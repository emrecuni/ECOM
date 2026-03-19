using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class EmailVerificationFieldUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ATTEMPT_COUNT",
                table: "EMAIL_VERIFICATION",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PURPOSE",
                table: "EMAIL_VERIFICATION",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATTEMPT_COUNT",
                table: "EMAIL_VERIFICATION");

            migrationBuilder.DropColumn(
                name: "PURPOSE",
                table: "EMAIL_VERIFICATION");
        }
    }
}
