using Backbone.AdminApi.Infrastructure.DTOs;
using Backbone.AdminApi.Infrastructure.Persistence.Database;
using Backbone.BuildingBlocks.API;
using Backbone.BuildingBlocks.API.Mvc;
using Backbone.BuildingBlocks.API.Mvc.ControllerAttributes;
using Backbone.BuildingBlocks.Application.Abstractions.Exceptions;
using Backbone.Modules.Devices.Application.Clients.Commands.ChangeClientSecret;
using Backbone.Modules.Devices.Application.Clients.Commands.CreateClient;
using Backbone.Modules.Devices.Application.Clients.Commands.DeleteClient;
using Backbone.Modules.Devices.Application.Clients.Commands.UpdateClient;
using Backbone.Modules.Devices.Application.Clients.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backbone.AdminApi.Controllers;

[Route("api/v1/[controller]")]
[Authorize("ApiKey")]
public class ClientsController : ApiControllerBase
{
    private readonly AdminApiDbContext _adminApiDbContext;

    public ClientsController(IMediator mediator, AdminApiDbContext adminApiDbContext) : base(mediator)
    {
        _adminApiDbContext = adminApiDbContext;
    }

    [HttpGet]
    [ProducesResponseType(typeof(HttpResponseEnvelopeResult<ClientOverview>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllClients(CancellationToken cancellationToken)
    {
        var clientOverviews = await _adminApiDbContext.ClientOverviews.ToListAsync(cancellationToken);
        return Ok(clientOverviews);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ClientDTO), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClient([FromRoute] string id, CancellationToken cancellationToken)
    {
        var client = await _adminApiDbContext.ClientOverviews.FirstOrDefaultAsync(c => c.ClientId == id, cancellationToken: cancellationToken) ?? throw new NotFoundException(nameof(ClientOverview));
        return Ok(new ClientDTO(client.ClientId, client.DisplayName, client.DefaultTier.Id, client.CreatedAt, client.NumberOfIdentities, client.MaxIdentities));
    }

    [HttpPost]
    [ProducesResponseType(typeof(HttpResponseEnvelopeResult<CreateClientResponse>), StatusCodes.Status200OK)]
    public async Task<CreatedResult> CreateOAuthClients(CreateClientCommand command, CancellationToken cancellationToken)
    {
        var createdClient = await _mediator.Send(command, cancellationToken);
        return Created(createdClient);
    }

    [HttpPatch("{clientId}/ChangeSecret")]
    [ProducesResponseType(typeof(HttpResponseEnvelopeResult<ChangeClientSecretResponse>), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeClientSecret([FromRoute] string clientId, [FromBody] ChangeClientSecretRequest request, CancellationToken cancellationToken)
    {
        var changedClient = await _mediator.Send(new ChangeClientSecretCommand(clientId, request.NewSecret), cancellationToken);
        return Ok(changedClient);
    }

    [HttpPut("{clientId}")]
    [ProducesResponseType(typeof(HttpResponseEnvelopeResult<UpdateClientResponse>), StatusCodes.Status200OK)]
    [ProducesError(StatusCodes.Status404NotFound)]
    [ProducesError(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateClient([FromRoute] string clientId, [FromBody] UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var updatedClient = await _mediator.Send(new UpdateClientCommand(clientId, request.DefaultTier, request.MaxIdentities), cancellationToken);
        return Ok(updatedClient);
    }

    [HttpDelete("{clientId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteClient([FromRoute] string clientId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteClientCommand(clientId), cancellationToken);
        return NoContent();
    }
}

public class ChangeClientSecretRequest
{
    public required string NewSecret { get; set; }
}

public class UpdateClientRequest
{
    public required string DefaultTier { get; set; }
    public int? MaxIdentities { get; set; }
}
