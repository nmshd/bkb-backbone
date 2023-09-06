﻿using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Application.IntegrationEvents.Incoming.QuotaCreatedForTier;
using Backbone.Modules.Quotas.Application.IntegrationEvents.Outgoing;
using Backbone.Modules.Quotas.Application.Metrics;
using Backbone.Modules.Quotas.Application.Tests.TestDoubles;
using Backbone.Modules.Quotas.Domain.Aggregates.Identities;
using Backbone.Modules.Quotas.Domain.Aggregates.Metrics;
using Backbone.Modules.Quotas.Domain.Aggregates.Tiers;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Backbone.Modules.Quotas.Application.Tests.Tests.Identities;

public class QuotaCreatedForTierIntegrationEventHandlerTests
{
    [Fact]
    public async void Creates_tier_quota_after_consuming_integration_event()
    {
        // Arrange
        var tierId = new TierId("TIRFxoL0U24aUqZDSAWc");

        var tierQuotaDefinition = new TierQuotaDefinition(MetricKey.NumberOfSentMessages, 5, QuotaPeriod.Month);
        var tierQuotaDefinitionsRepository = new FindTierQuotaDefinitionsStubRepository(tierQuotaDefinition);

        var firstIdentity = new Identity("some-identity-address-one", tierId);
        var secondIdentity = new Identity("some-identity-address-two", tierId);
        var identities = new List<Identity> { firstIdentity, secondIdentity };
        var identitiesRepository = A.Fake<IIdentitiesRepository>();
        A.CallTo(() => identitiesRepository.FindWithTier(tierId, CancellationToken.None, true)).Returns(identities);
        var handler = CreateHandler(identitiesRepository, tierQuotaDefinitionsRepository, null);

        // Act
        await handler.Handle(new QuotaCreatedForTierIntegrationEvent(tierId, tierQuotaDefinition.Id));

        // Assert
        A.CallTo(() => identitiesRepository.Update(A<IEnumerable<Identity>>.That.Matches(ids =>
            ids.All(i => i.TierQuotas.Count == 1))
            , CancellationToken.None)
        ).MustHaveHappened();
    }

    [Fact]
    public async void Updates_metric_statuses_after_creating_tier_quota()
    {
        // Arrange
        var tierId = new TierId("TIRFxoL0U24aUqZDSAWc");

        var tierQuotaDefinition = new TierQuotaDefinition(MetricKey.NumberOfSentMessages, 5, QuotaPeriod.Month);
        var tierQuotaDefinitionsRepository = new FindTierQuotaDefinitionsStubRepository(tierQuotaDefinition);

        var firstIdentity = new Identity("some-identity-address-one", tierId);
        var secondIdentity = new Identity("some-identity-address-two", tierId);
        var identities = new List<Identity> { firstIdentity, secondIdentity };
        var identitiesRepository = A.Fake<IIdentitiesRepository>();
        A.CallTo(() => identitiesRepository.FindWithTier(tierId, CancellationToken.None, true)).Returns(identities);
        var metricStatusesService = A.Fake<IMetricStatusesService>();
        var handler = CreateHandler(identitiesRepository, tierQuotaDefinitionsRepository, metricStatusesService);

        // Act
        await handler.Handle(new QuotaCreatedForTierIntegrationEvent(tierId, tierQuotaDefinition.Id));

        // Assert
        A.CallTo(() => metricStatusesService.RecalculateMetricStatuses(
            A<List<string>>.That.Matches(x => x.Count == identities.Count),
            A<List<string>>.That.Contains(tierQuotaDefinition.MetricKey.Value),
            A<CancellationToken>._)
        ).MustHaveHappened();
    }

    private QuotaCreatedForTierIntegrationEventHandler CreateHandler(IIdentitiesRepository identities, ITiersRepository tierQuotaDefinitions, IMetricStatusesService? metricStatusesService)
    {
        var logger = A.Fake<ILogger<QuotaCreatedForTierIntegrationEventHandler>>();
        return new QuotaCreatedForTierIntegrationEventHandler(identities, tierQuotaDefinitions, logger, metricStatusesService ?? A.Fake<IMetricStatusesService>());
    }
}
