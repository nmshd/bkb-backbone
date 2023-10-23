﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.Devices.Application.Infrastructure.PushNotifications;
using Backbone.Devices.Application.Infrastructure.PushNotifications.Datawallet;

namespace Backbone.Devices.Application.IntegrationEvents.Incoming.DatawalletModificationCreated;

public class DatawalletModifiedIntegrationEventHandler : IIntegrationEventHandler<DatawalletModifiedIntegrationEvent>
{
    private readonly IPushService _pushService;

    public DatawalletModifiedIntegrationEventHandler(IPushService pushService)
    {
        _pushService = pushService;
    }

    public async Task Handle(DatawalletModifiedIntegrationEvent integrationEvent)
    {
        await _pushService.SendNotification(integrationEvent.Identity, new DatawalletModificationsCreatedPushNotification(integrationEvent.ModifiedByDevice), CancellationToken.None);
    }
}
