using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maxsociety.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVisitorFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Visitors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Visitors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Visitors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
