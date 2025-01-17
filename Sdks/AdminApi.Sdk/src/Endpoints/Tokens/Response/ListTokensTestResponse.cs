﻿using Backbone.BuildingBlocks.SDK.Endpoints.Common.Types;
using Backbone.Modules.Tokens.Domain.Entities;

namespace Backbone.AdminApi.Sdk.Endpoints.Tokens.Response;

public class ListTokensTestResponse : List<TokenDTO>
{
    public PaginationData? Pagination { get; set; }
}

public class TokenDTO
{
    public TokenDTO(Token token)
    {
        Id = token.Id;
        CreatedBy = token.CreatedBy;
        CreatedByDevice = token.CreatedByDevice;
        CreatedAt = token.CreatedAt;
        ExpiresAt = token.ExpiresAt;
        Content = token.Content;
        ForIdentity = token.ForIdentity?.Value;
        IsPasswordProtected = token.Password is { Length: > 0 };
    }

    public string Id { get; set; }

    public string CreatedBy { get; set; }
    public string CreatedByDevice { get; set; }

    public string? ForIdentity { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }

    public byte[] Content { get; set; }

    public bool IsPasswordProtected { get; }
}

public class PaginationData
{
    public PaginationData(PaginationFilter previousFilter, int totalRecords)
    {
        TotalRecords = totalRecords;

        var pageSize = previousFilter.PageSize > 0 ? previousFilter.PageSize : totalRecords;
        var totalPages = (double)totalRecords / pageSize;
        var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

        PageNumber = previousFilter.PageNumber;
        PageSize = pageSize;
        TotalPages = roundedTotalPages;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
}
