﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backbone.Modules.Tokens.Infrastructure.Database.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAddress80 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Tokens",
                table: "Tokens",
                type: "character(80)",
                unicode: false,
                fixedLength: true,
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(36)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 36);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "Tokens",
                table: "Tokens",
                type: "character(36)",
                unicode: false,
                fixedLength: true,
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(80)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 80);
        }
    }
}
