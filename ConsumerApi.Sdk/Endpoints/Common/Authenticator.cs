﻿using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backbone.ConsumerApi.Sdk.Endpoints.Common;

public class Authenticator
{
    private readonly Configuration.AuthenticationConfiguration _config;
    private readonly HttpClient _httpClient;
    private string? _jwt;
    private DateTime? _expiresAt;

    public Authenticator(Configuration.AuthenticationConfiguration config, HttpClient httpClient)
    {
        _config = config;
        _httpClient = httpClient;
    }

    public async Task<string> GetJwt()
    {
        if (_jwt == null || _expiresAt < DateTime.Now + TimeSpan.FromSeconds(30))
        {
            await RefreshToken();
        }

        return _jwt;
    }

    [MemberNotNull(nameof(_jwt))]
    private async Task RefreshToken()
    {
        var form = new Dictionary<string, string>()
        {
            { "grant_type", "password" },
            { "username", _config.Username },
            { "password", _config.Password },
            { "client_id", _config.ClientId },
            { "client_secret", _config.ClientSecret }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "/connect/token") { Content = new FormUrlEncodedContent(form) };
        var httpResponse = await _httpClient.SendAsync(request);

        var responseRawContent = await httpResponse.Content.ReadAsStringAsync();
        var accessTokenResponse = JsonSerializer.Deserialize<AccessTokenResponse>(responseRawContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

        _expiresAt = accessTokenResponse.ExpiresAt;
        _jwt = accessTokenResponse.AccessToken;
    }

    private class AccessTokenResponse
    {
        public AccessTokenResponse(
            string accessToken,
            string tokenType,
            int expiresIn)
        {
            AccessToken = accessToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            ExpiresAt = DateTime.UtcNow.AddSeconds(expiresIn);
        }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        public DateTime ExpiresAt { get; }
        public bool IsExpired => (ExpiresAt - DateTime.UtcNow).TotalSeconds <= 15;
    }
}
