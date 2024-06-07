﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.BuildingBlocks.Domain;
using Backbone.Modules.Devices.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Devices.Domain.DomainEvents.Outgoing;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using MediatR;

namespace Backbone.Modules.Devices.Application.Identities.Commands.TriggerRipeDeletionProcesses;
public class Handler : IRequestHandler<TriggerRipeDeletionProcessesCommand, TriggerRipeDeletionProcessesResponse>
{
    private readonly IIdentitiesRepository _identitiesRepository;
    private readonly IEventBus _eventBus;

    public Handler(IIdentitiesRepository identitiesRepository, IEventBus eventBus)
    {
        _identitiesRepository = identitiesRepository;
        _eventBus = eventBus;
    }

    public async Task<TriggerRipeDeletionProcessesResponse> Handle(TriggerRipeDeletionProcessesCommand request, CancellationToken cancellationToken)
    {
        var identities = await _identitiesRepository.Find(Identity.IsReadyForDeletion(), cancellationToken, track: true);

        var response = new TriggerRipeDeletionProcessesResponse();

        foreach (var identity in identities)
        {
            try
            {
                identity.DeletionStarted();
                await _identitiesRepository.Update(identity, cancellationToken);
                _eventBus.Publish(new IdentityDeletedDomainEvent(identity.Address));
                response.AddSuccess(identity.Address);
            }
            catch (DomainException ex)
            {
                response.AddError(identity.Address, ex.Error);
            }
        }

        return response;
    }
}
