using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class CommentSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "COMMENTS",
                columns: new[] { "ID", "COMMENT", "CUSTOMER_ID", "IMAGE_PATH", "PRODUCT_ID", "SCORE" },
                values: new object[,]
                {
                    { 1, "Great product! Highly recommend.", 1, null, 1, 5 },
                    { 2, "Not bad! Recommend.", 2, null, 1, 3 },
                    { 3, "Wonderful! Highly recommend.", 4, null, 1, 5 },
                    { 4, "Recommend.", 3, null, 3, 4 }
                });

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: null);
        }
    }
}
