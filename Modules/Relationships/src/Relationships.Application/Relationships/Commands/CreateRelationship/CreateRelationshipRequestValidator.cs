﻿using Backbone.BuildingBlocks.Application.FluentValidation;
using Backbone.Tooling.Extensions;
using FluentValidation;

namespace Backbone.Relationships.Application.Relationships.Commands.CreateRelationship;

// ReSharper disable once UnusedMember.Global
public class CreateRelationshipCommandValidator : AbstractValidator<CreateRelationshipCommand>
{
    public CreateRelationshipCommandValidator()
    {
        RuleFor(c => c.RelationshipTemplateId).DetailedNotEmpty();
        RuleFor(c => c.Content).NumberOfBytes(0, 10.Mebibytes());
    }
}
