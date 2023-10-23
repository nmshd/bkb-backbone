﻿using Backbone.BuildingBlocks.Application.Abstractions.Exceptions;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Synchronization.Domain.Entities.Sync;
using Microsoft.EntityFrameworkCore;

namespace Backbone.Synchronization.Application.Extensions;

public static class SyncRunsQueryableExtensions
{
    public static IQueryable<SyncRun> WithId(this IQueryable<SyncRun> query, SyncRunId id)
    {
        return query.Where(d => d.Id == id);
    }

    public static IQueryable<SyncRun> CreatedBy(this IQueryable<SyncRun> query, IdentityAddress createdBy)
    {
        return query.Where(d => d.CreatedBy == createdBy);
    }

    public static IQueryable<SyncRun> NotFinalized(this IQueryable<SyncRun> query)
    {
        return query.Where(d => d.FinalizedAt == null);
    }

    public static async Task<SyncRun> GetFirst(this IQueryable<SyncRun> query, CancellationToken cancellationToken)
    {
        var syncRun = await query.FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(SyncRun));
        return syncRun;
    }
}
