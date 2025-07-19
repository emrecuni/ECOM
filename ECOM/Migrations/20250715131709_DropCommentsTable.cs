using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class DropCommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMMENTS_CUSTOMERS_CUSTOMER_ID",
                table: "COMMENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_COMMENTS_PRODUCTS_PRODUCT_ID",
                table: "COMMENTS");


            migrationBuilder.RenameTable(
                name: "COMMENTS",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "SCORE",
                table: "Comments",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "COMMENT",
                table: "Comments",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "PRODUCT_ID",
                table: "Comments",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "IMAGE_PATH",
                table: "Comments",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "CUSTOMER_ID",
                table: "Comments",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_COMMENTS_PRODUCT_ID",
                table: "Comments",
                newName: "IX_Comments_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_COMMENTS_CUSTOMER_ID",
                table: "Comments",
                newName: "IX_Comments_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CUSTOMERS_CustomerId",
                table: "Comments",
                column: "CustomerId",
                principalTable: "CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_PRODUCTS_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CUSTOMERS_CustomerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_PRODUCTS_ProductId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "COMMENTS");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "COMMENTS",
                newName: "SCORE");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "COMMENTS",
                newName: "COMMENT");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "COMMENTS",
                newName: "PRODUCT_ID");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "COMMENTS",
                newName: "IMAGE_PATH");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "COMMENTS",
                newName: "CUSTOMER_ID");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "COMMENTS",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProductId",
                table: "COMMENTS",
                newName: "IX_COMMENTS_PRODUCT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerId",
                table: "COMMENTS",
                newName: "IX_COMMENTS_CUSTOMER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COMMENTS",
                table: "COMMENTS",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_COMMENTS_CUSTOMERS_CUSTOMER_ID",
                table: "COMMENTS",
                column: "CUSTOMER_ID",
                principalTable: "CUSTOMERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COMMENTS_PRODUCTS_PRODUCT_ID",
                table: "COMMENTS",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
