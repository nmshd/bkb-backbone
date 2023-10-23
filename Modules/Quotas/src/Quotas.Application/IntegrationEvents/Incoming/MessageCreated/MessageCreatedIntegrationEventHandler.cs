﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.Quotas.Application.Metrics;
using Backbone.Quotas.Domain.Aggregates.Metrics;

namespace Backbone.Quotas.Application.IntegrationEvents.Incoming.MessageCreated;
public class MessageCreatedIntegrationEventHandler : IIntegrationEventHandler<MessageCreatedIntegrationEvent>
{
    private readonly IMetricStatusesService _metricStatusesService;

    public MessageCreatedIntegrationEventHandler(IMetricStatusesService metricStatusesService)
    {
        _metricStatusesService = metricStatusesService;
    }

    public async Task Handle(MessageCreatedIntegrationEvent integrationEvent)
    {
        var identities = new List<string> { integrationEvent.CreatedBy };
        var metrics = new List<string> { MetricKey.NumberOfSentMessages.Value };

        await _metricStatusesService.RecalculateMetricStatuses(identities, metrics, CancellationToken.None);
    }
}
