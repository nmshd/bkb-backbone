﻿using Backbone.AdminApi.Sdk.Endpoints.Common;
using Backbone.AdminApi.Sdk.Endpoints.Common.Types;
using Backbone.AdminApi.Sdk.Endpoints.Tiers.Types;
using Backbone.AdminApi.Sdk.Endpoints.Tiers.Types.Requests;
using Backbone.AdminApi.Sdk.Endpoints.Tiers.Types.Responses;

namespace Backbone.AdminApi.Sdk.Endpoints.Tiers;

public class TiersEndpoint(EndpointClient client) : Endpoint(client)
{
    public async Task<AdminApiResponse<ListTiersResponse>> ListTiers() => await _client.Get<ListTiersResponse>("Tiers");

    public async Task<AdminApiResponse<TierDetails>> GetTier(string id) => await _client.Get<TierDetails>($"Tiers/{id}");

    public async Task<AdminApiResponse<Tier>> CreateTier(CreateTierRequest request) => await _client.Post<Tier>("Tiers");

    public async Task<AdminApiResponse<EmptyResponse>> DeleteTier(string id) => await _client.Delete<EmptyResponse>($"Tiers/{id}");

    public async Task<AdminApiResponse<TierQuotaDefinition>> AddTierQuota(string id, CreateQuotaForTierRequest request)
        => await _client.Post<TierQuotaDefinition>($"Tiers/{id}/Quotas", request);

    public async Task<AdminApiResponse<EmptyResponse>> DeleteTierQuota(string id, string quotaId)
        => await _client.Delete<EmptyResponse>($"Tiers/{id}/Quotas/{quotaId}");
}
