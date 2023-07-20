﻿using Backbone.Modules.Quotas.Domain;
using Backbone.Modules.Quotas.Domain.Metrics;
using Microsoft.Extensions.DependencyInjection;

namespace Backbone.Modules.Quotas.Application.Metrics;
public class ServiceProviderMetricCalculatorFactory : MetricCalculatorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceProviderMetricCalculatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override IMetricCalculator CreateNumberOfSentMessagesMetricCalculator()
    {
        var calculator = _serviceProvider.GetRequiredService<NumberOfSentMessagesMetricCalculator>();
        return calculator;
    }

    protected override IMetricCalculator CreateNumberOfFilesMetricCalculator()
    {
        var calculator = _serviceProvider.GetRequiredService<NumberOfFilesMetricCalculator>();
        return calculator;
    }

    protected override IMetricCalculator CreateNumberOfRelationshipsMetricCalculator()
    {
        var calculator = _serviceProvider.GetRequiredService<NumberOfRelationshipsMetricCalculator>();
        return calculator;
    }
}
