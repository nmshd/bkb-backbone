﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.Persistence.BlobStorage;
using Backbone.Synchronization.Application.Infrastructure;
using Backbone.Synchronization.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backbone.Synchronization.Jobs.SanityCheck.Infrastructure.DataSource;

public class DataSource : IDataSource
{
    private readonly IBlobStorage _blobStorage;
    private readonly BlobOptions _blobOptions;
    private readonly ISynchronizationDbContext _dbContext;

    public DataSource(IBlobStorage blobStorage, IOptions<BlobOptions> blobOptions, ISynchronizationDbContext dbContext)
    {
        _blobStorage = blobStorage;
        _blobOptions = blobOptions.Value;
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<string>> GetBlobIdsAsync(CancellationToken cancellationToken)
    {
        var blobIds = await _blobStorage.FindAllAsync(_blobOptions.RootFolder);
        return await blobIds.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<DatawalletModificationId>> GetDatabaseIdsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SetReadOnly<DatawalletModification>().Select(u => u.Id).ToListAsync(cancellationToken);
    }
}
