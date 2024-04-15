﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backbone.Modules.Relationships.Infrastructure.Database.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class IdForRelationshipTemplateAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelationshipTemplateAllocations",
                schema: "Relationships",
                table: "RelationshipTemplateAllocations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "Relationships",
                table: "RelationshipTemplateAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                schema: "Relationships",
                table: "RelationshipChanges",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelationshipTemplateAllocations",
                schema: "Relationships",
                table: "RelationshipTemplateAllocations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipTemplateAllocations_RelationshipTemplateId_AllocatedBy",
                table: "RelationshipTemplateAllocations",
                columns: new[] { "RelationshipTemplateId", "AllocatedBy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelationshipTemplateAllocations",
                schema: "Relationships",
                table: "RelationshipTemplateAllocations");

            migrationBuilder.DropIndex(
                name: "IX_RelationshipTemplateAllocations_RelationshipTemplateId_AllocatedBy",
                schema: "Relationships",
                table: "RelationshipTemplateAllocations");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Relationships",
                table: "RelationshipTemplateAllocations");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                schema: "Relationships",
                table: "RelationshipChanges",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(34)",
                oldMaxLength: 34);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelationshipTemplateAllocations",
                schema: "Relationships",
                table: "RelationshipTemplateAllocations",
                columns: new[] { "RelationshipTemplateId", "AllocatedBy" });
        }
    }
}
