﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backbone.Modules.Tokens.Infrastructure.Database.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class PersonalizedTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForIdentity",
                schema: "Tokens",
                table: "Tokens",
                type: "character varying(80)",
                unicode: false,
                maxLength: 80,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForIdentity",
                schema: "Tokens",
                table: "Tokens");
        }
    }
}
