﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Quotas.Infrastructure.CompiledModels.Postgres
{
    public partial class QuotasDbContextModel
    {
        partial void Initialize()
        {
            var fileMetadata = FileMetadataEntityType.Create(this);
            var identity = IdentityEntityType.Create(this);
            var individualQuota = IndividualQuotaEntityType.Create(this);
            var metricStatus = MetricStatusEntityType.Create(this);
            var tierQuota = TierQuotaEntityType.Create(this);
            var message = MessageEntityType.Create(this);
            var relationship = RelationshipEntityType.Create(this);
            var relationshipTemplate = RelationshipTemplateEntityType.Create(this);
            var tier = TierEntityType.Create(this);
            var tierQuotaDefinition = TierQuotaDefinitionEntityType.Create(this);
            var token = TokenEntityType.Create(this);

            IdentityEntityType.CreateForeignKey1(identity, tier);
            IndividualQuotaEntityType.CreateForeignKey1(individualQuota, identity);
            MetricStatusEntityType.CreateForeignKey1(metricStatus, identity);
            TierQuotaEntityType.CreateForeignKey1(tierQuota, identity);
            TierQuotaEntityType.CreateForeignKey2(tierQuota, tierQuotaDefinition);
            TierQuotaDefinitionEntityType.CreateForeignKey1(tierQuotaDefinition, tier);

            FileMetadataEntityType.CreateAnnotations(fileMetadata);
            IdentityEntityType.CreateAnnotations(identity);
            IndividualQuotaEntityType.CreateAnnotations(individualQuota);
            MetricStatusEntityType.CreateAnnotations(metricStatus);
            TierQuotaEntityType.CreateAnnotations(tierQuota);
            MessageEntityType.CreateAnnotations(message);
            RelationshipEntityType.CreateAnnotations(relationship);
            RelationshipTemplateEntityType.CreateAnnotations(relationshipTemplate);
            TierEntityType.CreateAnnotations(tier);
            TierQuotaDefinitionEntityType.CreateAnnotations(tierQuotaDefinition);
            TokenEntityType.CreateAnnotations(token);

            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "7.0.13");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
        }
    }
}
