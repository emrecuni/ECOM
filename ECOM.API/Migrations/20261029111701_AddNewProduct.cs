using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "ID", "BRAND_ID", "CREATED_AT", "DESCRIPTION", "IMAGE_PATH", "NAME", "PRICE", "SCORE", "SELLER_ID", "SUB_CATEGORY_ID", "SUP_CATEGORY_ID" },
                values: new object[] { 21, 2, new DateTime(2026, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yeni nesil A serisi çip, gelişmiş Pro kamera sistemi ve dayanıklı gövdesiyle Apple'ın en yeni Pro modeli. Mavi renk seçeneği.", "products/iphone18pro.jpg", "Apple iPhone 18 Pro", 89999.99m, 4.8f, 1, 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 21);
        }
    }
}
