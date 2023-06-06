﻿namespace Backbone.Modules.Devices.Domain.Entities;
public class OAuthClient
{
    public OAuthClient(string clientId, string displayName)
    {
        ClientId = clientId;
        DisplayName = displayName;
    }
    public string ClientId { get; set; }

    public string DisplayName { get; set; }
}
