﻿using System.ComponentModel.DataAnnotations;
using Backbone.Devices.Infrastructure.PushNotifications.DirectPush;
using Backbone.Devices.Infrastructure.PushNotifications.Dummy;
using Microsoft.Extensions.DependencyInjection;
using DirectPnsCommunicationOptions = Backbone.Devices.Infrastructure.PushNotifications.DirectPush.DirectPnsCommunicationOptions;

namespace Backbone.Devices.Infrastructure.PushNotifications;

public static class IServiceCollectionExtensions
{
    public const string PROVIDER_DIRECT = "Direct";
    public const string PROVIDER_DUMMY = "Dummy";

    public static void AddPushNotifications(this IServiceCollection services, PushNotificationOptions options)
    {
        switch (options.Provider)
        {
            case PROVIDER_DUMMY:
                services.AddDummyPushNotifications();
                break;
            case PROVIDER_DIRECT:
                services.AddDirectPushNotifications(options.DirectPnsCommunication);
                break;
            default:
                throw new Exception($"Push Notification Provider {options.Provider} does not exist.");
        }
    }
}

public class PushNotificationOptions
{
    [Required]
    [RegularExpression(
        $"{IServiceCollectionExtensions.PROVIDER_DIRECT}|{IServiceCollectionExtensions.PROVIDER_DUMMY}")]
    public string Provider { get; set; }

#nullable enable
    public DirectPnsCommunicationOptions? DirectPnsCommunication { get; set; }
}
