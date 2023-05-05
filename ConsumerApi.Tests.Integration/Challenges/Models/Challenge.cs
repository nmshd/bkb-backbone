﻿using System.ComponentModel.DataAnnotations;

namespace ConsumerApi.Tests.Integration.Models;

public class Challenge
{
    [Required]
    public string Id { get; set; }
    [Required]
    public DateTime ExpiresAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? CreatedByDevice { get; set; }
}
