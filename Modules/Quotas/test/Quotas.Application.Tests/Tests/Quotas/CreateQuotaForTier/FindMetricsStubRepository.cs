﻿using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Domain.Aggregates.Metrics;

namespace Backbone.Modules.Quotas.Application.Tests.Tests.Quotas.CreateQuotaForTier;

public class FindMetricsStubRepository : IMetricsRepository
{
    private readonly Metric _metric;

    public FindMetricsStubRepository(Metric metric)
    {
        _metric = metric;
    }

    public Task<Metric> Find(MetricKey key, CancellationToken cancellationToken)
    {
        return Task.FromResult(_metric);
    }

    public Task<IEnumerable<Metric>> FindAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
