using System;
using System.Text.Json;
using Backbone.Modules.Devices.Infrastructure.PushNotifications;
using Backbone.Modules.Devices.Infrastructure.PushNotifications.DirectPush.FirebaseCloudMessaging;
using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using Enmeshed.Tooling;
using FluentAssertions;
using Xunit;

namespace Backbone.Modules.Devices.Infrastructure.Tests.Tests.DirectPush;

public class FcmMessageBuilderTests
{
    [Fact]
    public void Built_message_has_all_properties_set()
    {
        // Act
        var message = new FcmMessageBuilder()
            .SetTag(1)
            .SetTokens(new[] { "token1", "token2" })
            .SetNotificationText("someNotificationTextTitle", "someNotificationTextBody")
            .AddContent(new NotificationContent(IdentityAddress.Parse("id1KJnD8ipfckRQ1ivAhNVLtypmcVM5vPX4j"), new { SomeProperty = "someValue" }))
            .Build();

        // Assert
        message.Notification.Title.Should().Be("someNotificationTextTitle");
        message.Notification.Body.Should().Be("someNotificationTextBody");

        message.Tokens.Should().HaveCount(2);
        message.Tokens.Should().Contain("token1");
        message.Tokens.Should().Contain("token2");

        message.Android.Notification.ChannelId.Should().Be("ENMESHED");
        message.Data.Should().Contain("android_channel_id", "ENMESHED");

        message.Data["content-available"].Should().Be("1");

        message.Android.CollapseKey.Should().Be("1");
        message.Data.Should().Contain("tag", "1");
    }

    [Fact]
    public void Content_is_valid_json()
    {
        // Arrange
        SystemTime.Set(DateTime.Parse("2021-01-01T00:00:00.000Z"));

        // Act
        var message = new FcmMessageBuilder()
            .AddContent(new NotificationContent(IdentityAddress.Parse("id1KJnD8ipfckRQ1ivAhNVLtypmcVM5vPX4j"), new { SomeProperty = "someValue" }))
            .Build();
        var contentJson = FormatJson(message.Data["content"]);

        // Assert
        contentJson.Should().Be(FormatJson(@"{
          'accRef': 'id1KJnD8ipfckRQ1ivAhNVLtypmcVM5vPX4j',
          'eventName': 'dynamic',
          'sentAt': '2021-01-01T00:00:00Z',
          'payload': {
            'SomeProperty': 'someValue'
          }
        }"));
    }

    private static string FormatJson(string jsonString)
    {
        jsonString = jsonString.Replace("'", "\"");

        var deserialized = JsonSerializer.Deserialize<JsonElement>(jsonString);

        return JsonSerializer.Serialize(deserialized, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
    }
}
