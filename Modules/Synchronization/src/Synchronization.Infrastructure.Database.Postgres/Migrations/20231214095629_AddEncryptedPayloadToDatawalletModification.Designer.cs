﻿// <auto-generated />
using System;
using Backbone.Modules.Synchronization.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backbone.Modules.Synchronization.Infrastructure.Database.Postgres.Migrations
{
    [DbContext(typeof(SynchronizationDbContext))]
    [Migration("20231214095629_AddEncryptedPayloadToDatawalletModification")]
    partial class AddEncryptedPayloadToDatawalletModification
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Datawallet", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("character(36)")
                        .IsFixedLength();

                    b.Property<ushort>("Version")
                        .IsUnicode(false)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Owner")
                        .IsUnique();

                    b.ToTable("Datawallets");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.DatawalletModification", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<string>("BlobReference")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("character(32)")
                        .IsFixedLength();

                    b.Property<string>("Collection")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("character(36)")
                        .IsFixedLength();

                    b.Property<string>("CreatedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<string>("DatawalletId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<ushort>("DatawalletVersion")
                        .IsUnicode(false)
                        .HasColumnType("integer");

                    b.Property<byte[]>("EncryptedPayload")
                        .HasColumnType("bytea");

                    b.Property<long>("Index")
                        .HasColumnType("bigint");

                    b.Property<string>("ObjectIdentifier")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PayloadCategory")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DatawalletId");

                    b.HasIndex("CreatedBy", "Index")
                        .IsUnique();

                    b.ToTable("DatawalletModifications");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Sync.ExternalEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Index")
                        .HasColumnType("bigint");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("character(36)")
                        .IsFixedLength();

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<byte>("SyncErrorCount")
                        .HasColumnType("smallint");

                    b.Property<string>("SyncRunId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<int>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SyncRunId");

                    b.HasIndex("Owner", "Index")
                        .IsUnique();

                    b.HasIndex("Owner", "SyncRunId");

                    b.ToTable("ExternalEvents");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncError", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<string>("ErrorCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ExternalEventId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<string>("SyncRunId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("ExternalEventId");

                    b.HasIndex("SyncRunId", "ExternalEventId")
                        .IsUnique();

                    b.ToTable("SyncErrors");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncRun", b =>
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
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("character(36)")
                        .IsFixedLength();

                    b.Property<string>("CreatedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<int>("EventCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FinalizedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Index")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("CreatedBy", "FinalizedAt");

                    b.HasIndex("CreatedBy", "Index")
                        .IsUnique();

                    b.ToTable("SyncRuns");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.DatawalletModification", b =>
                {
                    b.HasOne("Backbone.Modules.Synchronization.Domain.Entities.Datawallet", "Datawallet")
                        .WithMany("Modifications")
                        .HasForeignKey("DatawalletId");

                    b.Navigation("Datawallet");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Sync.ExternalEvent", b =>
                {
                    b.HasOne("Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncRun", "SyncRun")
                        .WithMany("ExternalEvents")
                        .HasForeignKey("SyncRunId");

                    b.Navigation("SyncRun");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncError", b =>
                {
                    b.HasOne("Backbone.Modules.Synchronization.Domain.Entities.Sync.ExternalEvent", null)
                        .WithMany("Errors")
                        .HasForeignKey("ExternalEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncRun", null)
                        .WithMany("Errors")
                        .HasForeignKey("SyncRunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Datawallet", b =>
                {
                    b.Navigation("Modifications");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Sync.ExternalEvent", b =>
                {
                    b.Navigation("Errors");
                });

            modelBuilder.Entity("Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncRun", b =>
                {
                    b.Navigation("Errors");

                    b.Navigation("ExternalEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
