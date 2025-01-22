﻿using Backbone.BuildingBlocks.Application.Abstractions.Exceptions;
using Backbone.BuildingBlocks.Application.FluentValidation;
using Backbone.Modules.Announcements.Domain.Entities;
using FluentValidation;

namespace Backbone.Modules.Announcements.Application.Announcements.Commands.CreateAnnouncement;

public class Validator : AbstractValidator<CreateAnnouncementCommand>
{
    public Validator()
    {
        RuleFor(x => x.Texts)
            .Must(x => x.Any(t => t.Language == AnnouncementLanguage.DEFAULT_LANGUAGE.Value))
            .WithErrorCode(GenericApplicationErrors.Validation.InvalidPropertyValue().Code)
            .WithMessage("There must be a text for English.");

        RuleFor(x => x.Recipients)
            .Must(x => x is null or { Count: <= 100 })
            .WithErrorCode(GenericApplicationErrors.Validation.InvalidPropertyValue().Code)
            .WithMessage("The maximum number of recipients is 100.");

        RuleForEach(x => x.Texts).SetValidator(new CreateAnnouncementCommandTextValidator());
        RuleForEach(x => x.Recipients).SetValidator(new CreateAnnouncementCommandRecipientValidator());
    }
}

public class CreateAnnouncementCommandRecipientValidator : AbstractValidator<string>
{
    public CreateAnnouncementCommandRecipientValidator()
    {
        RuleFor(recipient => recipient).DetailedNotEmpty();
    }
}

public class CreateAnnouncementCommandTextValidator : AbstractValidator<CreateAnnouncementCommandText>
{
    public CreateAnnouncementCommandTextValidator()
    {
        RuleFor(x => x.Language).TwoLetterIsoLanguage();
        RuleFor(x => x.Title).DetailedNotEmpty();
        RuleFor(x => x.Body).DetailedNotEmpty();
    }
}
