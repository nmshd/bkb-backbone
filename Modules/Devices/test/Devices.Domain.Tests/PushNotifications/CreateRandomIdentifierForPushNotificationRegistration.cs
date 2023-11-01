﻿using Backbone.Modules.Devices.Application.Tests.Tests.PushNotifications;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications.Handles;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications.Hashing;
using FluentAssertions;
using Xunit;
using Environment = Backbone.Modules.Devices.Domain.Aggregates.PushNotifications.Environment;
using static Backbone.UnitTestTools.Data.TestDataGenerator;

namespace Backbone.Modules.Devices.Domain.Tests.PushNotifications;

public class CreateRandomIdentifierForPushNotificationRegistration
{
    [Fact]
    public void Generate_random_identifier()
    {
        // Arrange

        // Act
        var randomDevicePushIdentifier = DevicePushIdentifier.New();

        // Assert
        randomDevicePushIdentifier.Should().
    }

    [Fact]
    public void Generate_random_identifier_while_instancing_PnsRegistration_class()
    {
        // Arrange
        var randomIdentityAddress = CreateRandomIdentityAddress();
        var randomDeviceId = CreateRandomDeviceId();
        var pnsHandle = PnsHandle.Parse("value", PushNotificationPlatform.Fcm).Value;

        // var identifierTestValue = DevicePushIdentifier.Create(randomDeviceId);
        var identifierTestValue = randomDeviceId + "-" + DevicePushIdentifierSuffixGenerator.GenerateSuffixUtf8();

        // Act
        var pnsRegistration = new PnsRegistration(randomIdentityAddress, randomDeviceId, pnsHandle, "appId", Environment.Development);

        // Assert
        pnsRegistration.IdentityAddress.Should().BeEquivalentTo(randomIdentityAddress);
        pnsRegistration.DeviceId.Should().BeEquivalentTo(randomDeviceId);
        pnsRegistration.DevicePushIdentifier.Value.Should().BeEquivalentTo(identifierTestValue);
        pnsRegistration.Handle.Should().BeEquivalentTo(pnsHandle);
        pnsRegistration.AppId.Should().BeEquivalentTo("appId");
        pnsRegistration.Environment.Should().Be(Environment.Development);
    }
}
