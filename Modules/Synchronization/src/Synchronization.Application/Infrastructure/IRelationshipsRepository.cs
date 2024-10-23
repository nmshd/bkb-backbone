using Backbone.Modules.Synchronization.Domain.Entities.Relationships;

namespace Backbone.Modules.Synchronization.Application.Infrastructure;

public interface IRelationshipsRepository
{
    Task<List<Relationship>> GetRelationships(IEnumerable<RelationshipId> ids, CancellationToken cancellationToken);
}
