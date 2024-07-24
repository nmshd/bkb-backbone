﻿using Backbone.BuildingBlocks.Application.FluentValidation;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using FluentValidation;

namespace Backbone.Modules.Relationships.Application.Relationships.Commands.FindRelationshipsOfIdentity;

public class Validator : AbstractValidator<FindRelationshipsOfIdentityQuery>
{
    public Validator()
    {
        RuleFor(x => x.IdentityAddress).ValidId<FindRelationshipsOfIdentityQuery, IdentityAddress>();
    }
}
