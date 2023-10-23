﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus.Events;

namespace Backbone.Quotas.Application.IntegrationEvents.Incoming.TierOfIdentityChanged;
public class TierOfIdentityChangedIntegrationEvent : IntegrationEvent
{
    public string OldTier { get; set; }
    public string NewTier { get; set; }
    public string IdentityAddress { get; set; }
}
