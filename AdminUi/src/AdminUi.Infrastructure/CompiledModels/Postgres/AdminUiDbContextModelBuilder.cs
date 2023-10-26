﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace AdminUi.Infrastructure.CompiledModels.Postgres
{
    public partial class AdminUiDbContextModel
    {
        partial void Initialize()
        {
            var clientOverview = ClientOverviewEntityType.Create(this);
            var tierDTO = TierDTOEntityType.Create(this);
            var identityOverview = IdentityOverviewEntityType.Create(this);
            var tierDTO0 = TierDTO0EntityType.Create(this);
            var tierOverview = TierOverviewEntityType.Create(this);

            TierDTOEntityType.CreateForeignKey1(tierDTO, clientOverview);
            TierDTO0EntityType.CreateForeignKey1(tierDTO0, identityOverview);

            ClientOverviewEntityType.CreateAnnotations(clientOverview);
            TierDTOEntityType.CreateAnnotations(tierDTO);
            IdentityOverviewEntityType.CreateAnnotations(identityOverview);
            TierDTO0EntityType.CreateAnnotations(tierDTO0);
            TierOverviewEntityType.CreateAnnotations(tierOverview);

            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "7.0.12");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
        }
    }
}
