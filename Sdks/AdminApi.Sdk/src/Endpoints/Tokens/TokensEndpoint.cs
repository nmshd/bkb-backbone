﻿using System.Collections.Specialized;
using Backbone.AdminApi.Sdk.Endpoints.Tokens.Response;
using Backbone.BuildingBlocks.SDK.Endpoints.Common;
using Backbone.BuildingBlocks.SDK.Endpoints.Common.Types;

namespace Backbone.AdminApi.Sdk.Endpoints.Tokens;

public class TokensEndpoint(EndpointClient client) : AdminApiEndpoint(client)
{
    public async Task<ApiResponse<ListTokensTestResponse>> ListTokensByIdentity(PaginationFilter paginationFilter, string createdBy, CancellationToken cancellationToken)
    {
        var queryParameters = new NameValueCollection()
        {
            { "createdBy", createdBy }
        };
        return await _client.Get<ListTokensTestResponse>($"api/{API_VERSION}/Tokens", queryParameters, paginationFilter);
    }
}
