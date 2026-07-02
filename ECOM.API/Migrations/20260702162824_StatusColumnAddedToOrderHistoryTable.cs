using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class StatusColumnAddedToOrderHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "STATUS",
                table: "ORDER_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 1,
                column: "STATUS",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 2,
                column: "STATUS",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 3,
                column: "STATUS",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 4,
                column: "STATUS",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 5,
                column: "STATUS",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 6,
                column: "STATUS",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 7,
                column: "STATUS",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 8,
                column: "STATUS",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "ORDER_HISTORY");
        }
    }
}
