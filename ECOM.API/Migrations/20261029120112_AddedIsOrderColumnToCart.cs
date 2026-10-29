using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsOrderColumnToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrder",
                table: "CART",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 1,
                column: "IsOrder",
                value: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 2,
                column: "IsOrder",
                value: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 3,
                column: "IsOrder",
                value: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 4,
                column: "IsOrder",
                value: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 5,
                column: "IsOrder",
                value: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 6,
                column: "IsOrder",
                value: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 7,
                column: "IsOrder",
                value: false);

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 8,
                column: "IsOrder",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrder",
                table: "CART");
        }
    }
}
