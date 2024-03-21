﻿using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Relationships.Domain.Aggregates.Relationships;
using Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates;

namespace Backbone.Modules.Relationships.Domain.Tests.TestHelpers;

public static class TestData
{
    public static readonly IdentityAddress IDENTITY_1 = IdentityAddress.Create([1, 1, 1], "id1");
    public static readonly DeviceId DEVICE_1 = DeviceId.New();

    public static readonly IdentityAddress IDENTITY_2 = IdentityAddress.Create([2, 2, 2], "id1");
    public static readonly DeviceId DEVICE_2 = DeviceId.New();

    public static readonly RelationshipTemplate RELATIONSHIP_TEMPLATE_OF_1 = new(IDENTITY_1, DEVICE_1, 1, null, []);
    public static readonly RelationshipTemplate RELATIONSHIP_TEMPLATE_OF_2 = new(IDENTITY_2, DEVICE_2, 1, null, []);

    public static Relationship CreatePendingRelationship()
    {
        return new Relationship(RELATIONSHIP_TEMPLATE_OF_2, IDENTITY_1, DEVICE_1, null, []);
    }

    public static Relationship CreateActiveRelationship()
    {
        var relationship = new Relationship(RELATIONSHIP_TEMPLATE_OF_2, IDENTITY_1, DEVICE_1, null, []);
        relationship.Accept(IDENTITY_2, DEVICE_2);
        return relationship;
    }
}
