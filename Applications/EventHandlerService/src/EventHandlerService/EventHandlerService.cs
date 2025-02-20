﻿using Backbone.BuildingBlocks.API;
using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;

namespace Backbone.EventHandlerService;

public class EventHandlerService : IHostedService
{
    private readonly IEventBus _eventBus;
    private readonly IEnumerable<AbstractModule> _modules;
    private readonly ILogger<EventHandlerService> _logger;

    public EventHandlerService(IEventBus eventBus, IEnumerable<AbstractModule> modules, ILogger<EventHandlerService> logger)
    {
        _eventBus = eventBus;
        _modules = modules;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await SubscribeToEvents();
        await _eventBus.StartConsuming(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _eventBus.StopConsuming(cancellationToken);
    }

    private async Task SubscribeToEvents()
    {
        _logger.LogInformation("Subscribing to events...");
        foreach (var module in _modules)
        {
            await module.ConfigureEventBus(_eventBus);
        }

        _logger.LogInformation("Successfully subscribed to events.");
    }
}
