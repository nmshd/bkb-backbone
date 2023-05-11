﻿using AutoMapper;
using Backbone.Modules.Relationships.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Relationships.Application.Relationships.DTOs;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.UserContext;
using MediatR;

namespace Backbone.Modules.Relationships.Application.Relationships.Queries.ListChanges;

public class Handler : IRequestHandler<ListChangesQuery, ListChangesResponse>
{
    private readonly IMapper _mapper;
    private readonly IRelationshipsRepository _relationshipsRepository;
    private readonly IUserContext _userContext;

    public Handler(IUserContext userContext, IMapper mapper, IRelationshipsRepository relationshipsRepository)
    {
        _mapper = mapper;
        _relationshipsRepository = relationshipsRepository;
        _userContext = userContext;
    }

    public async Task<ListChangesResponse> Handle(ListChangesQuery request, CancellationToken cancellationToken)
    {
        var dbPaginationResult = await _relationshipsRepository.FindChangesWithIds(request.Ids, request.Type, request.Status, request.ModifiedAt, request.CreatedAt, request.CompletedAt, request.CreatedBy, request.CompletedBy, _userContext.GetAddress(), request.PaginationFilter, track: false);

        return new ListChangesResponse(_mapper.Map<RelationshipChangeDTO[]>(dbPaginationResult.ItemsOnPage), request.PaginationFilter, dbPaginationResult.TotalNumberOfItems);
    }
}
