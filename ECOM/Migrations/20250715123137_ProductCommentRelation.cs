using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class ProductCommentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMMENTS_PRODUCTS_ID",
                table: "COMMENTS");

            migrationBuilder.RenameColumn(
                name: "ISCUSTOMER",
                table: "CUSTOMERS",
                newName: "IS_CUSTOMER");

            migrationBuilder.AddColumn<string>(
                name: "IMAGE_PATH",
                table: "PRODUCTS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "COMMENTS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_PRODUCT_ID",
                table: "COMMENTS",
                column: "PRODUCT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_COMMENTS_PRODUCTS_PRODUCT_ID",
                table: "COMMENTS",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMMENTS_PRODUCTS_PRODUCT_ID",
                table: "COMMENTS");

            migrationBuilder.DropIndex(
                name: "IX_COMMENTS_PRODUCT_ID",
                table: "COMMENTS");

            migrationBuilder.DropColumn(
                name: "IMAGE_PATH",
                table: "PRODUCTS");

            migrationBuilder.RenameColumn(
                name: "IS_CUSTOMER",
                table: "CUSTOMERS",
                newName: "ISCUSTOMER");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "COMMENTS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_COMMENTS_PRODUCTS_ID",
                table: "COMMENTS",
                column: "ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
