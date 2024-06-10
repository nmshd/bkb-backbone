﻿using Backbone.DevelopmentKit.Identity.ValueObjects;

namespace Backbone.BuildingBlocks.Application.Identities;
public interface IIdentityDeleter
{
    Task Delete(IdentityAddress identityAddress, IDeletionProcessLogger deletionProcessLogger);
}

public interface IDeletionProcessLogger
{
    Task LogDeletion(IdentityAddress identityAddress, AggregateType aggregateType);
}

public enum AggregateType
{
    Challenges,
    PnsRegistrations,
    Identity,
    Files,
    Messages,
    QuotasIdentity,
    Relationships,
    RelationshipTemplates,
    RelationshipTemplateAllocations,
    ExternalEvents,
    SyncRuns,
    Datawallets,
    Tokens
}
