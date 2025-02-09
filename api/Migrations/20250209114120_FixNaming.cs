using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Address",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Address",
                newName: "Latitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Address",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Address",
                newName: "latitude");
        }
    }
}
