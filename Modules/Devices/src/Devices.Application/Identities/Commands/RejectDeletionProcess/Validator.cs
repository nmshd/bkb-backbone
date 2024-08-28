﻿using Backbone.BuildingBlocks.Application.Extensions;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using FluentValidation;

namespace Backbone.Modules.Devices.Application.Identities.Commands.RejectDeletionProcess;

public class Validator : AbstractValidator<RejectDeletionProcessCommand>
{
    public Validator()
    {
        RuleFor(x => x.DeletionProcessId).ValidId<RejectDeletionProcessCommand, IdentityDeletionProcessId>();
    }
}