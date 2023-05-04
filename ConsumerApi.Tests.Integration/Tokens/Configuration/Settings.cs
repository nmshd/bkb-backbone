﻿using System.ComponentModel.DataAnnotations;

namespace ConsumerApi.Tests.Integration.Tokens.Configuration;

public static class Settings
{
    public class HttpConfiguration
    {
        [Required]
        public string BaseUrl { get; set; } = "";
        [Required]
        public ClientCredentialsConfiguration ClientCredentials { get; set; } = new();
    }

    public class ClientCredentialsConfiguration
    {
        [Required]
        public string ClientId { get; set; } = "";
        [Required]
        public string ClientSecret { get; set; } = "";
    }
}
