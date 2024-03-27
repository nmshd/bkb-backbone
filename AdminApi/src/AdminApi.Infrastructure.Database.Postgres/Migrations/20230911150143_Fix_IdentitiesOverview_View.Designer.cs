// <auto-generated />
using System;
using Backbone.AdminApi.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdminUi.Infrastructure.Database.Postgres.Migrations
{
    [DbContext(typeof(AdminApiDbContext))]
    [Migration("20230911150143_Fix_IdentitiesOverview_View")]
    partial class Fix_IdentitiesOverview_View
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdminUi.Infrastructure.DTOs.IdentityOverview", b =>
                {
                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedWithClient")
                        .HasColumnType("text");

                    b.Property<int?>("DatawalletVersion")
                        .HasColumnType("integer");

                    b.Property<byte>("IdentityVersion")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("LastLoginAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("NumberOfDevices")
                        .HasColumnType("integer");

                    b.Property<string>("TierId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TierName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable((string)null);

                    b.ToView("IdentityOverviews", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
