using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewSeedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BRANDS",
                columns: new[] { "ID", "CREATED_AT", "NAME" },
                values: new object[,]
                {
                    { 13, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMD" },
                    { 14, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASUS" },
                    { 15, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MSI" },
                    { 16, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puma" },
                    { 17, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reusch" },
                    { 18, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Team Group" },
                    { 19, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "XFX" }
                });

            migrationBuilder.InsertData(
                table: "COMMENTS",
                columns: new[] { "ID", "COMMENT", "CREATED_AT", "CUSTOMER_ID", "IMAGE_PATH", "PRODUCT_ID", "SCORE" },
                values: new object[,]
                {
                    { 5, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 2, 5 },
                    { 6, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 2, 4 },
                    { 7, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 2, 5 },
                    { 8, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 3, 5 },
                    { 9, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 3, 4 },
                    { 10, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 4, 5 },
                    { 11, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 4, 5 },
                    { 12, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 4, 4 },
                    { 13, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 5, 4 },
                    { 14, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 5, 4 },
                    { 15, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 6, 5 },
                    { 16, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 6, 4 },
                    { 17, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 6, 4 },
                    { 18, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 7, 5 },
                    { 19, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 7, 5 },
                    { 20, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 8, 5 },
                    { 21, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 8, 5 },
                    { 22, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 8, 4 },
                    { 23, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 9, 5 },
                    { 24, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 9, 4 },
                    { 25, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 9, 4 },
                    { 26, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 10, 4 },
                    { 27, "Ortalama bir ürün, idare eder.", new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 10, 3 },
                    { 28, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 11, 5 },
                    { 29, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 11, 4 },
                    { 30, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 11, 4 },
                    { 31, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 12, 4 },
                    { 32, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 12, 4 },
                    { 33, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 12, 5 },
                    { 34, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 13, 5 },
                    { 35, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 13, 4 },
                    { 36, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 14, 4 },
                    { 37, "Fena değil ama daha iyisini beklerdim.", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 14, 3 },
                    { 38, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 14, 4 },
                    { 39, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 15, 5 },
                    { 40, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 15, 5 },
                    { 41, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 15, 5 },
                    { 42, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 16, 5 },
                    { 43, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 16, 4 },
                    { 44, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 16, 5 },
                    { 45, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 17, 5 },
                    { 46, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 17, 4 },
                    { 47, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 18, 4 },
                    { 48, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 18, 5 },
                    { 49, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 18, 4 },
                    { 50, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 19, 5 },
                    { 51, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 19, 4 },
                    { 52, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 19, 5 },
                    { 53, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 20, 5 },
                    { 54, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 20, 5 },
                    { 55, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 20, 4 },
                    { 56, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 21, 5 },
                    { 57, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 21, 5 }
                });

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 1,
                column: "SCORE",
                value: 4.3333335f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 2,
                column: "SCORE",
                value: 4.6666665f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 3,
                column: "SCORE",
                value: 4.3333335f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 4,
                column: "SCORE",
                value: 4.6666665f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 5,
                column: "SCORE",
                value: 4f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 6,
                column: "SCORE",
                value: 4.3333335f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 7,
                column: "SCORE",
                value: 5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 8,
                column: "SCORE",
                value: 4.6666665f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 9,
                column: "SCORE",
                value: 4.3333335f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 10,
                column: "SCORE",
                value: 3.5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 11,
                column: "SCORE",
                value: 4.3333335f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 12,
                column: "SCORE",
                value: 4.3333335f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 13,
                column: "SCORE",
                value: 4.5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 14,
                column: "SCORE",
                value: 3.6666667f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 15,
                column: "SCORE",
                value: 5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 16,
                column: "SCORE",
                value: 4.6666665f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 17,
                column: "SCORE",
                value: 4.5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 18,
                column: "SCORE",
                value: 4.3333335f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 19,
                column: "SCORE",
                value: 4.6666665f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 20,
                column: "SCORE",
                value: 4.6666665f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 21,
                column: "SCORE",
                value: 5f);

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "ID", "BRAND_ID", "CREATED_AT", "DESCRIPTION", "IMAGE_PATH", "NAME", "PRICE", "SCORE", "SELLER_ID", "SUB_CATEGORY_ID", "SUP_CATEGORY_ID" },
                values: new object[,]
                {
                    { 37, 3, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mini LED aydınlatma, XR işlemci ve Google TV ile parlak ve canlı görüntü.", "products/sonybravia7.jpg", "Sony Bravia 7 55\" Mini LED TV", 44999.99m, 4.5f, 2, 4, 1 },
                    { 38, 4, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "IP67 dayanıklılık, 15 saat pil ömrü ve güçlü bas sunan taşınabilir hoparlör.", "products/lgxboomxg8t.jpg", "LG XBOOM Go XG8T Bluetooth Hoparlör", 6499.99m, 3.6666667f, 3, 5, 1 },
                    { 39, 5, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazer navigasyon, 4000Pa emiş gücü ve paspas özelliğiyle akıllı robot süpürge.", "products/xiaomirobots10.jpg", "Xiaomi Robot Vacuum S10", 8999.99m, 4.3333335f, 3, 6, 1 },
                    { 40, 6, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teri hızla uzaklaştıran Dri-FIT kumaş ve hafif yapısıyla erkek koşu tişörtü.", "products/nikedrifittshirt.jpg", "Nike Dri-FIT Koşu Tişörtü", 1199.99m, 4f, 4, 8, 7 },
                    { 41, 9, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akışkan saten kumaş, V yaka ve ince askılı midi boy kadın elbise.", "products/zarasatenelbise.jpg", "Zara Saten Midi Elbise", 1899.99m, 4f, 4, 9, 7 },
                    { 42, 8, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yumuşak pamuklu içi şardonlu kumaş ve rahat kesimli kapüşonlu sweatshirt.", "products/mavikapusonlusweat.jpg", "Mavi Kapüşonlu Kadın Sweatshirt", 999.99m, 4f, 4, 9, 7 },
                    { 43, 10, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çekmeceli, sade tasarımlı ve kablo düzenleme bölmeli çalışma masası.", "products/ikeamalmmasa.jpg", "IKEA MALM Çalışma Masası", 4499.99m, 4.3333335f, 5, 12, 11 },
                    { 44, 11, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elmas katkılı yapışmaz kaplama ve tüm ocaklarla uyumlu tabanlı tava seti.", "products/karacabiodiamond.jpg", "Karaca Bio Diamond 3'lü Tava Seti", 2799.99m, 4.5f, 5, 13, 11 },
                    { 45, 12, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "5.6 litre kapasite, 8 otomatik program ve yağsız pişirme sunan fritöz.", "products/tefaleasyfry.jpg", "Tefal Easy Fry XXL Airfryer", 4999.99m, 4.6666665f, 5, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "ID", "CREATED_AT", "NAME", "TYPE" },
                values: new object[,]
                {
                    { 14, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spor", false },
                    { 15, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Futbol Ekipmanları", false },
                    { 16, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilgisayar Bileşenleri", false },
                    { 17, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tablet", false }
                });

            migrationBuilder.InsertData(
                table: "SELLERS",
                columns: new[] { "ID", "CREATED_AT", "NAME", "SCORE" },
                values: new object[] { 6, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SporMarket", null });

            migrationBuilder.InsertData(
                table: "COMMENTS",
                columns: new[] { "ID", "COMMENT", "CREATED_AT", "CUSTOMER_ID", "IMAGE_PATH", "PRODUCT_ID", "SCORE" },
                values: new object[,]
                {
                    { 100, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 37, 5 },
                    { 101, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 37, 4 },
                    { 102, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 38, 4 },
                    { 103, "Fena değil ama daha iyisini beklerdim.", new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 38, 3 },
                    { 104, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 38, 4 },
                    { 105, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 39, 5 },
                    { 106, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 39, 4 },
                    { 107, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 39, 4 },
                    { 108, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 40, 4 },
                    { 109, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 40, 4 },
                    { 110, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 41, 5 },
                    { 111, "Fena değil ama daha iyisini beklerdim.", new DateTime(2026, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 41, 3 },
                    { 112, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 41, 4 },
                    { 113, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 42, 4 },
                    { 114, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 42, 4 },
                    { 115, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 42, 4 },
                    { 116, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 43, 4 },
                    { 117, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 43, 5 },
                    { 118, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 43, 4 },
                    { 119, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 44, 5 },
                    { 120, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 44, 4 },
                    { 121, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 45, 5 },
                    { 122, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 45, 5 },
                    { 123, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 45, 4 }
                });

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "ID", "BRAND_ID", "CREATED_AT", "DESCRIPTION", "IMAGE_PATH", "NAME", "PRICE", "SCORE", "SELLER_ID", "SUB_CATEGORY_ID", "SUP_CATEGORY_ID" },
                values: new object[,]
                {
                    { 22, 13, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 çekirdek 12 izlek, 4.6 GHz boost hızı ve 65W TDP ile oyun ve günlük kullanım için verimli masaüstü işlemci.", "products/AMD Ryzen 5 5600X.jpg", "AMD Ryzen 5 5600X", 5499.99m, 4.6666665f, 3, 16, 1 },
                    { 23, 14, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AM4 soket, PCIe 4.0, Wi-Fi 6 ve 2.5Gb Ethernet desteğiyle dayanıklı mATX anakart.", "products/asus-tuf-gaming-b550m-e-wifi-1.png", "ASUS TUF Gaming B550M-E WiFi Anakart", 4299.99m, 4.3333335f, 1, 16, 1 },
                    { 24, 15, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6GB GDDR5 bellek ve çift fanlı Ventus soğutmayla 1080p oyunlar için ekran kartı.", "products/gtx 1660.jpg", "MSI GeForce GTX 1660 Ventus XS 6GB", 8999.99m, 3.6666667f, 2, 16, 1 },
                    { 25, 15, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Temperli cam yan panel, 2 adet ARGB fan ve geniş hava akışı sunan Mid-Tower oyuncu kasası.", "products/msi 100m.jpg", "MSI MAG Forge 100M Kasa", 2499.99m, 4.5f, 3, 16, 1 },
                    { 26, 18, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2x8GB kit, alüminyum soğutucu ve düşük gecikme değerleriyle masaüstü bellek.", "products/team t-force.jpg", "Team Group T-Force Vulcan Z 16GB DDR4 3200MHz", 1399.99m, 4.3333335f, 1, 16, 1 },
                    { 27, 14, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "165Hz yenileme hızı, 1ms MPRT ve FreeSync Premium destekli Full HD kavisli oyuncu monitörü.", "products/tuf vg24vqr.jpg", "ASUS TUF Gaming VG24VQR 23.6\" Kavisli Monitör", 5999.99m, 4.6666665f, 2, 3, 1 },
                    { 28, 19, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "8GB GDDR6 bellek ve RDNA 2 mimarisiyle 1080p oyunlarda yüksek performans.", "products/xfx rx6600.jpg", "XFX Speedster SWFT 210 Radeon RX 6600 8GB", 9499.99m, 4f, 2, 16, 1 },
                    { 29, 5, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "11.2 inç 144Hz 3.2K ekran, Snapdragon 7+ Gen 3 işlemci ve 8850 mAh batarya.", "products/xiaomi-pad-7.jpg", "Xiaomi Pad 7", 15999.99m, 4.3333335f, 3, 17, 1 },
                    { 30, 6, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hafif üst yüzey ve çorap bilekli tasarımıyla hız odaklı profesyonel futbol kramponu.", "products/Nike Superfly.jpg", "Nike Mercurial Superfly Krampon", 7499.99m, 4.6666665f, 6, 15, 14 },
                    { 31, 16, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayarlanabilir FUZIONFIT+ bant sistemiyle ayağı saran, top kontrolü odaklı krampon.", "products/Puma Future.jpg", "Puma Future Krampon", 5299.99m, 3.6666667f, 6, 15, 14 },
                    { 32, 16, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra hafif yapısı ve hızlı çıkış sağlayan tabanıyla süratli oyuncular için krampon.", "products/Puma Ultra.jpg", "Puma Ultra Krampon", 4799.99m, 4.5f, 6, 15, 14 },
                    { 33, 17, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek tutuş sağlayan Grip lateks avuç içi ve esnek bilek bandıyla maç eldiveni.", "products/reusch.jpg", "Reusch Attrakt Kaleci Eldiveni", 2299.99m, 4.3333335f, 6, 15, 14 },
                    { 34, 17, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parmak koruma çubuklu yapısı ve dayanıklı lateksiyle antrenman ve maç eldiveni.", "products/reusch(2).jpg", "Reusch Argos Pro M1 Kaleci Eldiveni", 1899.99m, 3.3333333f, 6, 15, 14 },
                    { 35, 1, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10.9 inç ekran, S Pen desteği ve IP68 suya dayanıklılık sunan tablet.", "products/galaxytabs9fe.jpg", "Samsung Galaxy Tab S9 FE", 12999.99m, 4.3333335f, 2, 17, 1 },
                    { 36, 2, new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "M2 çip, 11 inç Liquid Retina ekran ve Apple Pencil Pro desteğiyle güçlü tablet.", "products/ipadairm2.jpg", "Apple iPad Air M2", 27999.99m, 5f, 1, 17, 1 }
                });

            migrationBuilder.InsertData(
                table: "COMMENTS",
                columns: new[] { "ID", "COMMENT", "CREATED_AT", "CUSTOMER_ID", "IMAGE_PATH", "PRODUCT_ID", "SCORE" },
                values: new object[,]
                {
                    { 58, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 22, 5 },
                    { 59, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 22, 5 },
                    { 60, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 22, 4 },
                    { 61, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 23, 4 },
                    { 62, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 23, 4 },
                    { 63, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 23, 5 },
                    { 64, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 24, 4 },
                    { 65, "Fiyatı biraz yüksek, performansı orta.", new DateTime(2026, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 24, 3 },
                    { 66, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 24, 4 },
                    { 67, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 25, 4 },
                    { 68, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 25, 5 },
                    { 69, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 26, 5 },
                    { 70, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 26, 4 },
                    { 71, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 26, 4 },
                    { 72, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 27, 5 },
                    { 73, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 27, 4 },
                    { 74, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 27, 5 },
                    { 75, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 28, 4 },
                    { 76, "İyi bir ürün, tavsiye ederim.", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 28, 4 },
                    { 77, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 29, 5 },
                    { 78, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 29, 4 },
                    { 79, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 29, 4 },
                    { 80, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 30, 5 },
                    { 81, "Harika bir ürün, kesinlikle tavsiye ederim.", new DateTime(2026, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 30, 5 },
                    { 82, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 30, 4 },
                    { 83, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 31, 4 },
                    { 84, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 31, 4 },
                    { 85, "Fena değil ama daha iyisini beklerdim.", new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 31, 3 },
                    { 86, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 32, 4 },
                    { 87, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 32, 5 },
                    { 88, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 33, 5 },
                    { 89, "Beklediğim gibi çıktı, sorun yaşamadım.", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 33, 4 },
                    { 90, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 33, 4 },
                    { 91, "Fiyatı biraz yüksek, performansı orta.", new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 34, 3 },
                    { 92, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 34, 4 },
                    { 93, "Fena değil ama daha iyisini beklerdim.", new DateTime(2026, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 34, 3 },
                    { 94, "Fiyatına göre gayet başarılı.", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 35, 4 },
                    { 95, "Genel olarak memnunum, küçük eksikleri var.", new DateTime(2026, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 35, 4 },
                    { 96, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 35, 5 },
                    { 97, "Beklentimin çok üzerinde çıktı, çok memnunum.", new DateTime(2026, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 36, 5 },
                    { 98, "Kalitesi ve performansı mükemmel.", new DateTime(2026, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 36, 5 },
                    { 99, "Kargo hızlıydı, ürün kusursuz geldi.", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 36, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 1,
                column: "SCORE",
                value: 4.8f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 2,
                column: "SCORE",
                value: 4.7f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 3,
                column: "SCORE",
                value: 4.5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 4,
                column: "SCORE",
                value: 4.9f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 5,
                column: "SCORE",
                value: 4.4f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 6,
                column: "SCORE",
                value: 4.6f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 7,
                column: "SCORE",
                value: 4.8f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 8,
                column: "SCORE",
                value: 4.9f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 9,
                column: "SCORE",
                value: 4.7f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 10,
                column: "SCORE",
                value: 4.3f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 11,
                column: "SCORE",
                value: 4.5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 12,
                column: "SCORE",
                value: 4.4f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 13,
                column: "SCORE",
                value: 4.6f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 14,
                column: "SCORE",
                value: 4.3f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 15,
                column: "SCORE",
                value: 4.8f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 16,
                column: "SCORE",
                value: 4.7f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 17,
                column: "SCORE",
                value: 4.6f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 18,
                column: "SCORE",
                value: 4.5f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 19,
                column: "SCORE",
                value: 4.6f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 20,
                column: "SCORE",
                value: 4.7f);

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 21,
                column: "SCORE",
                value: 4.8f);
        }
    }
}
