﻿using System.ComponentModel.DataAnnotations;

namespace AdminApi.Tests.Integration.Configuration;

public static class Settings
{
    public class HttpConfiguration
    {
        [Required]
        public string BaseUrl { get; set; } = "";
    }
}
