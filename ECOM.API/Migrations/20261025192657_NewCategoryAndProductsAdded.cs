using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class NewCategoryAndProductsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BRANDS",
                columns: new[] { "ID", "CREATED_AT", "NAME" },
                values: new object[,]
                {
                    { 6, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nike" },
                    { 7, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adidas" },
                    { 8, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mavi" },
                    { 9, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zara" },
                    { 10, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "IKEA" },
                    { 11, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karaca" },
                    { 12, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tefal" }
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "ID", "CREATED_AT", "NAME", "TYPE" },
                values: new object[,]
                {
                    { 7, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moda", false },
                    { 8, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erkek Giyim", false },
                    { 9, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kadın Giyim", false },
                    { 10, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayakkabı", false },
                    { 11, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ev & Yaşam", false },
                    { 12, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobilya", false },
                    { 13, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mutfak Gereçleri", false }
                });

            migrationBuilder.InsertData(
                table: "SELLERS",
                columns: new[] { "ID", "CREATED_AT", "NAME", "SCORE" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ModaPlus", null },
                    { 5, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "EvDekor", null }
                });

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "ID", "BRAND_ID", "CREATED_AT", "DESCRIPTION", "IMAGE_PATH", "NAME", "PRICE", "SCORE", "SELLER_ID", "SUB_CATEGORY_ID", "SUP_CATEGORY_ID" },
                values: new object[,]
                {
                    { 11, 8, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Esnek denim kumaş, slim fit kesim ve koyu indigo yıkama ile günlük kullanıma uygun erkek jean.", "products/mavijakejean.jpg", "Mavi Jake Slim Fit Jean", 1799.99m, 4.5f, 4, 8, 7 },
                    { 12, 7, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yumuşak pamuklu iç yüzey, klasik 3 şerit detayı ve rahat kesimli erkek sweatshirt.", "products/adidasessentialssweat.jpg", "Adidas Essentials 3-Stripes Sweatshirt", 1499.99m, 4.4f, 4, 8, 7 },
                    { 13, 9, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Su itici kumaş, kruvaze önden kapanış ve bel kuşağı ile zamansız kadın trençkot.", "products/zaratrenckot.jpg", "Zara Kuşaklı Trençkot", 3299.99m, 4.6f, 4, 9, 7 },
                    { 14, 8, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek bel, skinny kesim ve toparlayıcı esnek kumaş ile kadın jean.", "products/maviserenayjean.jpg", "Mavi Serenay Yüksek Bel Jean", 1699.99m, 4.3f, 4, 9, 7 },
                    { 15, 6, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deri üst yüzey, Air yastıklama teknolojisi ve ikonik tasarımıyla günlük spor ayakkabı.", "products/nikeairforce1.jpg", "Nike Air Force 1 '07", 4299.99m, 4.8f, 4, 10, 7 },
                    { 16, 7, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hafif Boost ara taban, Primeknit üst yüzey ve Continental dış taban ile koşu ayakkabısı.", "products/adidasultraboostlight.jpg", "Adidas Ultraboost Light", 6499.99m, 4.7f, 4, 10, 7 },
                    { 17, 10, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "4x4 bölmeli, çok yönlü kullanılabilen beyaz raf ünitesi; dikey veya yatay yerleştirilebilir.", "products/ikeakallax.jpg", "IKEA KALLAX Raf Ünitesi", 4999.99m, 4.6f, 5, 12, 11 },
                    { 18, 10, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huş kaplama esnek çerçeve ve yıkanabilir minder kılıfı ile ergonomik dinlenme koltuğu.", "products/ikeapoang.jpg", "IKEA POÄNG Koltuk", 5999.99m, 4.5f, 5, 12, 11 },
                    { 19, 11, new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Köpük sensörü, sesli uyarı ve 5 fincan kapasitesi ile pratik Türk kahvesi makinesi.", "products/karacahatir.jpg", "Karaca Hatır Türk Kahvesi Makinesi", 2499.99m, 4.6f, 5, 13, 11 },
                    { 20, 12, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çıkarılabilir saplar, Titanium yapışmaz kaplama ve indüksiyon uyumlu tabanlı istiflenebilir set.", "products/tefalingenio.jpg", "Tefal Ingenio 13 Parça Tencere Seti", 6999.99m, 4.7f, 5, 13, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
