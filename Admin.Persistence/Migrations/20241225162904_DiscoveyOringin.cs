using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DiscoveyOringin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DiscoveryOriginId",
                table: "OidDiscovery",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OidDiscovery_DiscoveryOriginId",
                table: "OidDiscovery",
                column: "DiscoveryOriginId",
                unique: true,
                filter: "[DiscoveryOriginId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OidDiscovery_OidList_DiscoveryOriginId",
                table: "OidDiscovery",
                column: "DiscoveryOriginId",
                principalTable: "OidList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OidDiscovery_OidList_DiscoveryOriginId",
                table: "OidDiscovery");

            migrationBuilder.DropIndex(
                name: "IX_OidDiscovery_DiscoveryOriginId",
                table: "OidDiscovery");

            migrationBuilder.DropColumn(
                name: "DiscoveryOriginId",
                table: "OidDiscovery");
        }
    }
}
