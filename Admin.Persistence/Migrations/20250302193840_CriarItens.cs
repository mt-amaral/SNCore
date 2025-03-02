using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CriarItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CronExpression_ItemId",
                table: "CronExpression");

            migrationBuilder.CreateIndex(
                name: "IX_CronExpression_ItemId",
                table: "CronExpression",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CronExpression_ItemId",
                table: "CronExpression");

            migrationBuilder.CreateIndex(
                name: "IX_CronExpression_ItemId",
                table: "CronExpression",
                column: "ItemId",
                unique: true);
        }
    }
}
