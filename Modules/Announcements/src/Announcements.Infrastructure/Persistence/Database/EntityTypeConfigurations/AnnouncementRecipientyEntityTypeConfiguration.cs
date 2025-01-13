﻿using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.EntityTypeConfigurations;
using Backbone.Modules.Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backbone.Modules.Announcements.Infrastructure.Persistence.Database.EntityTypeConfigurations;

public class AnnouncementRecipientEntityTypeConfiguration : EntityEntityTypeConfiguration<AnnouncementRecipient>
{
    public override void Configure(EntityTypeBuilder<AnnouncementRecipient> builder)
    {
        base.Configure(builder);

        builder.HasKey(a => new { a.AnnouncementId, a.DeviceId, a.Address });

        builder.Property(a => a.DeviceId);
        builder.Property(a => a.Address);
        builder.Property(a => a.CreatedAt);
    }
}