﻿using Backbone.BuildingBlocks.Application.Identities;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Messages.Application.Messages.Commands.AnonymizeMessagesOfIdentity;
using MediatR;

namespace Backbone.Modules.Messages.Application.Identities;
public class IdentityDeleter : IIdentityDeleter
{
    private readonly IMediator _mediator;

    public IdentityDeleter(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Delete(IdentityAddress identityAddress, IDeletionProcessLogger deletionProcessLogger)
    {
        await _mediator.Send(new AnonymizeMessagesOfIdentityCommand(identityAddress));
        await deletionProcessLogger.LogDeletion(identityAddress, AggregateType.Messages); // TODO: these are not deleted but anonymized, perhaps adapt the names?
    }
}
