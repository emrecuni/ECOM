using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class AddressSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NEIGHBOURHOODS_CITY_CITY_ID",
                table: "NEIGHBOURHOODS");

            migrationBuilder.RenameColumn(
                name: "CITY_ID",
                table: "NEIGHBOURHOODS",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_NEIGHBOURHOODS_CITY_ID",
                table: "NEIGHBOURHOODS",
                newName: "IX_NEIGHBOURHOODS_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "NEIGHBOURHOODS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 5,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "CITY",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "İstanbul" },
                    { 2, "Ankara" },
                    { 3, "İzmir" }
                });

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 5,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 6,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DISTRICT",
                columns: new[] { "ID", "CITY_ID", "NAME" },
                values: new object[,]
                {
                    { 1, 1, "Kadıköy" },
                    { 2, 1, "Beşiktaş" },
                    { 3, 1, "Üsküdar" },
                    { 4, 2, "Çankaya" },
                    { 5, 3, "Konak" }
                });

            migrationBuilder.InsertData(
                table: "NEIGHBOURHOODS",
                columns: new[] { "ID", "CityId", "DISTRICT_ID", "NAME" },
                values: new object[,]
                {
                    { 1, null, 1, "Moda" },
                    { 2, null, 1, "Göztepe" },
                    { 3, null, 2, "Levent" },
                    { 4, null, 2, "Etiler" },
                    { 5, null, 4, "Kızılay" }
                });

            migrationBuilder.InsertData(
                table: "ADDRESSES",
                columns: new[] { "ID", "ADDITION_TIME", "ADDRESS", "ADDRESS_NAME", "CITY_ID", "CUSTOMER_ID", "DISTRICT_ID", "NEIGHBOURHOOD_ID", "RECEIVER_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moda Cad. No:12 D:3", "Ev", 1, 1, 1, 1, 1 },
                    { 2, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Levent Mah. Büyükdere Cad. No:45 Kat:7", "İş yeri", 1, 1, 2, 3, 1 },
                    { 3, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fenerbahçe Mah. Bağdat Cad. No:78", "Ev", 1, 2, 1, 2, 2 },
                    { 4, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Etiler Mah. Nisbetiye Cad. No:5 D:8", "Annem", 1, 2, 2, 4, 3 },
                    { 5, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kızılay Mah. Atatürk Bulvarı No:101 D:2", "Ev", 2, 3, 4, 5, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_NEIGHBOURHOODS_CITY_CityId",
                table: "NEIGHBOURHOODS",
                column: "CityId",
                principalTable: "CITY",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NEIGHBOURHOODS_CITY_CityId",
                table: "NEIGHBOURHOODS");

            migrationBuilder.DeleteData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DISTRICT",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DISTRICT",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CITY",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NEIGHBOURHOODS",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DISTRICT",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DISTRICT",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DISTRICT",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CITY",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CITY",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "NEIGHBOURHOODS",
                newName: "CITY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_NEIGHBOURHOODS_CityId",
                table: "NEIGHBOURHOODS",
                newName: "IX_NEIGHBOURHOODS_CITY_ID");

            migrationBuilder.AlterColumn<int>(
                name: "CITY_ID",
                table: "NEIGHBOURHOODS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "BRANDS",
                keyColumn: "ID",
                keyValue: 5,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 5,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "PRODUCT_CATEGORIES",
                keyColumn: "ID",
                keyValue: 6,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.UpdateData(
                table: "SELLERS",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_NEIGHBOURHOODS_CITY_CITY_ID",
                table: "NEIGHBOURHOODS",
                column: "CITY_ID",
                principalTable: "CITY",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
