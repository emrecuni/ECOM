using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class CouponTablesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CODE",
                table: "S_COUPONS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ENABLE",
                table: "D_COUPONS",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CODE",
                table: "S_COUPONS");

            migrationBuilder.AlterColumn<bool>(
                name: "ENABLE",
                table: "D_COUPONS",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
