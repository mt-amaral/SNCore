﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
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
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SrcIcon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OidList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oid = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OidList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: true),
                    OidId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_HostModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "HostModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_OidList_OidId",
                        column: x => x.OidId,
                        principalTable: "OidList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OidDiscovery",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OidDiscoveryIndex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscoveryOriginId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OidDiscovery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OidDiscovery_OidList_DiscoveryOriginId",
                        column: x => x.DiscoveryOriginId,
                        principalTable: "OidList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Snmp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnmpVersion = table.Column<short>(type: "smallint", nullable: false),
                    Community = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    User = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "CronExpression",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Second = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Minute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Day = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Month = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weesday = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CronExpression", x => x.Id);
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
                name: "IX_CronExpression_HostId",
                table: "CronExpression",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_CronExpression_ItemId",
                table: "CronExpression",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Host_GroupId",
                table: "Host",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Host_ModelId",
                table: "Host",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ModelId",
                table: "Item",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_OidId",
                table: "Item",
                column: "OidId",
                unique: true,
                filter: "[OidId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OidDiscovery_DiscoveryOriginId",
                table: "OidDiscovery",
                column: "DiscoveryOriginId",
                unique: true,
                filter: "[DiscoveryOriginId] IS NOT NULL");

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
                name: "CronExpression");

            migrationBuilder.DropTable(
                name: "OidDiscovery");

            migrationBuilder.DropTable(
                name: "Snmp");

            migrationBuilder.DropTable(
                name: "Telnet");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Host");

            migrationBuilder.DropTable(
                name: "OidList");

            migrationBuilder.DropTable(
                name: "HostGroup");

            migrationBuilder.DropTable(
                name: "HostModel");
        }
    }
}
