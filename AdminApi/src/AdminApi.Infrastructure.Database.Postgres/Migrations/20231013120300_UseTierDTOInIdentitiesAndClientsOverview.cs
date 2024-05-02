using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminUi.Infrastructure.Database.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UseTierDTOInIdentitiesAndClientsOverview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(""" DROP VIEW "AdminUi"."ClientOverviews" """);

            migrationBuilder.Sql("""
                CREATE VIEW "AdminUi"."ClientOverviews" AS
                    SELECT
                        CLIENTS."ClientId" AS "ClientId",
                        CLIENTS."DisplayName" AS "DisplayName",
                        CLIENTS."DefaultTier" AS "DefaultTierId",
                        TIERS."Name" AS "DefaultTierName",
                        CLIENTS."CreatedAt" AS "CreatedAt",
                        (
        		            SELECT COUNT("ClientId") 
        		            FROM "Devices"."Identities"
        		            WHERE "ClientId" = CLIENTS."ClientId"
        	            ) AS "NumberOfIdentities"
                    FROM "Devices"."OpenIddictApplications" CLIENTS
                    LEFT JOIN "Devices"."Tiers" TIERS
                    ON TIERS."Id" = CLIENTS."DefaultTier"
        """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(""" DROP VIEW "AdminUi"."ClientOverviews" """);

            migrationBuilder.Sql("""
                CREATE VIEW "AdminUi"."ClientOverviews" AS
                    SELECT
                        CLIENTS."ClientId" AS "ClientId",
                        CLIENTS."DisplayName" AS "DisplayName",
                        CLIENTS."DefaultTier" AS "DefaultTier",
                        CLIENTS."CreatedAt" AS "CreatedAt",
                        (
        		            SELECT COUNT("ClientId") 
        		            FROM "Devices"."Identities"
        		            WHERE "ClientId" = CLIENTS."ClientId"
        	            ) AS "NumberOfIdentities"
                    FROM "Devices"."OpenIddictApplications" CLIENTS
        """);
        }
    }
}
