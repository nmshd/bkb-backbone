using Backbone.Modules.Relationships.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Relationships.Domain.Entities;
using MediatR;

namespace Backbone.Modules.Relationships.Application.Relationships.Commands.DeleteRelationshipsOfIdentity;

public class Handler : IRequestHandler<DeleteRelationshipsOfIdentityCommand>
{
    private readonly IRelationshipsRepository _relationshipsRepository;

    public Handler(IRelationshipsRepository relationshipsRepository)
    {
        _relationshipsRepository = relationshipsRepository;
    }

    public async Task Handle(DeleteRelationshipsOfIdentityCommand request, CancellationToken cancellationToken)
    {
        await _relationshipsRepository.Delete(Relationship.HasParticipant(request.IdentityAddress), cancellationToken);
    }
}
