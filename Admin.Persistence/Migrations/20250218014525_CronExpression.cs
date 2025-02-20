using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CronExpression : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CronExpression",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expression = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CronExpression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CronExpression_HostGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "HostGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CronExpression_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CronExpression_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CronExpression_GroupId",
                table: "CronExpression",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CronExpression_HostId",
                table: "CronExpression",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_CronExpression_ItemId",
                table: "CronExpression",
                column: "ItemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CronExpression");
        }
    }
}
