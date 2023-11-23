﻿namespace Backbone.AdminUi.Tests.Integration.Models;
public class ClientOverviewDTO
{
    public string ClientId { get; set; }
    public string DisplayName { get; set; }
    public TierDTO DefaultTier { get; set; }
    public int? NumberOfIdentities { get; set; }
}
