using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class TokenColumnAddedToOrderHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TOKEN",
                table: "ORDER_HISTORY",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 1,
                column: "TOKEN",
                value: null);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 2,
                column: "TOKEN",
                value: null);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 3,
                column: "TOKEN",
                value: null);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 4,
                column: "TOKEN",
                value: null);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 5,
                column: "TOKEN",
                value: null);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 6,
                column: "TOKEN",
                value: null);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 7,
                column: "TOKEN",
                value: null);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 8,
                column: "TOKEN",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TOKEN",
                table: "ORDER_HISTORY");
        }
    }
}
