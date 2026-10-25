using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 1,
                column: "IMAGE_PATH",
                value: "products/iphone15pro.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 2,
                column: "IMAGE_PATH",
                value: "products/s24ultra.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 3,
                column: "IMAGE_PATH",
                value: "products/xiaomi14tpro.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 4,
                column: "IMAGE_PATH",
                value: "products/macbookairm3.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 5,
                column: "IMAGE_PATH",
                value: "products/galaxybook4pro.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 6,
                column: "IMAGE_PATH",
                value: "products/samsungneqled65.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 7,
                column: "IMAGE_PATH",
                value: "products/lgoled c4.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 8,
                column: "IMAGE_PATH",
                value: "products/sonywh1000xm5.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 9,
                column: "IMAGE_PATH",
                value: "products/airpodspro2.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 10,
                column: "IMAGE_PATH",
                value: "products/xiaomipurifier4pro.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 1,
                column: "IMAGE_PATH",
                value: "/images/products/iphone15pro.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 2,
                column: "IMAGE_PATH",
                value: "/images/products/s24ultra.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 3,
                column: "IMAGE_PATH",
                value: "/images/products/xiaomi14tpro.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 4,
                column: "IMAGE_PATH",
                value: "/images/products/macbookairm3.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 5,
                column: "IMAGE_PATH",
                value: "/images/products/galaxybook4pro.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 6,
                column: "IMAGE_PATH",
                value: "/images/products/samsungneqled65.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 7,
                column: "IMAGE_PATH",
                value: "/images/products/lgoled c4.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 8,
                column: "IMAGE_PATH",
                value: "/images/products/sonywh1000xm5.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 9,
                column: "IMAGE_PATH",
                value: "/images/products/airpodspro2.jpg");

            migrationBuilder.UpdateData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 10,
                column: "IMAGE_PATH",
                value: "/images/products/xiaomipurifier4pro.jpg");
        }
    }
}
