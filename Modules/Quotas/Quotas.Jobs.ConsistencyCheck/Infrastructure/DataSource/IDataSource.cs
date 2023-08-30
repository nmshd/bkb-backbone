﻿namespace Backbone.Modules.Quotas.Jobs.ConsistencyCheck.Infrastructure.DataSource;
public interface IDataSource
{
    Task<IEnumerable<string>> GetIdentitiesMissingFromQuotas(CancellationToken cancellationToken);
    Task<IEnumerable<string>> GetIdentitiesMissingFromDevices(CancellationToken cancellationToken);
    Task<IEnumerable<string>> GetTiersMissingFromQuotas(CancellationToken cancellationToken);
    Task<IEnumerable<string>> GetTiersMissingFromDevices(CancellationToken cancellationToken);
}
