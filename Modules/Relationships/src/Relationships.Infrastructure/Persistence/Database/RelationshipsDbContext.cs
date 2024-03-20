using Backbone.BuildingBlocks.Infrastructure.Persistence.Database;
using Backbone.Modules.Relationships.Domain.Aggregates.Relationships;
using Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates;
using Backbone.Modules.Relationships.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace Backbone.Modules.Relationships.Infrastructure.Persistence.Database;

public class RelationshipsDbContext : AbstractDbContextBase
{
    public RelationshipsDbContext()
    {
    }

    public RelationshipsDbContext(DbContextOptions<RelationshipsDbContext> options) : base(options)
    {
    }

    public RelationshipsDbContext(DbContextOptions<RelationshipsDbContext> options, IServiceProvider serviceProvider) : base(options, serviceProvider)
    {
    }

    public DbSet<Relationship> Relationships { get; set; } = null!;
    public DbSet<RelationshipTemplate> RelationshipTemplates { get; set; } = null!;

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    //     optionsBuilder.UseSqlServer();
    // }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<RelationshipId>().AreUnicode(false).AreFixedLength().HaveMaxLength(RelationshipId.MAX_LENGTH).HaveConversion<RelationshipIdEntityFrameworkValueConverter>();
        configurationBuilder.Properties<RelationshipTemplateId>().AreUnicode(false).AreFixedLength().HaveMaxLength(RelationshipTemplateId.MAX_LENGTH)
            .HaveConversion<RelationshipTemplateIdEntityFrameworkValueConverter>();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(RelationshipsDbContext).Assembly);
    }
}
