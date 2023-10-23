﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Synchronization.Application.Infrastructure;
using Backbone.Synchronization.Application.IntegrationEvents.Outgoing;
using Backbone.Synchronization.Domain.Entities.Sync;
using Microsoft.Extensions.Logging;

namespace Backbone.Synchronization.Application.IntegrationEvents.Incoming.MessageCreated;

public class MessageCreatedIntegrationEventHandler : IIntegrationEventHandler<MessageCreatedIntegrationEvent>
{
    private readonly ISynchronizationDbContext _dbContext;
    private readonly IEventBus _eventBus;
    private readonly ILogger<MessageCreatedIntegrationEventHandler> _logger;

    public MessageCreatedIntegrationEventHandler(ISynchronizationDbContext dbContext, IEventBus eventBus, ILogger<MessageCreatedIntegrationEventHandler> logger)
    {
        _dbContext = dbContext;
        _eventBus = eventBus;
        _logger = logger;
    }

    public async Task Handle(MessageCreatedIntegrationEvent integrationEvent)
    {
        await CreateExternalEvents(integrationEvent);
    }

    private async Task CreateExternalEvents(MessageCreatedIntegrationEvent integrationEvent)
    {
        foreach (var recipient in integrationEvent.Recipients)
        {
            var payload = new { integrationEvent.Id };
            try
            {
                var externalEvent = await _dbContext.CreateExternalEvent(IdentityAddress.Parse(recipient), ExternalEventType.MessageReceived, payload);
                _eventBus.Publish(new ExternalEventCreatedIntegrationEvent(externalEvent));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while processing an integration event.");
                throw;
            }
        }
    }
}
