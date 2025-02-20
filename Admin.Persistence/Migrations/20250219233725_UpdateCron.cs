using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCron : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CronExpression_HostGroup_GroupId",
                table: "CronExpression");

            migrationBuilder.DropIndex(
                name: "IX_CronExpression_GroupId",
                table: "CronExpression");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "CronExpression");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "CronExpression",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "CronExpression",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Minute",
                table: "CronExpression",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "CronExpression",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weesday",
                table: "CronExpression",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "CronExpression");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "CronExpression");

            migrationBuilder.DropColumn(
                name: "Minute",
                table: "CronExpression");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "CronExpression");

            migrationBuilder.DropColumn(
                name: "Weesday",
                table: "CronExpression");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "CronExpression",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CronExpression_GroupId",
                table: "CronExpression",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CronExpression_HostGroup_GroupId",
                table: "CronExpression",
                column: "GroupId",
                principalTable: "HostGroup",
                principalColumn: "Id");
        }
    }
}
