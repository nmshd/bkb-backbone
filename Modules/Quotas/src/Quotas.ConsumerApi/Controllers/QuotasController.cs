﻿using Backbone.Modules.Quotas.Application;
using Backbone.Modules.Quotas.Application.Identities.Queries.GetIndividualQuotas;
using Backbone.Modules.Quotas.Domain.Aggregates.Identities;
using Enmeshed.BuildingBlocks.API;
using Enmeshed.BuildingBlocks.API.Mvc;
using Enmeshed.BuildingBlocks.Application.Abstractions.Exceptions;
using Enmeshed.BuildingBlocks.Application.Pagination;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ApplicationException = Enmeshed.BuildingBlocks.Application.Abstractions.Exceptions.ApplicationException;

namespace Backbone.Modules.Quotas.ConsumerApi.Controllers;

[Route("api/v1/[controller]")]
public class QuotasController : ApiControllerBase
{
    private readonly ApplicationOptions _options;

    public QuotasController(IMediator mediator, IOptions<ApplicationOptions> options) : base(mediator)
    {
        _options = options.Value;
    }

    [HttpGet("Individual/{address}")]
    [ProducesResponseType(typeof(PagedHttpResponseEnvelope<List<IndividualQuota>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListIndividualQuotas([FromQuery] PaginationFilter paginationFilter, [FromRoute] string address, CancellationToken cancellationToken)
    {
        paginationFilter.PageSize ??= _options.Pagination.DefaultPageSize;

        if (paginationFilter.PageSize > _options.Pagination.MaxPageSize)
            throw new ApplicationException(GenericApplicationErrors.Validation.InvalidPageSize(_options.Pagination.MaxPageSize));

        var response = await _mediator.Send(new ListIndividualQuotasQuery(paginationFilter, address), cancellationToken);

        return Paged(response);
    }
}
