﻿using Backbone.BuildingBlocks.Application.Attributes;
using MediatR;

namespace Backbone.Modules.Relationships.Application.Relationships.Commands.RelationshipReactivationRequest;

[ApplyQuotasForMetrics("NumberOfRelationships")]
public class RequestRelationshipReactivationCommand : IRequest<RequestRelationshipReactivationResponse>
{
    public required string RelationshipId { get; set; }
}
