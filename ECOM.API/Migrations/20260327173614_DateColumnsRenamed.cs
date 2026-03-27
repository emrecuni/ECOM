using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class DateColumnsRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "SELLERS",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "PRODUCTS",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "PRODUCT_CATEGORIES",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "FAVORITES",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "CUSTOMERS",
                newName: "UPDATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "CART",
                newName: "UPDATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "CARDS",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "BRANDS",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "ADDITION_TIME",
                table: "ADDRESSES",
                newName: "UPDATED_AT");

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "CUSTOMERS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "COMMENTS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "CART",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "ADDRESSES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CREATED_AT", "UPDATED_AT" },
                values: new object[] { new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 1,
                column: "CREATED_AT",
                value: new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 2,
                column: "CREATED_AT",
                value: new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 3,
                column: "CREATED_AT",
                value: new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "COMMENTS",
                keyColumn: "ID",
                keyValue: 4,
                column: "CREATED_AT",
                value: new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "CUSTOMERS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "COMMENTS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "CART");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "ADDRESSES");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "SELLERS",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "PRODUCTS",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "PRODUCT_CATEGORIES",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "FAVORITES",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "CUSTOMERS",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "CART",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "CARDS",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "BRANDS",
                newName: "ADDITION_TIME");

            migrationBuilder.RenameColumn(
                name: "UPDATED_AT",
                table: "ADDRESSES",
                newName: "ADDITION_TIME");

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ADDRESSES",
                keyColumn: "ID",
                keyValue: 5,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 1,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 2,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 3,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 4,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 5,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 6,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 7,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CART",
                keyColumn: "ID",
                keyValue: 8,
                column: "ADDITION_TIME",
                value: new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
