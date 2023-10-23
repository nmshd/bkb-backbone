﻿using Backbone.BuildingBlocks.Application.Pagination;
using Backbone.Relationships.Domain.Ids;
using MediatR;

namespace Backbone.Relationships.Application.Relationships.Queries.ListRelationships;

public class ListRelationshipsQuery : IRequest<ListRelationshipsResponse>
{
    public ListRelationshipsQuery(PaginationFilter paginationFilter, IEnumerable<RelationshipId> ids)
    {
        PaginationFilter = paginationFilter;
        Ids = ids == null ? null : new List<RelationshipId>(ids);
    }

    public PaginationFilter PaginationFilter { get; set; }
    public List<RelationshipId> Ids { get; set; }
}
