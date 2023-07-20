﻿using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Domain;

namespace Backbone.Modules.Quotas.Application.Metrics;
public class NumberOfRelationshipsMetricCalculator : IMetricCalculator
{
    private readonly IRelationshipsRepository _relationshipsRepository;

    public NumberOfRelationshipsMetricCalculator(IRelationshipsRepository relationshipsRepository)
    {
        _relationshipsRepository = relationshipsRepository;    
    }

    public async Task<uint> CalculateUsage(DateTime from, DateTime to, string uploader, CancellationToken cancellationToken)
    {
        var numberOfRelationships = await _relationshipsRepository.Count(uploader, from, to, cancellationToken);
        return numberOfRelationships;
    }
}
