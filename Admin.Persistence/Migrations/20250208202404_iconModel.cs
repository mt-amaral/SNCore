using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class iconModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SrcIcon",
                table: "HostModel",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SrcIcon",
                table: "HostModel");
        }
    }
}
