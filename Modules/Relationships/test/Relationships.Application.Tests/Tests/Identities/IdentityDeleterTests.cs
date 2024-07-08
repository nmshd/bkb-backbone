﻿using Backbone.BuildingBlocks.Application.Identities;
using Backbone.Modules.Relationships.Application.Identities;
using Backbone.Modules.Relationships.Application.Relationships.Commands.DeleteRelationshipsOfIdentity;
using Backbone.Modules.Relationships.Application.RelationshipTemplates.Commands.AnonymizeRelationshipTemplateAllocationsAllocatedByIdentity;
using Backbone.Modules.Relationships.Application.RelationshipTemplates.Commands.DeleteRelationshipTemplatesOfIdentity;
using Backbone.UnitTestTools.BaseClasses;
using FakeItEasy;
using MediatR;
using Xunit;
using static Backbone.UnitTestTools.Data.TestDataGenerator;

namespace Backbone.Modules.Relationships.Application.Tests.Tests.Identities;

public class IdentityDeleterTests : AbstractTestsBase
{
    [Fact]
    public async Task Deleter_calls_correct_command()
    {
        // Arrange
        var mockMediator = A.Fake<IMediator>();
        var deleter = new IdentityDeleter(mockMediator);
        var identityAddress = CreateRandomIdentityAddress();
        var dummyIDeletionProcessLogger = A.Dummy<IDeletionProcessLogger>();

        // Act
        await deleter.Delete(identityAddress, dummyIDeletionProcessLogger);

        // Assert
        A.CallTo(() => mockMediator.Send(
            A<DeleteRelationshipsOfIdentityCommand>.That.Matches(i => i.IdentityAddress == identityAddress),
            A<CancellationToken>._)).MustHaveHappenedOnceExactly();
        A.CallTo(() => mockMediator.Send(
            A<DeleteRelationshipTemplatesOfIdentityCommand>.That.Matches(i => i.IdentityAddress == identityAddress),
            A<CancellationToken>._)).MustHaveHappenedOnceExactly();
        A.CallTo(() => mockMediator.Send(
            A<AnonymizeRelationshipTemplateAllocationsAllocatedByIdentityCommand>.That.Matches(i => i.IdentityAddress == identityAddress),
            A<CancellationToken>._)).MustHaveHappenedOnceExactly();
    }


    [Fact]
    public async Task Deleter_correctly_creates_audit_log()
    {
        // Arrange
        var dummyMediator = A.Dummy<IMediator>();
        var deleter = new IdentityDeleter(dummyMediator);
        var identityAddress = CreateRandomIdentityAddress();
        var mockIDeletionProcessLogger = A.Fake<IDeletionProcessLogger>();

        // Act
        await deleter.Delete(identityAddress, mockIDeletionProcessLogger);

        // Assert
        A.CallTo(() => mockIDeletionProcessLogger.LogDeletion(identityAddress, "Relationships")).MustHaveHappenedOnceExactly();
        A.CallTo(() => mockIDeletionProcessLogger.LogDeletion(identityAddress, "RelationshipTemplates")).MustHaveHappenedOnceExactly();
        A.CallTo(() => mockIDeletionProcessLogger.LogDeletion(identityAddress, "RelationshipTemplateAllocations")).MustHaveHappenedOnceExactly();
    }
}
