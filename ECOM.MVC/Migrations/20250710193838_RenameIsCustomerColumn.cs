using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsCustomerColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCustomer",
                table: "CUSTOMERS",
                newName: "ISCUSTOMER");

            migrationBuilder.AlterColumn<bool>(
                name: "ISCUSTOMER",
                table: "CUSTOMERS",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISCUSTOMER",
                table: "CUSTOMERS",
                newName: "IsCustomer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCustomer",
                table: "CUSTOMERS",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
