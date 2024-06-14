using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.IdentityDeletionProcessStarted;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.IdentityDeletionProcessStatusChanged;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.MessageCreated;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.PeerDeleted;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.PeerDeletionCanceled;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.PeerToBeDeleted;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.RelationshipChangeCompleted;
using Backbone.Modules.Synchronization.Application.DomainEvents.Incoming.RelationshipChangeCreated;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.IdentityDeletionProcessStarted;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.IdentityDeletionProcessStatusChanged;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.MessageCreated;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.PeerDeleted;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.PeerDeletionCanceled;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.PeerToBeDeleted;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.RelationshipChangeCompleted;
using Backbone.Modules.Synchronization.Domain.DomainEvents.Incoming.RelationshipChangeCreated;

namespace Backbone.Modules.Synchronization.Application.Extensions;

public static class IEventBusExtensions
{
    public static IEventBus AddSynchronizationDomainEventSubscriptions(this IEventBus eventBus)
    {
        SubscribeToMessagesEvents(eventBus);
        SubscribeToRelationshipsEvents(eventBus);

        return eventBus;
    }

    private static void SubscribeToMessagesEvents(IEventBus eventBus)
    {
        eventBus.Subscribe<MessageCreatedDomainEvent, MessageCreatedDomainEventHandler>();
        eventBus.Subscribe<IdentityDeletionProcessStartedDomainEvent, IdentityDeletionProcessStartedDomainEventHandler>();
        eventBus.Subscribe<IdentityDeletionProcessStatusChangedDomainEvent, IdentityDeletionProcessStatusChangedDomainEventHandler>();
        // eventBus.Subscribe<MessageDeliveredDomainEvent, MessageDeliveredDomainEventHandler>(); // this is temporarily disabled to avoid an external event flood when the same message is sent to many recipients
    }

    private static void SubscribeToRelationshipsEvents(IEventBus eventBus)
    {
        eventBus.Subscribe<RelationshipChangeCompletedDomainEvent, RelationshipChangeCompletedDomainEventHandler>();
        eventBus.Subscribe<RelationshipChangeCreatedDomainEvent, RelationshipChangeCreatedDomainEventHandler>();
        eventBus.Subscribe<PeerToBeDeletedDomainEvent, PeerToBeDeletedDomainEventHandler>();
        eventBus.Subscribe<PeerDeletionCanceledDomainEvent, PeerDeletionCanceledDomainEventHandler>();
        eventBus.Subscribe<PeerDeletedDomainEvent, PeerDeletedDomainEventHandler>();
    }
}
