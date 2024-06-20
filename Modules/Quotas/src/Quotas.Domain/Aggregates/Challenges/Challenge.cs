﻿namespace Backbone.Modules.Quotas.Domain.Aggregates.Challenges;

public class Challenge
{
    public const int EXPIRY_TIME_IN_MINUTES = 10;

    public required string Id { get; set; }
    public required DateTime ExpiresAt { get; set; }
    public required string? CreatedBy { get; set; }
}
