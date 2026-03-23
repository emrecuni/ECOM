using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FAVORITES",
                columns: new[] { "ID", "ADDITION_TIME", "CUSTOMER_ID", "PRODUCT_ID" },
                values: new object[,]
                {
                    { 1, null, 1, 1 },
                    { 2, null, 1, 2 },
                    { 3, null, 2, 3 },
                    { 4, null, 1, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FAVORITES",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
