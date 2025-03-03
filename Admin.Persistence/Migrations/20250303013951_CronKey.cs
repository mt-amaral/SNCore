using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CronKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CronExpression_Host_HostId",
                table: "CronExpression");

            migrationBuilder.AddForeignKey(
                name: "FK_CronExpression_Host_HostId",
                table: "CronExpression",
                column: "HostId",
                principalTable: "Host",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CronExpression_Host_HostId",
                table: "CronExpression");

            migrationBuilder.AddForeignKey(
                name: "FK_CronExpression_Host_HostId",
                table: "CronExpression",
                column: "HostId",
                principalTable: "Host",
                principalColumn: "Id");
        }
    }
}
