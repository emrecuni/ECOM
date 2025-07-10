using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECOM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANDS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENDER = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TABLE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OLD_VALUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NEW_VALUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROCESS_TYPE = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    PROCESS_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TYPE = table.Column<bool>(type: "bit", nullable: false),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "S_COUPONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LOWER_LIMIT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VALIDITY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_COUPONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SELLERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCORE = table.Column<float>(type: "real", nullable: true),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SELLERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DISTRICT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CITY_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTRICT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DISTRICT_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CARDS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    CARD_NO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CARDS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "D_COUPONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_COUPON_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: true),
                    DEFINITION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_COUPONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_D_COUPONS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_D_COUPONS_S_COUPONS_S_COUPON_ID",
                        column: x => x.S_COUPON_ID,
                        principalTable: "S_COUPONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BRAND_ID = table.Column<int>(type: "int", nullable: false),
                    SUP_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    SELLER_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SCORE = table.Column<float>(type: "real", nullable: true),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BRANDS_BRAND_ID",
                        column: x => x.BRAND_ID,
                        principalTable: "BRANDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRODUCT_CATEGORIES_SUB_CATEGORY_ID",
                        column: x => x.SUB_CATEGORY_ID,
                        principalTable: "PRODUCT_CATEGORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRODUCT_CATEGORIES_SUP_CATEGORY_ID",
                        column: x => x.SUP_CATEGORY_ID,
                        principalTable: "PRODUCT_CATEGORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_SELLERS_SELLER_ID",
                        column: x => x.SELLER_ID,
                        principalTable: "SELLERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NEIGHBOURHOODS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CITY_ID = table.Column<int>(type: "int", nullable: false),
                    DISTRICT_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEIGHBOURHOODS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NEIGHBOURHOODS_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NEIGHBOURHOODS_DISTRICT_DISTRICT_ID",
                        column: x => x.DISTRICT_ID,
                        principalTable: "DISTRICT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CART",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    SELLER_ID = table.Column<int>(type: "int", nullable: false),
                    DCOUPON_ID = table.Column<int>(type: "int", nullable: true),
                    PIECE = table.Column<int>(type: "int", nullable: true),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CART", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CART_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CART_D_COUPONS_DCOUPON_ID",
                        column: x => x.DCOUPON_ID,
                        principalTable: "D_COUPONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CART_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CART_SELLERS_SELLER_ID",
                        column: x => x.SELLER_ID,
                        principalTable: "SELLERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGE_PATH = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMMENTS_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMMENTS_PRODUCTS_ID",
                        column: x => x.ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAVORITES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORITES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FAVORITES_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAVORITES_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    CARD_ID = table.Column<int>(type: "int", nullable: false),
                    SELLER_ID = table.Column<int>(type: "int", nullable: false),
                    PIECE = table.Column<int>(type: "int", nullable: true),
                    ORDER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_HISTORY_CARDS_CARD_ID",
                        column: x => x.CARD_ID,
                        principalTable: "CARDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDER_HISTORY_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDER_HISTORY_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDER_HISTORY_SELLERS_SELLER_ID",
                        column: x => x.SELLER_ID,
                        principalTable: "SELLERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ADDRESS_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITY_ID = table.Column<int>(type: "int", nullable: false),
                    DISTRICT_ID = table.Column<int>(type: "int", nullable: false),
                    NEIGHBOURHOOD_ID = table.Column<int>(type: "int", nullable: false),
                    RECEIVER_ID = table.Column<int>(type: "int", nullable: false),
                    ADDITION_TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_CUSTOMERS_RECEIVER_ID",
                        column: x => x.RECEIVER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_DISTRICT_DISTRICT_ID",
                        column: x => x.DISTRICT_ID,
                        principalTable: "DISTRICT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_NEIGHBOURHOODS_NEIGHBOURHOOD_ID",
                        column: x => x.NEIGHBOURHOOD_ID,
                        principalTable: "NEIGHBOURHOODS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_CITY_ID",
                table: "ADDRESSES",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_CUSTOMER_ID",
                table: "ADDRESSES",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_DISTRICT_ID",
                table: "ADDRESSES",
                column: "DISTRICT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_NEIGHBOURHOOD_ID",
                table: "ADDRESSES",
                column: "NEIGHBOURHOOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_RECEIVER_ID",
                table: "ADDRESSES",
                column: "RECEIVER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARDS_CUSTOMER_ID",
                table: "CARDS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_CUSTOMER_ID",
                table: "CART",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_DCOUPON_ID",
                table: "CART",
                column: "DCOUPON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_PRODUCT_ID",
                table: "CART",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_SELLER_ID",
                table: "CART",
                column: "SELLER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_CUSTOMER_ID",
                table: "COMMENTS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_D_COUPONS_CUSTOMER_ID",
                table: "D_COUPONS",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_D_COUPONS_S_COUPON_ID",
                table: "D_COUPONS",
                column: "S_COUPON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DISTRICT_CITY_ID",
                table: "DISTRICT",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORITES_CUSTOMER_ID",
                table: "FAVORITES",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORITES_PRODUCT_ID",
                table: "FAVORITES",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NEIGHBOURHOODS_CITY_ID",
                table: "NEIGHBOURHOODS",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NEIGHBOURHOODS_DISTRICT_ID",
                table: "NEIGHBOURHOODS",
                column: "DISTRICT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_HISTORY_CARD_ID",
                table: "ORDER_HISTORY",
                column: "CARD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_HISTORY_CUSTOMER_ID",
                table: "ORDER_HISTORY",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_HISTORY_PRODUCT_ID",
                table: "ORDER_HISTORY",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_HISTORY_SELLER_ID",
                table: "ORDER_HISTORY",
                column: "SELLER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_BRAND_ID",
                table: "PRODUCTS",
                column: "BRAND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SELLER_ID",
                table: "PRODUCTS",
                column: "SELLER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SUB_CATEGORY_ID",
                table: "PRODUCTS",
                column: "SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SUP_CATEGORY_ID",
                table: "PRODUCTS",
                column: "SUP_CATEGORY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "CART");

            migrationBuilder.DropTable(
                name: "COMMENTS");

            migrationBuilder.DropTable(
                name: "FAVORITES");

            migrationBuilder.DropTable(
                name: "LOG");

            migrationBuilder.DropTable(
                name: "ORDER_HISTORY");

            migrationBuilder.DropTable(
                name: "NEIGHBOURHOODS");

            migrationBuilder.DropTable(
                name: "D_COUPONS");

            migrationBuilder.DropTable(
                name: "CARDS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "DISTRICT");

            migrationBuilder.DropTable(
                name: "S_COUPONS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "BRANDS");

            migrationBuilder.DropTable(
                name: "PRODUCT_CATEGORIES");

            migrationBuilder.DropTable(
                name: "SELLERS");

            migrationBuilder.DropTable(
                name: "CITY");
        }
    }
}
