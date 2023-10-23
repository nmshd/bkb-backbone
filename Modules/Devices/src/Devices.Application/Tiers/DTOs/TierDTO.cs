﻿namespace Backbone.Devices.Application.Tiers.DTOs;

public class TierDTO
{
    public string Id { get; set; }
    public string Name { get; set; }

    public TierDTO(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
