﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus.Events;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Relationships.Domain.Aggregates.Relationships;

namespace Backbone.Modules.Relationships.Application.IntegrationEvents.Outgoing;
public class RelationshipReactivationRevokedIntegrationEvent : IntegrationEvent
{
    public RelationshipReactivationRevokedIntegrationEvent(Relationship relationship, IdentityAddress partner) : 
        base($"{relationship.Id}/Reactivation/Revoked/{relationship.AuditLog.Last().CreatedAt}")
    {
        RelationshipId = relationship.Id;
        Partner = partner.StringValue;
    }

    public string RelationshipId { get; }
    public string Partner { get; }
}
