using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class CartSeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CART",
                columns: new[] { "ID", "ADDITION_TIME", "CUSTOMER_ID", "DCOUPON_ID", "ENABLE", "PIECE", "PRODUCT_ID", "SELLER_ID", "TOTAL_PRICE" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, true, 1, 1, 1, 54999.99m },
                    { 2, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, true, 1, 3, 3, 24999.99m },
                    { 3, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, true, 2, 8, 2, 19999.98m },
                    { 4, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, true, 1, 4, 1, 40499.99m },
                    { 5, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, true, 1, 7, 1, 29999.99m },
                    { 6, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, true, 3, 9, 3, 25499.97m },
                    { 7, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false, 1, 2, 2, 49999.99m },
                    { 8, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, false, 2, 10, 1, 6299.98m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 8);
        }
    }
}
