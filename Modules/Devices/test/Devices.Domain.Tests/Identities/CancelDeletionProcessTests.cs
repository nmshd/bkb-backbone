﻿using Backbone.BuildingBlocks.Domain;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using Backbone.Tooling;
using FluentAssertions;
using Xunit;

namespace Backbone.Modules.Devices.Domain.Tests.Identities;
public class CancelDeletionProcessTests
{
    [Fact]
    public void Cancel_deletion_process()
    {
        // Arrange
        var currentDate = DateTime.Parse("2020-01-01");
        SystemTime.Set(currentDate);

        var identity = TestDataGenerator.CreateIdentity();
        var device = new Device(identity);
        identity.Devices.Add(device);

        var deletionProcess = identity.StartDeletionProcessAsOwner(device.Id);
        SystemTime.Set(DateTime.Parse("2020-01-02"));

        // Act
        identity.CancelDeletionProcess(deletionProcess.Id, device.Id);

        // Assert
        deletionProcess.Status.Should().Be(DeletionProcessStatus.Cancelled);
    }

    [Fact]
    public void Throws_when_deletion_process_does_not_exist()
    {
        // Arrange
        var identity = TestDataGenerator.CreateIdentity();
        identity.Devices.Add(new Device(identity));
        var deviceId = identity.Devices[0].Id;
        var deletionProcessId = IdentityDeletionProcessId.Create("IDP00000000000000001").Value;

        // Act
        var acting = () => identity.CancelDeletionProcess(deletionProcessId, deviceId);

        // Assert
        acting.Should().Throw<DomainException>().Which.Message.Should().Contain("IdentityDeletionProcess");
    }
}
