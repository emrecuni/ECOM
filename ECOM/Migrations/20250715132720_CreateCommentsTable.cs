using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class CreateCommentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1,1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCORE = table.Column<int>(type: "int", nullable: true),
                    IMAGE_PATH = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMNETS", x => x.ID);

                    table.ForeignKey(
                        name: "FK_COMMENTS_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_COMMENTS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        onDelete: ReferentialAction.Restrict);

                });

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_PRODUCT_ID",
                table: "COMMENTS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_CUSTOMER_ID",
                table: "COMMENTS",
                column: "CUSTOMER_ID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMMENTS");
        }
    }
}
