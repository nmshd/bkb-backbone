﻿// <auto-generated />
using System;
using Backbone.Modules.Relationships.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backbone.Modules.Relationships.Infrastructure.Database.Postgres.Migrations
{
    [DbContext(typeof(RelationshipsDbContext))]
    partial class RelationshipsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Relationships")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates.RelationshipTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<byte[]>("Content")
                        .HasColumnType("bytea");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("character varying(80)")
                        .IsFixedLength(false);

                    b.Property<string>("CreatedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<DateTime?>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ForIdentity")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("character varying(80)")
                        .IsFixedLength(false);

                    b.Property<int?>("MaxNumberOfAllocations")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("RelationshipTemplates", "Relationships");
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates.RelationshipTemplateAllocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AllocatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AllocatedBy")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("character varying(80)")
                        .IsFixedLength(false);

                    b.Property<string>("AllocatedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<string>("RelationshipTemplateId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("RelationshipTemplateId", "AllocatedBy");

                    b.ToTable("RelationshipTemplateAllocations", "Relationships");
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.Relationships.Relationship", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("CreationContent")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("CreationResponseContent")
                        .HasColumnType("bytea");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("character varying(80)")
                        .IsFixedLength(false);

                    b.Property<bool>("FromHasDecomposed")
                        .HasColumnType("boolean");

                    b.Property<string>("RelationshipTemplateId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("character varying(80)")
                        .IsFixedLength(false);

                    b.Property<bool>("ToHasDecomposed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("From");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("From"), "hash");

                    b.HasIndex("RelationshipTemplateId");

                    b.HasIndex("To");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("To"), "hash");

                    b.ToTable("Relationships", "Relationships");
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.Relationships.RelationshipAuditLogEntry", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("character varying(80)")
                        .IsFixedLength(false);

                    b.Property<string>("CreatedByDevice")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<int>("NewStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("OldStatus")
                        .HasColumnType("integer");

                    b.Property<int>("Reason")
                        .HasColumnType("integer");

                    b.Property<string>("RelationshipId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("RelationshipId");

                    b.ToTable("RelationshipAuditLog", "Relationships");
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates.RelationshipTemplateAllocation", b =>
                {
                    b.HasOne("Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates.RelationshipTemplate", null)
                        .WithMany("Allocations")
                        .HasForeignKey("RelationshipTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.Relationships.Relationship", b =>
                {
                    b.HasOne("Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates.RelationshipTemplate", "RelationshipTemplate")
                        .WithMany("Relationships")
                        .HasForeignKey("RelationshipTemplateId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("RelationshipTemplate");
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.Relationships.RelationshipAuditLogEntry", b =>
                {
                    b.HasOne("Backbone.Modules.Relationships.Domain.Aggregates.Relationships.Relationship", null)
                        .WithMany("AuditLog")
                        .HasForeignKey("RelationshipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.RelationshipTemplates.RelationshipTemplate", b =>
                {
                    b.Navigation("Allocations");

                    b.Navigation("Relationships");
                });

            modelBuilder.Entity("Backbone.Modules.Relationships.Domain.Aggregates.Relationships.Relationship", b =>
                {
                    b.Navigation("AuditLog");
                });
#pragma warning restore 612, 618
        }
    }
}
