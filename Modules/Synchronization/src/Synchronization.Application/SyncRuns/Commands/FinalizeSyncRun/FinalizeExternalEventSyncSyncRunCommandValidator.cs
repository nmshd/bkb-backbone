﻿using Backbone.BuildingBlocks.Application.FluentValidation;
using Backbone.Synchronization.Application.Datawallets.DTOs;
using FluentValidation;

namespace Backbone.Synchronization.Application.SyncRuns.Commands.FinalizeSyncRun;

// ReSharper disable once UnusedMember.Global
public class FinalizeExternalEventSyncSyncRunCommandValidator : AbstractValidator<FinalizeExternalEventSyncSyncRunCommand>
{
    public FinalizeExternalEventSyncSyncRunCommandValidator()
    {
        RuleForEach(x => x.ExternalEventResults).SetValidator(new EventResultValidator());
        RuleForEach(x => x.DatawalletModifications).SetValidator(new PushDatawalletModificationItemValidator());
    }

    public class EventResultValidator : AbstractValidator<FinalizeExternalEventSyncSyncRunCommand.ExternalEventResult>
    {
        public EventResultValidator()
        {
            RuleFor(i => i.ExternalEventId).DetailedNotEmpty();
        }
    }
}
