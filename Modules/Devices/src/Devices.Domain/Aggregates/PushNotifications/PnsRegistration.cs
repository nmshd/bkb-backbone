﻿using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Devices.Domain.Aggregates.PushNotifications.Handles;
using Backbone.Tooling;

namespace Backbone.Devices.Domain.Aggregates.PushNotifications;

public class PnsRegistration
{
    private PnsRegistration() { }

    public PnsRegistration(IdentityAddress identityAddress, DeviceId deviceId, PnsHandle handle, string appId)
    {
        IdentityAddress = identityAddress;
        DeviceId = deviceId;
        Handle = handle;
        UpdatedAt = SystemTime.UtcNow;
        AppId = appId;
    }

    public IdentityAddress IdentityAddress { get; }
    public DeviceId DeviceId { get; }
    public PnsHandle Handle { get; private set; }
    public string AppId { get; set; }
    public DateTime UpdatedAt { get; private set; }

    public void Update(PnsHandle newHandle, string appId)
    {
        AppId = appId;
        Handle = newHandle;
        UpdatedAt = SystemTime.UtcNow;
    }
}
