using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.API.Migrations
{
    /// <inheritdoc />
    public partial class CanUsedFieldAddedToEmailVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CAN_USED",
                table: "EMAIL_VERIFICATION",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CAN_USED",
                table: "EMAIL_VERIFICATION");
        }
    }
}
