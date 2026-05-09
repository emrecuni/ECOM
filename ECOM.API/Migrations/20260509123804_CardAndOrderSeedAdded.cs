using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class CardAndOrderSeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CARDS",
                columns: new[] { "ID", "CVV", "CARD_NO", "CREATED_AT", "CUSTOMER_ID", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "000", "4111111111111111", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "12/26" },
                    { 2, "000", "5500000000000004", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "08/27" },
                    { 3, "000", "3714496353984312", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "05/26" }
                });

            migrationBuilder.InsertData(
                table: "ORDER_HISTORY",
                columns: new[] { "ID", "CARD_ID", "CART_ID", "CUSTOMER_ID", "DELIVERY_DATE", "ORDER_DATE", "PIECE", "PRODUCT_ID", "SELLER_ID", "TOTAL_PRICE" },
                values: new object[,]
                {
                    { 1, 1, null, 1, new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 54999.99m },
                    { 2, 1, null, 1, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, 2, 9999.99m },
                    { 3, 2, 4, 2, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 1, 40499.99m },
                    { 4, 2, null, 2, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9, 3, 16999.98m },
                    { 5, 3, 5, 3, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, 1, 29999.99m },
                    { 6, 3, null, 3, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 24999.99m },
                    { 7, 1, null, 1, null, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, 3, 34999.99m },
                    { 8, 2, 8, 2, null, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, 1, 6299.98m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ORDER_HISTORY",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CARDS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CARDS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CARDS",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
