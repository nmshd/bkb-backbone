﻿using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.Attributes;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backbone.Modules.Devices.Infrastructure.Database.Postgres.Migrations
{
    /// <inheritdoc />
    [DependsOn(ModuleType.Devices, "20240701074627_Init")]
    public partial class AddAdditionalDataToIdentityDeletionProcessAuditLogEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalData",
                schema: "Devices",
                table: "IdentityDeletionProcessAuditLog",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalData",
                schema: "Devices",
                table: "IdentityDeletionProcessAuditLog");
        }
    }
}
