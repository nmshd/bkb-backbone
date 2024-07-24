﻿// <auto-generated />
using System;
using Backbone.Modules.Messages.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backbone.Modules.Messages.Infrastructure.Database.SqlServer.Migrations
{
    [DbContext(typeof(MessagesDbContext))]
    [Migration("20240710125427_AddIsRelationshipDecomposedByRecipientAndIsRelationshipDecomposedBySenderProperties")]
    partial class AddIsRelationshipDecomposedByRecipientAndIsRelationshipDecomposedBySenderProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Messages")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backbone.Modules.Messages.Domain.Entities.Attachment", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<string>("MessageId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("Id", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("Attachments", "Messages");
                });

            modelBuilder.Entity("Backbone.Modules.Messages.Domain.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<byte[]>("Body")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .IsFixedLength(false);

                    b.Property<string>("CreatedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Messages", "Messages");
                });

            modelBuilder.Entity("Backbone.Modules.Messages.Domain.Entities.RecipientInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .IsFixedLength(false);

                    b.Property<byte[]>("EncryptedKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsRelationshipDecomposedByRecipient")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRelationshipDecomposedBySender")
                        .HasColumnType("bit");

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceivedByDevice")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("ReceivedAt");

                    b.HasIndex("Address", "MessageId");

                    b.ToTable("RecipientInformation", "Messages");
                });

            modelBuilder.Entity("Backbone.Modules.Messages.Domain.Entities.Relationship", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .IsFixedLength(false);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .IsFixedLength(false);

                    b.HasKey("Id");

                    b.ToTable("Relationships", "Relationships", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Backbone.Modules.Messages.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("Backbone.Modules.Messages.Domain.Entities.Message", null)
                        .WithMany("Attachments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backbone.Modules.Messages.Domain.Entities.RecipientInformation", b =>
                {
                    b.HasOne("Backbone.Modules.Messages.Domain.Entities.Message", null)
                        .WithMany("Recipients")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backbone.Modules.Messages.Domain.Entities.Message", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}
