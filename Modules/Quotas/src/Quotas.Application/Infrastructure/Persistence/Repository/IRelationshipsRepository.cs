﻿using Enmeshed.DevelopmentKit.Identity.ValueObjects;

namespace Backbone.Modules.Quotas.Application.Infrastructure.Persistence.Repository;
public interface IRelationshipsRepository
{
    Task<uint> Count(string createdBy, DateTime createdAtFrom, DateTime createdAtTo, CancellationToken cancellationToken);
}
