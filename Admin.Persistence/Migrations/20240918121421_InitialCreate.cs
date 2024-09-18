using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HostGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HostModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    Ipv4 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Host_HostGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "HostGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Host_HostModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "HostModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Snmp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SnmpVersion = table.Column<short>(type: "smallint", nullable: false),
                    Community = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snmp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Snmp_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telnet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telnet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telnet_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Host_GroupId",
                table: "Host",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Host_ModelId",
                table: "Host",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Snmp_HostId",
                table: "Snmp",
                column: "HostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telnet_HostId",
                table: "Telnet",
                column: "HostId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snmp");

            migrationBuilder.DropTable(
                name: "Telnet");

            migrationBuilder.DropTable(
                name: "Host");

            migrationBuilder.DropTable(
                name: "HostGroup");

            migrationBuilder.DropTable(
                name: "HostModel");
        }
    }
}
