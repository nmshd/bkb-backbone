using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backbone.Modules.Devices.Infrastructure.Database.Postgres.Migrations;

/// <inheritdoc />
public partial class AppIdForPnsRegistrations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(""" DELETE FROM "PnsRegistrations" """);

        migrationBuilder.DropForeignKey(
            name: "FK_Identities_Tiers_TierId",
            schema: "Devices",
            table: "Identities");

        migrationBuilder.DropIndex(
            name: "IX_Identities_TierId",
            schema: "Devices",
            table: "Identities");

        migrationBuilder.AddColumn<string>(
            name: "AppId",
            schema: "Devices",
            table: "PnsRegistrations",
            type: "text",
            nullable: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "AppId",
            schema: "Devices",
            table: "PnsRegistrations");

        migrationBuilder.CreateIndex(
            name: "IX_Identities_TierId",
            schema: "Devices",
            table: "Identities",
            column: "TierId");

        migrationBuilder.AddForeignKey(
            name: "FK_Identities_Tiers_TierId",
            schema: "Devices",
            table: "Identities",
            column: "TierId",
            principalTable: "Tiers",
            principalColumn: "Id");
    }
}
