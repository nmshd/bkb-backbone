﻿// <auto-generated />
using System;
using Backbone.Modules.Tokens.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backbone.Modules.Tokens.Infrastructure.Database.SqlServer.Migrations
{
    [DbContext(typeof(TokensDbContext))]
    partial class TokensDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Tokens")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backbone.Modules.Tokens.Domain.Entities.Token", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<byte[]>("Content")
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

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ForIdentity")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .IsFixedLength(false);

                    b.Property<byte[]>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("varbinary(200)");

                    b.HasKey("Id");

                    b.ToTable("Tokens", "Tokens");
                });

            modelBuilder.Entity("Backbone.Modules.Tokens.Domain.Entities.TokenAllocation", b =>
                {
                    b.Property<string>("TokenId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<string>("AllocatedBy")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .IsFixedLength(false);

                    b.Property<DateTime>("AllocatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("AllocatedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.HasKey("TokenId", "AllocatedBy");

                    b.ToTable("TokenAllocations", "Tokens");
                });

            modelBuilder.Entity("Backbone.Modules.Tokens.Domain.Entities.TokenAllocation", b =>
                {
                    b.HasOne("Backbone.Modules.Tokens.Domain.Entities.Token", null)
                        .WithMany("Allocations")
                        .HasForeignKey("TokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backbone.Modules.Tokens.Domain.Entities.Token", b =>
                {
                    b.Navigation("Allocations");
                });
#pragma warning restore 612, 618
        }
    }
}
