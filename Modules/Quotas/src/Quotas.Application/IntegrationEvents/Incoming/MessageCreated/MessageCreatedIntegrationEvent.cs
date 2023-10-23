﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus.Events;

namespace Backbone.Quotas.Application.IntegrationEvents.Incoming.MessageCreated;
public class MessageCreatedIntegrationEvent : IntegrationEvent
{
    public string Id { get; private set; }
    public IEnumerable<string> Recipients { get; private set; }
    public string CreatedBy { get; private set; }
}
