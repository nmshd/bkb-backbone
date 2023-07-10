﻿using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications;

namespace Backbone.Modules.Devices.Infrastructure.PushNotifications.DirectPush;
public abstract class PnsConnectorFactory
{
    public IPnsConnector CreateFor(PushNotificationPlatform platform)
    {
        switch (platform)
        {
            case PushNotificationPlatform.Fcm:
                return CreateForFirebaseCloudMessaging();
            case PushNotificationPlatform.Apns:
                break;
        }
        throw new NotImplementedException($"There is currently no {nameof(IPnsConnector)} for the platform '{platform}'.");
    }

    protected abstract IPnsConnector CreateForFirebaseCloudMessaging();
}
