using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class AdditionTimeAddedToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ADDITION_TIME",
                table: "CART",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ADDITION_TIME",
                table: "CART");
        }
    }
}
