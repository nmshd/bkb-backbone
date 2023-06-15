﻿using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Domain;
using MediatR;

namespace Backbone.Modules.Quotas.Application.Metrics.Commands.RecalculateMetricStatuses;
public class Handler : IRequestHandler<RecalculateMetricStatusesCommand>
{
    private readonly IMetricCalculatorFactory _metricCalculatorFactory;
    private readonly IIdentitiesRepository _identitiesRepository;

    public Handler(IMetricCalculatorFactory metricCalculatorFactory, IIdentitiesRepository identitiesRepository)
    {
        _metricCalculatorFactory = metricCalculatorFactory;
        _identitiesRepository = identitiesRepository;
    }

    public async Task Handle(RecalculateMetricStatusesCommand command, CancellationToken cancellationToken)
    {
        var identities = await _identitiesRepository.FindByAddresses(command.Identities, cancellationToken);
        
        foreach (var identity in identities)
        {
            await identity.UpdateMetrics(command.Metrics, _metricCalculatorFactory, cancellationToken);
        }

        await _identitiesRepository.Update(identities, cancellationToken);
    }
}
