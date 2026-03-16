using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BRANDS",
                columns: new[] { "ID", "ADDITION_TIME", "NAME" },
                values: new object[,]
                {
                    { 1, null, "Samsung" },
                    { 2, null, "Apple" },
                    { 3, null, "Sony" },
                    { 4, null, "LG" },
                    { 5, null, "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "ID", "ADDITION_TIME", "NAME", "TYPE" },
                values: new object[,]
                {
                    { 1, null, "Elektronik", false },
                    { 2, null, "Telefon", false },
                    { 3, null, "Bilgisayar", false },
                    { 4, null, "Televizyon", false },
                    { 5, null, "Ses Sistemleri", false },
                    { 6, null, "Küçük Ev Aletleri", false }
                });

            migrationBuilder.InsertData(
                table: "SELLERS",
                columns: new[] { "ID", "ADDITION_TIME", "NAME", "SCORE" },
                values: new object[,]
                {
                    { 1, null, "TechStore", null },
                    { 2, null, "ElektroMarket", null },
                    { 3, null, "DigiShop", null }
                });

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "ID", "ADDITION_TIME", "BRAND_ID", "DESCRIPTION", "IMAGE_PATH", "NAME", "PRICE", "SCORE", "SELLER_ID", "SUB_CATEGORY_ID", "SUP_CATEGORY_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A17 Pro çip, 48MP kamera sistemi ve titanyum tasarım ile güçlü bir akıllı telefon.", "/images/products/iphone15pro.jpg", "Apple iPhone 15 Pro", 54999.99m, 4.8f, 1, 2, 1 },
                    { 2, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Snapdragon 8 Gen 3 işlemci, 200MP kamera ve dahili S Pen ile üst segment deneyimi.", "/images/products/s24ultra.jpg", "Samsung Galaxy S24 Ultra", 49999.99m, 4.7f, 2, 2, 1 },
                    { 3, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Leica kamera ortaklığı, 5000mAh batarya ve 144Hz AMOLED ekran.", "/images/products/xiaomi14tpro.jpg", "Xiaomi 14T Pro", 24999.99m, 4.5f, 3, 2, 1 },
                    { 4, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "M3 çip, 13.6 inç Liquid Retina ekran ve 18 saate kadar pil ömrü.", "/images/products/macbookairm3.jpg", "Apple MacBook Air M3", 44999.99m, 4.9f, 1, 3, 1 },
                    { 5, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Intel Core Ultra 7 işlemci, 14 inç AMOLED ekran ve hafif alüminyum gövde.", "/images/products/galaxybook4pro.jpg", "Samsung Galaxy Book4 Pro", 38999.99m, 4.4f, 2, 3, 1 },
                    { 6, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Neo Quantum işlemci, Mini LED arka aydınlatma ve Dolby Atmos ses desteği.", "/images/products/samsungneqled65.jpg", "Samsung Neo QLED 4K 65\"", 34999.99m, 4.6f, 3, 4, 1 },
                    { 7, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "OLED evo panel, α9 AI işlemci ve webOS 24 ile sinema kalitesi deneyim.", "/images/products/lgoled c4.jpg", "LG OLED C4 55\"", 29999.99m, 4.8f, 1, 4, 1 },
                    { 8, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Sektörün en iyi gürültü engelleme teknolojisi, 30 saat pil ömrü ve katlanabilir tasarım.", "/images/products/sonywh1000xm5.jpg", "Sony WH-1000XM5", 9999.99m, 4.9f, 2, 5, 1 },
                    { 9, new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Aktif gürültü engelleme, Adaptif Ses ve H2 çip ile mükemmel ses deneyimi.", "/images/products/airpodspro2.jpg", "Apple AirPods Pro 2", 8499.99m, 4.7f, 3, 5, 1 },
                    { 10, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "OLED ekran, HEPA filtre ve Mi Home uygulaması ile akıllı hava temizleyici.", "/images/products/xiaomipurifier4pro.jpg", "Xiaomi Smart Air Purifier 4 Pro", 3499.99m, 4.3f, 1, 6, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
