using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Application.Metrics;
using Backbone.Modules.Quotas.Domain.Aggregates.Metrics;
using Backbone.Modules.Quotas.Domain.Aggregates.Tiers;
using Backbone.Modules.Quotas.Domain.DomainEvents.Outgoing;
using Microsoft.Extensions.Logging;

namespace Backbone.Modules.Quotas.Application.DomainEvents.Incoming.QuotaCreatedForTier;

public class QuotaCreatedForTierDomainEventHandler : IDomainEventHandler<QuotaCreatedForTierDomainEvent>
{
    private readonly IIdentitiesRepository _identitiesRepository;
    private readonly ITiersRepository _tiersRepository;
    private readonly ILogger<QuotaCreatedForTierDomainEventHandler> _logger;
    private readonly IMetricStatusesService _metricStatusesService;

    public QuotaCreatedForTierDomainEventHandler(IIdentitiesRepository identitiesRepository,
        ITiersRepository tiersRepository, ILogger<QuotaCreatedForTierDomainEventHandler> logger, IMetricStatusesService metricStatusesService)
    {
        _identitiesRepository = identitiesRepository;
        _tiersRepository = tiersRepository;
        _logger = logger;
        _metricStatusesService = metricStatusesService;
    }

    public async Task Handle(QuotaCreatedForTierDomainEvent @event)
    {
        _logger.LogTrace("Handling QuotaCreatedForTierDomainEvent...");

        var identitiesWithTier = await _identitiesRepository.FindWithTier(new TierId(@event.TierId), CancellationToken.None, true);

        if (!identitiesWithTier.Any())
        {
            _logger.LogTrace("No identities found with tier ID: '{tierId}'.", @event.TierId);
            return;
        }

        var tierQuotaDefinition = await _tiersRepository.FindTierQuotaDefinition(@event.TierQuotaDefinitionId, CancellationToken.None, true);

        foreach (var identity in identitiesWithTier)
        {
            identity.AssignTierQuotaFromDefinition(tierQuotaDefinition);
        }

        await _identitiesRepository.Update(identitiesWithTier, CancellationToken.None);

        var identityAddresses = identitiesWithTier.Select(i => i.Address).ToList();
        var metrics = new List<MetricKey> { tierQuotaDefinition.MetricKey };
        await _metricStatusesService.RecalculateMetricStatuses(identityAddresses, metrics, CancellationToken.None);

        _logger.LogInformation("Successfully created quotas for Identities.");
    }
}
