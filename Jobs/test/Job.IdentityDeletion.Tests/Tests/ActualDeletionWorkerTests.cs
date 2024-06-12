﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.BuildingBlocks.Application.Identities;
using Backbone.BuildingBlocks.Application.PushNotifications;
using Backbone.BuildingBlocks.Domain.Errors;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Job.IdentityDeletion.Workers;
using Backbone.Modules.Devices.Application.Identities.Commands.TriggerRipeDeletionProcesses;
using Backbone.Modules.Relationships.Application.Relationships.Commands.FindRelationshipsOfIdentity;
using Backbone.Modules.Relationships.Domain.Entities;
using Backbone.UnitTestTools.BaseClasses;
using Backbone.UnitTestTools.Data;
using CSharpFunctionalExtensions;
using FakeItEasy;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Backbone.Job.IdentityDeletion.Tests.Tests;

public class ActualDeletionWorkerTests : AbstractTestsBase
{
    [Fact]
    public async Task Proxies_triggering_the_deletion_processes_to_command_handler()
    {
        // Arrange
        var mockMediator = A.Fake<IMediator>();

        SetupRipeDeletionProcessesCommand(mockMediator);

        var identityDeleters = new List<IIdentityDeleter>();
        var worker = CreateWorker(mediator: mockMediator, identityDeleters);

        // Act
        await worker.StartProcessing(CancellationToken.None);

        // Assert
        A.CallTo(() => mockMediator.Send(A<TriggerRipeDeletionProcessesCommand>._, A<CancellationToken>._)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task Calls_Deleters_For_Each_Identity()
    {
        // Arrange
        var mockMediator = A.Fake<IMediator>();
        var identityAddress1 = TestDataGenerator.CreateRandomIdentityAddress();
        var identityAddress2 = TestDataGenerator.CreateRandomIdentityAddress();
        SetupRipeDeletionProcessesCommand(mockMediator, identityAddress1, identityAddress2);

        var mockIdentityDeleter = A.Fake<IIdentityDeleter>();
        var mockIDeletionProcessLogger = A.Fake<IDeletionProcessLogger>();

        var identityDeleters = new List<IIdentityDeleter> { mockIdentityDeleter };

        var worker = CreateWorker(mediator: mockMediator, identityDeleters, deletionProcessLogger: mockIDeletionProcessLogger);

        A.CallTo(() => mockMediator.Send(A<FindRelationshipsOfIdentityQuery>._, A<CancellationToken>._))
            .Returns(new FindRelationshipsOfIdentityResponse(new List<Relationship>()));

        // Act
        await worker.StartProcessing(CancellationToken.None);

        // Assert
        A.CallTo(() => mockIdentityDeleter.Delete(identityAddress1, mockIDeletionProcessLogger)).MustHaveHappenedOnceExactly();
        A.CallTo(() => mockIdentityDeleter.Delete(identityAddress2, mockIDeletionProcessLogger)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task Sends_push_notification_for_each_relationship_of_each_identity()
    {
        // Arrange
        var mockMediator = A.Fake<IMediator>();
        var identityAddress1 = TestDataGenerator.CreateRandomIdentityAddress();
        var identityAddress2 = TestDataGenerator.CreateRandomIdentityAddress();
        var identityAddress3 = TestDataGenerator.CreateRandomIdentityAddress();
        SetupRipeDeletionProcessesCommand(mockMediator, identityAddress1, identityAddress2, identityAddress3);
        A.CallTo(() => mockMediator.Send(A<FindRelationshipsOfIdentityQuery>._, A<CancellationToken>._)).Returns(new FindRelationshipsOfIdentityResponse(new List<Relationship>()));

        var mockPushNotificationSender = A.Dummy<IPushNotificationSender>();
        var worker = CreateWorker(mediator: mockMediator, pushNotificationSender: mockPushNotificationSender);

        // Act
        await worker.StartProcessing(CancellationToken.None);

        // Assert
        foreach (var identityAddress in new[] { identityAddress1, identityAddress2, identityAddress3 })
        {
            A.CallTo(() => mockPushNotificationSender.SendNotification(identityAddress, A<IPushNotification>._, A<CancellationToken>._)).MustHaveHappenedOnceExactly();
        }
    }

    private void SetupRipeDeletionProcessesCommand(IMediator mediator, params IdentityAddress[] identityAddresses)
    {
        var commandResponse = new TriggerRipeDeletionProcessesResponse(identityAddresses.ToDictionary(x => x, _ => UnitResult.Success<DomainError>()));
        A.CallTo(() => mediator.Send(A<TriggerRipeDeletionProcessesCommand>._, A<CancellationToken>._)).Returns(commandResponse);
    }

    private static ActualDeletionWorker CreateWorker(IMediator mediator,
        List<IIdentityDeleter>? identityDeleters = null,
        IEventBus? eventBus = null,
        IPushNotificationSender? pushNotificationSender = null,
        IDeletionProcessLogger? deletionProcessLogger = null)
    {
        var hostApplicationLifetime = A.Dummy<IHostApplicationLifetime>();
        identityDeleters ??= [A.Dummy<IIdentityDeleter>()];
        eventBus ??= A.Dummy<IEventBus>();
        pushNotificationSender ??= A.Dummy<IPushNotificationSender>();
        var logger = A.Dummy<ILogger<ActualDeletionWorker>>();
        deletionProcessLogger ??= A.Dummy<IDeletionProcessLogger>();
        return new ActualDeletionWorker(hostApplicationLifetime, identityDeleters, mediator, pushNotificationSender, eventBus, logger, deletionProcessLogger);
    }
}
