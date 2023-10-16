﻿using Backbone.Modules.Devices.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Devices.Domain.Entities;
using Enmeshed.BuildingBlocks.Application.Abstractions.Exceptions;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.UserContext;
using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Backbone.Modules.Devices.Application.Devices.Commands.ChangePassword;

public class Handler : IRequestHandler<ChangePasswordCommand>
{
    private readonly DeviceId _activeDevice;
    private readonly ILogger<Handler> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IIdentitiesRepository _identitiesRepository;

    public Handler(UserManager<ApplicationUser> userManager, IUserContext userContext, ILogger<Handler> logger, IIdentitiesRepository identitiesRepository)
    {
        _userManager = userManager;
        _logger = logger;
        _activeDevice = userContext.GetDeviceId();
        _identitiesRepository = identitiesRepository;
    }

    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var currentDevice = await _identitiesRepository.GetDeviceById(_activeDevice, cancellationToken, track: true);

        var changePasswordResult = await _userManager.ChangePasswordAsync(currentDevice.User, request.OldPassword, request.NewPassword);

        if (!changePasswordResult.Succeeded)
            throw new OperationFailedException(ApplicationErrors.Devices.ChangePasswordFailed(changePasswordResult.Errors.First().Description));

        _logger.ChangedPasswordForDeviceWithId(_activeDevice);
    }
}

file static class LoggerExtensions
{
    private static readonly Action<ILogger, DeviceId, Exception> CHANGED_PASSWORD_FOR_DEVICE =
        LoggerMessage.Define<DeviceId>(
            LogLevel.Information,
            new EventId(277894, "Devices.ChangedPasswordForDeviceWithId"),
            "Successfully changed password for device with id '{activeDevice}'."
        );

    public static void ChangedPasswordForDeviceWithId(this ILogger logger, DeviceId activeDevice)
    {
        CHANGED_PASSWORD_FOR_DEVICE(logger, activeDevice, default!);
    }
}
