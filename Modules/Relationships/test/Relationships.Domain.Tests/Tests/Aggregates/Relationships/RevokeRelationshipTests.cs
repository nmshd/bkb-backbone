﻿using Backbone.BuildingBlocks.Domain;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Relationships.Domain.Aggregates.Relationships;
using Backbone.Modules.Relationships.Domain.DomainEvents.Outgoing;
using Backbone.Modules.Relationships.Domain.Tests.Extensions;
using Backbone.Tooling;
using Backbone.UnitTestTools.BaseClasses;
using Backbone.UnitTestTools.FluentAssertions.Extensions;
using FluentAssertions;
using Xunit;
using static Backbone.Modules.Relationships.Domain.Tests.TestHelpers.TestData;

namespace Backbone.Modules.Relationships.Domain.Tests.Tests.Aggregates.Relationships;

public class RevokeRelationshipTests : AbstractTestsBase
{
    [Fact]
    public void Revoke_creation_transitions_relationship_to_status_revoked()
    {
        // Arrange
        var relationship = CreatePendingRelationship();

        // Act
        relationship.Revoke(IDENTITY_1, DEVICE_1, null);

        // Assert
        relationship.Status.Should().Be(RelationshipStatus.Revoked);
    }

    [Fact]
    public void Revoking_creation_creates_an_audit_log_entry()
    {
        // Arrange
        SystemTime.Set("2000-01-01");

        var relationship = CreatePendingRelationship();

        // Act
        relationship.Revoke(IDENTITY_1, DEVICE_1, null);

        // Assert
        relationship.AuditLog.Should().HaveCount(2);

        var auditLogEntry = relationship.AuditLog.OrderBy(a => a.CreatedAt).Last();

        auditLogEntry.Id.Should().NotBeNull();
        auditLogEntry.Reason.Should().Be(RelationshipAuditLogEntryReason.RevocationOfCreation);
        auditLogEntry.OldStatus.Should().Be(RelationshipStatus.Pending);
        auditLogEntry.NewStatus.Should().Be(RelationshipStatus.Revoked);
        auditLogEntry.CreatedBy.Should().Be(IDENTITY_1);
        auditLogEntry.CreatedByDevice.Should().Be(DEVICE_1);
        auditLogEntry.CreatedAt.Should().Be(DateTime.Parse("2000-01-01"));
    }

    [Fact]
    public void Raises_RelationshipStatusChangedDomainEvent()
    {
        // Arrange
        var relationship = CreatePendingRelationship();

        // Act
        relationship.Revoke(IDENTITY_1, DEVICE_1, null);

        // Assert
        var domainEvent = relationship.Should().HaveASingleDomainEvent<RelationshipStatusChangedDomainEvent>();
        domainEvent.RelationshipId.Should().Be(relationship.Id);
        domainEvent.Status.Should().Be(relationship.Status.ToString());
        domainEvent.Initiator.Should().Be(relationship.LastModifiedBy);
        domainEvent.Peer.Should().Be(relationship.GetPeer(relationship.LastModifiedBy));
    }

    [Fact]
    public void Can_only_revoke_creation_when_relationship_is_in_status_pending()
    {
        // Arrange
        var relationship = CreateActiveRelationship();

        // Act
        var acting = () => relationship.Revoke(IDENTITY_2, DEVICE_2, null);

        // Assert
        acting.Should().Throw<DomainException>().WithError(
            "error.platform.validation.relationshipRequest.relationshipIsNotInCorrectStatus",
            nameof(RelationshipStatus.Pending)
        );
    }

    [Fact]
    public void Cannot_revoke_own_relationship_request()
    {
        // Arrange
        var relationship = CreatePendingRelationship();

        // Act
        var acting = () => relationship.Revoke(IDENTITY_2, DEVICE_2, null);

        // Assert
        acting.Should().Throw<DomainException>().WithError("error.platform.validation.relationshipRequest.cannotRevokeRelationshipRequestNotCreatedByYourself");
    }

    [Fact]
    public void Cannot_revoke_foreign_relationship_request()
    {
        // Arrange
        var relationship = CreatePendingRelationship();
        var foreignAddress = IdentityAddress.ParseUnsafe("some-other-identity");

        // Act
        var acting = () => relationship.Revoke(foreignAddress, DeviceId.New(), null);

        // Assert
        acting.Should().Throw<DomainException>().WithError("error.platform.validation.relationshipRequest.cannotRevokeRelationshipRequestNotCreatedByYourself");
    }
}
