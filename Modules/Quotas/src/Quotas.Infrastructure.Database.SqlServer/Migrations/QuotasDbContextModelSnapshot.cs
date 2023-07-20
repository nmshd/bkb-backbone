﻿// <auto-generated />
using System;
using Backbone.Modules.Quotas.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Quotas.Infrastructure.Database.SqlServer.Migrations
{
    [DbContext(typeof(QuotasDbContext))]
    partial class QuotasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.FileMetadata.FileMetadata", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("CipherSize")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileMetadata", "Files", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Identities.Identity", b =>
                {
                    b.Property<string>("Address")
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("char(36)")
                        .IsFixedLength();

                    b.Property<string>("TierId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("Address");

                    b.HasIndex("TierId");

                    b.ToTable("Identities");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Identities.MetricStatus", b =>
                {
                    b.Property<string>("Owner")
                        .HasColumnType("char(36)");

                    b.Property<string>("MetricKey")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .IsFixedLength(false);

                    b.Property<DateTime?>("IsExhaustedUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Owner", "MetricKey");

                    b.ToTable("MetricStatuses", (string)null);
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Identities.TierQuota", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<string>("ApplyTo")
                        .HasColumnType("char(36)");

                    b.Property<string>("_definitionId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .HasColumnName("DefinitionId")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("ApplyTo");

                    b.HasIndex("_definitionId");

                    b.ToTable("TierQuotas");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Messages.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages", "Messages", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Tiers.Tier", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)")
                        .IsFixedLength(false);

                    b.HasKey("Id");

                    b.ToTable("Tiers");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Tiers.TierQuotaDefinition", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<string>("MetricKey")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .IsFixedLength(false);

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<string>("TierId")
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("TierId");

                    b.ToTable("TierQuotaDefinitions");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Identities.Identity", b =>
                {
                    b.HasOne("Backbone.Modules.Quotas.Domain.Aggregates.Tiers.Tier", null)
                        .WithMany()
                        .HasForeignKey("TierId");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Identities.MetricStatus", b =>
                {
                    b.HasOne("Backbone.Modules.Quotas.Domain.Aggregates.Identities.Identity", null)
                        .WithMany("MetricStatuses")
                        .HasForeignKey("Owner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Identities.TierQuota", b =>
                {
                    b.HasOne("Backbone.Modules.Quotas.Domain.Aggregates.Identities.Identity", null)
                        .WithMany("TierQuotas")
                        .HasForeignKey("ApplyTo");

                    b.HasOne("Backbone.Modules.Quotas.Domain.Aggregates.Tiers.TierQuotaDefinition", "_definition")
                        .WithMany()
                        .HasForeignKey("_definitionId");

                    b.Navigation("_definition");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Tiers.TierQuotaDefinition", b =>
                {
                    b.HasOne("Backbone.Modules.Quotas.Domain.Aggregates.Tiers.Tier", null)
                        .WithMany("Quotas")
                        .HasForeignKey("TierId");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Identities.Identity", b =>
                {
                    b.Navigation("MetricStatuses");

                    b.Navigation("TierQuotas");
                });

            modelBuilder.Entity("Backbone.Modules.Quotas.Domain.Aggregates.Tiers.Tier", b =>
                {
                    b.Navigation("Quotas");
                });
#pragma warning restore 612, 618
        }
    }
}
