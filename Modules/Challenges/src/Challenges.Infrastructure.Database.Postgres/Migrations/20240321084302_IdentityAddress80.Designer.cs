﻿// <auto-generated />
using System;
using Backbone.Modules.Challenges.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backbone.Modules.Challenges.Infrastructure.Database.Postgres.Migrations
{
    [DbContext(typeof(ChallengesDbContext))]
    [Migration("20240321084302_IdentityAddress80")]
    partial class IdentityAddress80
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backbone.Modules.Challenges.Domain.Entities.Challenge", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character(80)")
                        .IsFixedLength();

                    b.Property<string>("CreatedByDevice")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("character(20)")
                        .IsFixedLength();

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });
#pragma warning restore 612, 618
        }
    }
}
