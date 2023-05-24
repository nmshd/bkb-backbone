﻿using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Domain.Aggregates.Metrics;
using Enmeshed.BuildingBlocks.Application.Abstractions.Exceptions;

namespace Backbone.Modules.Quotas.Infrastructure.Persistence.Repository;

public class MetricsRepository : IMetricsRepository
{
    private readonly List<Metric> _metrics;

    public MetricsRepository()
    {
        _metrics = new List<Metric>
        {
            new Metric(MetricKey.NumberOfSentMessages, "Number of Sent Messages"),
            new Metric(MetricKey.NumberOfRelationships, "Number of Relationships"),
            new Metric(MetricKey.NumberOfFiles, "Number of Files"),
            new Metric(MetricKey.FileStorageCapacity, "File Storage Capacity")
        };
    }

    public Task<Metric> Find(MetricKey key, CancellationToken cancellationToken)
    {
        var metric = _metrics.FirstOrDefault(metric => metric.Key == key);

        if (metric == null)
            throw new NotFoundException();

        return Task.FromResult(metric);
    }

    public Task<IEnumerable<Metric>> FindAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(_metrics.AsEnumerable());
    }
}