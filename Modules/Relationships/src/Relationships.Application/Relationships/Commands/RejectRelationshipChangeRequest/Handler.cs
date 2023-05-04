﻿using AutoMapper;
using Backbone.Modules.Relationships.Application.Extensions;
using Backbone.Modules.Relationships.Application.Infrastructure;
using Backbone.Modules.Relationships.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Relationships.Application.IntegrationEvents;
using Backbone.Modules.Relationships.Domain;
using Backbone.Modules.Relationships.Domain.Entities;
using Backbone.Modules.Relationships.Domain.Errors;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.Persistence.BlobStorage;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.UserContext;
using MediatR;

namespace Backbone.Modules.Relationships.Application.Relationships.Commands.RejectRelationshipChangeRequest;

public class Handler : IRequestHandler<RejectRelationshipChangeRequestCommand, RejectRelationshipChangeRequestResponse>
{
    private readonly IContentStore _contentStore;
    private readonly IRelationshipsDbContext _dbContext;
    private readonly IEventBus _eventBus;
    private readonly IMapper _mapper;
    private readonly IRelationshipsRepository _relationshipsRepository;
    private readonly IUserContext _userContext;

    public Handler(IUserContext userContext, IMapper mapper, IEventBus eventBus, IContentStore contentStore, IRelationshipsRepository relationshipsRepository)
    {
        _userContext = userContext;
        _relationshipsRepository = relationshipsRepository;
        _mapper = mapper;
        _eventBus = eventBus;
        _contentStore = contentStore;
    }

    public async Task<RejectRelationshipChangeRequestResponse> Handle(RejectRelationshipChangeRequestCommand changeRequest, CancellationToken cancellationToken)
    {
        var relationship = await _relationshipsRepository.FindRelationshipPlain(changeRequest.Id, cancellationToken);

        var change = relationship.RejectChange(changeRequest.ChangeId, _userContext.GetAddress(), _userContext.GetDeviceId(), changeRequest.ResponseContent);

        try
        {
            // TODO: Refactor this
            await _contentStore.SaveContentOfChangeResponse(change.Response);
        }
        catch (BlobAlreadyExistsException)
        {
            throw new DomainException(DomainErrors.ChangeRequestIsAlreadyCompleted(change.Status));
        }

        await _relationshipsRepository.Update(relationship);

        PublishIntegrationEvent(change);

        var response = _mapper.Map<RejectRelationshipChangeRequestResponse>(relationship);

        return response;
    }

    private void PublishIntegrationEvent(RelationshipChange change)
    {
        var evt = new RelationshipChangeCompletedIntegrationEvent(change);
        _eventBus.Publish(evt);
    }
}
