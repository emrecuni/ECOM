using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNameInOrderHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ORDER_HISTORY",
                newName: "TOTAL_PRICE");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "ORDER_HISTORY",
                newName: "CART_ID");

            migrationBuilder.AlterColumn<int>(
                name: "CART_ID",
                table: "ORDER_HISTORY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TOTAL_PRICE",
                table: "ORDER_HISTORY",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "CART_ID",
                table: "ORDER_HISTORY",
                newName: "CartId");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "ORDER_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
