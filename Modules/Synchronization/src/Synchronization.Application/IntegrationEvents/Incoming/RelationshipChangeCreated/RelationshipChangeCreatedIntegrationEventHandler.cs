﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.Synchronization.Application.Infrastructure;
using Backbone.Synchronization.Application.IntegrationEvents.Outgoing;
using Backbone.Synchronization.Domain.Entities.Sync;
using Microsoft.Extensions.Logging;

namespace Backbone.Synchronization.Application.IntegrationEvents.Incoming.RelationshipChangeCreated;

public class RelationshipChangeCreatedIntegrationEventHandler : IIntegrationEventHandler<RelationshipChangeCreatedIntegrationEvent>
{
    private readonly ISynchronizationDbContext _dbContext;
    private readonly IEventBus _eventBus;
    private readonly ILogger<RelationshipChangeCreatedIntegrationEventHandler> _logger;

    public RelationshipChangeCreatedIntegrationEventHandler(ISynchronizationDbContext dbContext, IEventBus eventBus, ILogger<RelationshipChangeCreatedIntegrationEventHandler> logger)
    {
        _dbContext = dbContext;
        _eventBus = eventBus;
        _logger = logger;
    }

    public async Task Handle(RelationshipChangeCreatedIntegrationEvent integrationEvent)
    {
        await CreateExternalEvent(integrationEvent);
    }

    private async Task CreateExternalEvent(RelationshipChangeCreatedIntegrationEvent integrationEvent)
    {
        var payload = new { integrationEvent.RelationshipId, integrationEvent.ChangeId };
        try
        {
            var externalEvent = await _dbContext.CreateExternalEvent(integrationEvent.ChangeRecipient, ExternalEventType.RelationshipChangeCreated, payload);
            _eventBus.Publish(new ExternalEventCreatedIntegrationEvent(externalEvent));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured while processing an integration event.");
            throw;
        }
    }
}
