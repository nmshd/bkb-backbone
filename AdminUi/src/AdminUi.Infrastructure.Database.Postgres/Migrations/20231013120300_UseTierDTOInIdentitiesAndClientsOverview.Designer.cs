﻿// <auto-generated />
using System;
using Backbone.AdminUi.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdminUi.Infrastructure.Database.Postgres.Migrations
{
    [DbContext(typeof(AdminUiDbContext))]
    [Migration("20231013120300_UseTierDTOInIdentitiesAndClientsOverview")]
    partial class UseTierDTOInIdentitiesAndClientsOverview
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdminUi.Infrastructure.DTOs.ClientOverview", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfIdentities")
                        .HasColumnType("integer");

                    b.HasKey("ClientId");

                    b.ToTable((string)null);

                    b.ToView("ClientOverviews", (string)null);
                });

            modelBuilder.Entity("AdminUi.Infrastructure.DTOs.IdentityOverview", b =>
                {
                    b.Property<string>("Address")
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

                    b.HasKey("Address");

                    b.ToTable((string)null);

                    b.ToView("IdentityOverviews", (string)null);
                });

            modelBuilder.Entity("AdminUi.Infrastructure.DTOs.TierOverview", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfIdentities")
                        .HasColumnType("integer");

                    b.ToTable((string)null);

                    b.ToView("TierOverviews", (string)null);
                });

            modelBuilder.Entity("AdminUi.Infrastructure.DTOs.ClientOverview", b =>
                {
                    b.OwnsOne("AdminUi.Infrastructure.DTOs.TierDTO", "DefaultTier", b1 =>
                        {
                            b1.Property<string>("ClientOverviewClientId")
                                .HasColumnType("text");

                            b1.Property<string>("Id")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("DefaultTierId");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("DefaultTierName");

                            b1.HasKey("ClientOverviewClientId");

                            b1.ToTable((string)null);

                            b1.ToView("ClientOverviews");

                            b1.WithOwner()
                                .HasForeignKey("ClientOverviewClientId");
                        });

                    b.Navigation("DefaultTier")
                        .IsRequired();
                });

            modelBuilder.Entity("AdminUi.Infrastructure.DTOs.IdentityOverview", b =>
                {
                    b.OwnsOne("AdminUi.Infrastructure.DTOs.TierDTO", "Tier", b1 =>
                        {
                            b1.Property<string>("IdentityOverviewAddress")
                                .HasColumnType("text");

                            b1.Property<string>("Id")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TierId");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TierName");

                            b1.HasKey("IdentityOverviewAddress");

                            b1.ToTable((string)null);

                            b1.ToView("IdentityOverviews");

                            b1.WithOwner()
                                .HasForeignKey("IdentityOverviewAddress");
                        });

                    b.Navigation("Tier")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
