﻿using Backbone.BuildingBlocks.Application.FluentValidation;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using FluentValidation;

namespace Backbone.Modules.Devices.Application.Identities.Commands.CancelDeletionProcessAsOwner;

public class Validator : AbstractValidator<CancelDeletionProcessAsOwnerCommand>
{
    public Validator()
    {
        RuleFor(x => x.DeletionProcessId).ValidId<CancelDeletionProcessAsOwnerCommand, IdentityDeletionProcessId>();
    }
}