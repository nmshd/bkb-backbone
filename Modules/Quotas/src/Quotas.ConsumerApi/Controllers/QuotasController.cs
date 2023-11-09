﻿using Backbone.BuildingBlocks.API;
using Backbone.BuildingBlocks.API.Mvc;
using Backbone.BuildingBlocks.Application.Abstractions.Exceptions;
using Backbone.BuildingBlocks.Application.Pagination;
using Backbone.Modules.Quotas.Application;
using Backbone.Modules.Quotas.Application.DTOs;
using Backbone.Modules.Quotas.Application.Identities.Queries.GetQuotasForIdentity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ApplicationException = Backbone.BuildingBlocks.Application.Abstractions.Exceptions.ApplicationException;

namespace Backbone.Modules.Quotas.ConsumerApi.Controllers;

[Route("api/v1/[controller]")]
public class QuotasController : ApiControllerBase
{
    private readonly ApplicationOptions _options;

    public QuotasController(IMediator mediator, IOptions<ApplicationOptions> options) : base(mediator)
    {
        _options = options.Value;
    }

    [HttpGet("{address}")]
    [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "address" })]
    [ProducesResponseType(typeof(PagedHttpResponseEnvelope<List<QuotaDTO>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListIndividualQuotas([FromQuery] PaginationFilter paginationFilter, [FromRoute] string address, CancellationToken cancellationToken)
    {
        paginationFilter.PageSize ??= _options.Pagination.DefaultPageSize;

        if (paginationFilter.PageSize > _options.Pagination.MaxPageSize)
            throw new ApplicationException(GenericApplicationErrors.Validation.InvalidPageSize(_options.Pagination.MaxPageSize));

        var response = await _mediator.Send(new ListQuotasForIdentityQuery(paginationFilter, address), cancellationToken);

        return Paged(response);
    }
}
