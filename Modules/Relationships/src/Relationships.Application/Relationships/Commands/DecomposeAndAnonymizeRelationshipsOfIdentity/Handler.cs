using Backbone.Modules.Relationships.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Relationships.Domain.Aggregates.Relationships;
using MediatR;
using Microsoft.Extensions.Options;

namespace Backbone.Modules.Relationships.Application.Relationships.Commands.DecomposeAndAnonymizeRelationshipsOfIdentity;

public class Handler : IRequestHandler<DecomposeAndAnonymizeRelationshipsOfIdentityCommand>
{
    private readonly IRelationshipsRepository _relationshipsRepository;
    private readonly ApplicationOptions _applicationOptions;

    public Handler(IRelationshipsRepository relationshipsRepository, IOptions<ApplicationOptions> applicationOptions)
    {
        _relationshipsRepository = relationshipsRepository;
        _applicationOptions = applicationOptions.Value;
    }

    public async Task Handle(DecomposeAndAnonymizeRelationshipsOfIdentityCommand request, CancellationToken cancellationToken)
    {
        var relationships = (await _relationshipsRepository.FindRelationships(Relationship.HasParticipant(request.IdentityAddress), cancellationToken)).ToList();

        foreach (var relationship in relationships)
        {
            relationship.DecomposeDueToIdentityDeletion(request.IdentityAddress);
            relationship.AnonymizeParticipant(request.IdentityAddress, _applicationOptions.DidDomainName);
        }

        await _relationshipsRepository.Update(relationships);
    }
}
