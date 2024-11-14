using Backbone.BuildingBlocks.Application.PushNotifications;
using Backbone.BuildingBlocks.Infrastructure.Exceptions;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Devices.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Devices.Application.Infrastructure.PushNotifications;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications.Handles;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using Backbone.Modules.Devices.Infrastructure.PushNotifications.Connectors;
using Backbone.Modules.Devices.Infrastructure.PushNotifications.NotificationTexts;
using Backbone.Modules.Devices.Infrastructure.PushNotifications.Responses;
using Microsoft.Extensions.Logging;

namespace Backbone.Modules.Devices.Infrastructure.PushNotifications;

public class PushService : IPushNotificationRegistrationService, IPushNotificationSender
{
    private readonly IPnsRegistrationsRepository _pnsRegistrationsRepository;
    private readonly ILogger<PushService> _logger;
    private readonly PnsConnectorFactory _pnsConnectorFactory;
    private readonly IPushNotificationTextProvider _notificationTextProvider;
    private readonly IIdentitiesRepository _identitiesRepository;

    public PushService(IPnsRegistrationsRepository pnsRegistrationRepository, PnsConnectorFactory pnsConnectorFactory, ILogger<PushService> logger,
        IPushNotificationTextProvider notificationTextProvider, IIdentitiesRepository identitiesRepository)
    {
        _pnsRegistrationsRepository = pnsRegistrationRepository;
        _pnsConnectorFactory = pnsConnectorFactory;
        _logger = logger;
        _notificationTextProvider = notificationTextProvider;
        _identitiesRepository = identitiesRepository;
    }

    public async Task SendNotification(IPushNotificationWithConstantText notification, SendPushNotificationFilter filter, CancellationToken cancellationToken)
    {
        var notificationTexts = _notificationTextProvider.GetNotificationTextsForLanguages(notification.GetType(), await GetDistinctCommunicationLanguages(filter, cancellationToken));
        await SendNotificationInternal(notification, filter, notificationTexts, cancellationToken);
    }

    public async Task SendNotification(IPushNotificationWithDynamicText notification, SendPushNotificationFilter filter, Dictionary<string, NotificationText> notificationTexts,
        CancellationToken cancellationToken)
    {
        await SendNotificationInternal(
            notification,
            filter,
            notificationTexts.ToDictionary(kvp => CommunicationLanguage.Create(kvp.Key).Value, kvp => kvp.Value),
            cancellationToken
        );
    }

    private async Task SendNotificationInternal(IPushNotification notification, SendPushNotificationFilter filter, Dictionary<CommunicationLanguage, NotificationText> notificationTexts,
        CancellationToken cancellationToken)
    {
        var registrations = await _pnsRegistrationsRepository.Find(r => filter.IncludedIdentities.Contains(r.IdentityAddress) && !filter.ExcludedDevices.Contains(r.DeviceId), cancellationToken);

        var deviceIds = registrations.Select(r => r.DeviceId).ToList();

        var devices = await _identitiesRepository.FindDevices(
            d => deviceIds.Contains(d.Id),
            d => new { d.Id, d.CommunicationLanguage },
            cancellationToken
        );

        var groups = registrations.GroupBy(registration => registration.Handle.Platform);

        foreach (var group in groups)
        {
            var platform = group.Key;

            var pnsConnector = _pnsConnectorFactory.CreateFor(platform);

            var sendTasks = group
                .Select(r =>
                {
                    var device = devices.First(d => d.Id == r.DeviceId);
                    return pnsConnector.Send(r, notification, notificationTexts[device.CommunicationLanguage]);
                });

            var sendResults = await Task.WhenAll(sendTasks);
            await HandleNotificationResponses(new SendResults(sendResults));
        }
    }

    private async Task<List<CommunicationLanguage>> GetDistinctCommunicationLanguages(SendPushNotificationFilter filter, CancellationToken cancellationToken)
    {
        var devices = await _identitiesRepository.FindDevices(
            d => filter.IncludedIdentities.Contains(d.IdentityAddress) && !filter.ExcludedDevices.Contains(d.Id),
            d => new { d.CommunicationLanguage },
            cancellationToken
        );

        return devices.Select(d => d.CommunicationLanguage).Distinct().ToList();
    }

    private async Task HandleNotificationResponses(SendResults sendResults)
    {
        var deviceIdsToDelete = new List<DeviceId>();
        foreach (var sendResult in sendResults.Failures)
        {
            switch (sendResult.Error!.Reason)
            {
                case ErrorReason.InvalidHandle:
                    _logger.DeletingDeviceRegistration();
                    deviceIdsToDelete.Add(sendResult.DeviceId);
                    break;
                case ErrorReason.Unexpected:
                    _logger.ErrorWhileTryingToSendNotification(sendResult.Error.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Reason '{sendResult.Error.Reason}' not supported");
            }
        }

        await _pnsRegistrationsRepository.Delete(deviceIdsToDelete, CancellationToken.None);

        _logger.LogTrace("Successfully sent push notifications.");
    }

    public async Task<DevicePushIdentifier> UpdateRegistration(IdentityAddress address, DeviceId deviceId, PnsHandle handle, string appId, PushEnvironment environment,
        CancellationToken cancellationToken)
    {
        var registration = await _pnsRegistrationsRepository.FindByDeviceId(deviceId, cancellationToken, track: true);
        var pnsConnector = _pnsConnectorFactory.CreateFor(handle.Platform);

        if (registration != null)
        {
            registration.Update(handle, appId, environment);
            pnsConnector.ValidateRegistration(registration);

            await _pnsRegistrationsRepository.Update(registration, cancellationToken);

            _logger.LogTrace("Device successfully updated.");
        }
        else
        {
            registration = new PnsRegistration(address, deviceId, handle, appId, environment);
            pnsConnector.ValidateRegistration(registration);

            try
            {
                await _pnsRegistrationsRepository.Add(registration, cancellationToken);
                _logger.LogTrace("New device successfully registered.");
            }
            catch (InfrastructureException exception) when (exception.Code == InfrastructureErrors.UniqueKeyViolation().Code)
            {
                _logger.LogInformation(exception, "This exception can be ignored. It is only thrown in case of a concurrent registration request from multiple devices.");
            }
        }

        return registration.DevicePushIdentifier;
    }

    public async Task DeleteRegistration(DeviceId deviceId, CancellationToken cancellationToken)
    {
        var registration = await _pnsRegistrationsRepository.FindByDeviceId(deviceId, cancellationToken, track: true);

        if (registration == null)
        {
            _logger.LogInformation("Device not found.");
        }
        else
        {
            await _pnsRegistrationsRepository.Delete(new List<DeviceId> { deviceId }, cancellationToken);
            _logger.UnregisteredDevice();
        }
    }
}

internal static partial class DirectPushServiceLogs
{
    [LoggerMessage(
        EventId = 950845,
        EventName = "Devices.DirectPushService.DeletingDeviceRegistration",
        Level = LogLevel.Information,
        Message = "Deleting device registration for the device since handle is no longer valid.")]
    public static partial void DeletingDeviceRegistration(this ILogger logger);

    [LoggerMessage(
        EventId = 624412,
        EventName = "Devices.DirectPushService.ErrorWhileTryingToSendNotification",
        Level = LogLevel.Error,
        Message = "The following error occurred while trying to send the notification for the device: '{error}'.")]
    public static partial void ErrorWhileTryingToSendNotification(this ILogger logger, string error);

    [LoggerMessage(
        EventId = 628738,
        EventName = "Devices.DirectPushService.UnregisteredDevice",
        Level = LogLevel.Information,
        Message = "Unregistered the device from push notifications.")]
    public static partial void UnregisteredDevice(this ILogger logger);
}
