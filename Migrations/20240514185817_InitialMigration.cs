using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maxsociety.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FlatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResidentName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    VisitPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                });

            migrationBuilder.CreateTable(
                name: "VisitorLogs",
                columns: table => new
                {
                    VisitorLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorId = table.Column<long>(type: "bigint", nullable: true),
                    VisitDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorLogs", x => x.VisitorLogId);
                    table.ForeignKey(
                        name: "FK_VisitorLogs_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "VisitorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLogs_VisitorId",
                table: "VisitorLogs",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitorLogs");

            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
