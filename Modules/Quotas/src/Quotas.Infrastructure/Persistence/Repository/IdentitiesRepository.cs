﻿using Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Quotas.Domain.Aggregates.Identities;
using Backbone.Modules.Quotas.Infrastructure.Persistence.Database;
using Backbone.Modules.Quotas.Infrastructure.Persistence.Database.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Backbone.Modules.Quotas.Infrastructure.Persistence.Repository;

public class IdentitiesRepository : IIdentitiesRepository
{
    private readonly DbSet<Identity> _identitiesDbSet;
    private readonly QuotasDbContext _dbContext;

    public IdentitiesRepository(QuotasDbContext dbContext)
    {
        _dbContext = dbContext;
        _identitiesDbSet = dbContext.Set<Identity>();
    }

    public async Task Add(Identity identity, CancellationToken cancellationToken)
    {
        await _identitiesDbSet.AddAsync(identity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public IEnumerable<Identity> FindWithTier(string tierId)
    {
        var identities = _identitiesDbSet
            .WithTier(tierId);

        return identities;
    }

    public async Task Update(Identity identity, CancellationToken cancellationToken)
    {
        _identitiesDbSet.Update(identity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(IEnumerable<Identity> identities, CancellationToken cancellationToken)
    {
        _dbContext.UpdateRange(identities);
        await _dbContext.SaveChangesAsync();
    }
}
