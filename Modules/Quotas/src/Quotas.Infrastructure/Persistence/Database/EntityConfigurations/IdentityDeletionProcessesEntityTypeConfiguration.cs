﻿using Backbone.Modules.Quotas.Domain.Aggregates.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backbone.Modules.Quotas.Infrastructure.Persistence.Database.EntityConfigurations;

public class IdentityDeletionProcessesEntityTypeConfiguration : IEntityTypeConfiguration<IdentityDeletionProcesses>
{
    public void Configure(EntityTypeBuilder<IdentityDeletionProcesses> builder)
    {
        builder.ToTable(nameof(IdentityDeletionProcesses), "Devices", x => x.ExcludeFromMigrations());
        builder.HasKey(x => x.Id);
    }
}
