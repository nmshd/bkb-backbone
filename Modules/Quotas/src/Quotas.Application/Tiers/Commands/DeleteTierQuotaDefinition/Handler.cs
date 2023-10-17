﻿using Backbone.BuildingBlocks.Application.Abstractions.Exceptions;
using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.BuildingBlocks.Domain;
using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Application.IntegrationEvents.Outgoing;
using Backbone.Modules.Quotas.Domain.Aggregates.Tiers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backbone.Modules.Quotas.Application.Tiers.Commands.DeleteTierQuotaDefinition;
public class Handler : IRequestHandler<DeleteTierQuotaDefinitionCommand>
{
    private readonly ITiersRepository _tiersRepository;
    private readonly ILogger<Handler> _logger;
    private readonly IEventBus _eventBus;

    public Handler(ITiersRepository tiersRepository, ILogger<Handler> logger, IEventBus eventBus)
    {
        _tiersRepository = tiersRepository;
        _logger = logger;
        _eventBus = eventBus;
    }

    public async Task Handle(DeleteTierQuotaDefinitionCommand request, CancellationToken cancellationToken)
    {
        _logger.LogTrace("Deleting tier quota definition with id: '{tierQuotaDefinitionId}'.", request.TierQuotaDefinitionId);

        var tier = await _tiersRepository.Find(request.TierId, cancellationToken, true) ?? throw new NotFoundException(nameof(Tier));

        var result = tier.DeleteQuota(request.TierQuotaDefinitionId);
        if (result.IsFailure)
            throw new DomainException(result.Error);

        await _tiersRepository.Update(tier, cancellationToken);

        _logger.LogTrace("Successfully deleted tier quota definition with id: '{tierQuotaDefinitionId}'.", request.TierQuotaDefinitionId);

        _eventBus.Publish(new TierQuotaDefinitionDeletedIntegrationEvent(tier.Id, request.TierQuotaDefinitionId));

        _logger.LogTrace("Successfully published '{tierQuotaDefinitionDeletedIntegrationEvent}' with id: '{tierQuotaDefinitionId}' and tier id: '{tierId}'",
            nameof(TierQuotaDefinitionDeletedIntegrationEvent), request.TierQuotaDefinitionId, request.TierId);
    }
}
