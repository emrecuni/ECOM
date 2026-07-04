using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class ZipCodeAddedToNeighbourhoodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZIP_CODE",
                table: "NEIGHBOURHOODS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 1,
                column: "ZIP_CODE",
                value: null);

            migrationBuilder.UpdateData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 2,
                column: "ZIP_CODE",
                value: null);

            migrationBuilder.UpdateData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 3,
                column: "ZIP_CODE",
                value: null);

            migrationBuilder.UpdateData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 4,
                column: "ZIP_CODE",
                value: null);

            migrationBuilder.UpdateData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 5,
                column: "ZIP_CODE",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZIP_CODE",
                table: "NEIGHBOURHOODS");
        }
    }
}
