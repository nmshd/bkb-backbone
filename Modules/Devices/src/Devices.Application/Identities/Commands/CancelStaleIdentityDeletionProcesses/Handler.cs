﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.Modules.Devices.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Devices.Application.IntegrationEvents.Outgoing;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using MediatR;

namespace Backbone.Modules.Devices.Application.Identities.Commands.CancelStaleIdentityDeletionProcesses;

public class Handler : IRequestHandler<CancelStaleIdentityDeletionProcessesCommand, CancelStaleIdentityDeletionProcessesResponse>
{
    private readonly IIdentitiesRepository _identityRepository;
    private readonly IEventBus _eventBus;

    public Handler(IIdentitiesRepository identityRepository, IEventBus eventBus)
    {
        _identityRepository = identityRepository;
        _eventBus = eventBus;
    }

    public async Task<CancelStaleIdentityDeletionProcessesResponse> Handle(CancelStaleIdentityDeletionProcessesCommand request, CancellationToken cancellationToken)
    {
        var identities = await _identityRepository.FindAllWithDeletionProcessInStatus(DeletionProcessStatus.WaitingForApproval, cancellationToken, true);

        var staleDeletionProcesses = new CancelStaleIdentityDeletionProcessesResponse();

        foreach (var identity in identities)
        {
            var staleDeletionProcess = identity.DeletionProcesses.First(dp => dp.Status == DeletionProcessStatus.WaitingForApproval);

            if (IsInApprovalPeriod(staleDeletionProcess))
                continue;

            identity.CancelStaleDeletionProcess(staleDeletionProcess.Id);
            staleDeletionProcesses.CanceledIdentityDeletionPrecessIds.Add(staleDeletionProcess.Id);

            _eventBus.Publish(new IdentityDeletionProcessStatusChangedIntegrationEvent(identity.Address, staleDeletionProcess.Id));

            await _identityRepository.Update(identity, cancellationToken);
        }

        return staleDeletionProcesses;
    }

    private static bool IsInApprovalPeriod(IdentityDeletionProcess staleDeletionProcess)
    {
        return staleDeletionProcess.CreatedAt.AddDays(IdentityDeletionConfiguration.MaxApprovalTime) > DateTime.UtcNow;
    }
}
