﻿namespace Backbone.AdminApi.Tests.Integration.Models;

public class CreateClientRequest
{
    public required string ClientId { get; set; }
    public required string DisplayName { get; set; }
    public required string ClientSecret { get; set; }
    public required string DefaultTier { get; set; }
    public int? MaxIdentities { get; set; }
}
