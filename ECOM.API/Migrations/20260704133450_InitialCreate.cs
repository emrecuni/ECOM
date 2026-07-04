using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECOM.API.Migrations
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
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GENDER = table.Column<bool>(type: "bit", nullable: true),
                    IS_CUSTOMER = table.Column<bool>(type: "bit", nullable: true),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMAIL_VERIFICATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CODE_HASH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EXPIRED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_USED = table.Column<bool>(type: "bit", nullable: false),
                    CAN_USED = table.Column<bool>(type: "bit", nullable: false),
                    ATTEMPT_COUNT = table.Column<int>(type: "int", nullable: false),
                    PURPOSE = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMAIL_VERIFICATION", x => x.ID);
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
                name: "PAYMENT_SESSIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONVERSATION_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOKEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    EXPECTED_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PROCESSED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessingStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT_SESSIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TYPE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
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
                    NAME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SCORE = table.Column<float>(type: "real", nullable: true),
                    IMAGE_PATH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    DISTRICT_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIP_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEIGHBOURHOODS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NEIGHBOURHOODS_CITY_CityId",
                        column: x => x.CityId,
                        principalTable: "CITY",
                        principalColumn: "ID");
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
                    PIECE = table.Column<int>(type: "int", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCORE = table.Column<int>(type: "int", nullable: false),
                    IMAGE_PATH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_COMMENTS_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
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
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CARD_ID = table.Column<int>(type: "int", nullable: true),
                    SELLER_ID = table.Column<int>(type: "int", nullable: false),
                    CART_ID = table.Column<int>(type: "int", nullable: true),
                    PIECE = table.Column<int>(type: "int", nullable: true),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
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
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.InsertData(
                table: "BRANDS",
                columns: new[] { "ID", "CREATED_AT", "NAME" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung" },
                    { 2, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple" },
                    { 3, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sony" },
                    { 4, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "LG" },
                    { 5, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "CITY",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "İstanbul" },
                    { 2, "Ankara" },
                    { 3, "İzmir" }
                });

            migrationBuilder.InsertData(
                table: "CUSTOMERS",
                columns: new[] { "ID", "BIRTHDATE", "CREATED_AT", "EMAIL", "GENDER", "IS_CUSTOMER", "NAME", "PASSWORD", "PHONE", "SURNAME", "UPDATED_AT" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@gmail.com", true, true, "Ahmet", "gDdBkms2Z3g8T43jHKcphA==$lBOYfNxnf13JEUqZLLvgQ7ytu3NoYySvUOcQGSOd1PI=$3.32768.2", "05321234567", "Yılmaz", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.kaya@gmail.com", false, true, "Ayşe", "HlfQh6k799FJUKAnqBVKgA==$jb8mRVf3nPXxaJbKua8tTNncbhmK1WsnOLIjsGc/Rww=$3.32768.2", "05339876543", "Kaya", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1988, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.demir@hotmail.com", true, true, "Mehmet", "8ljtPIZfCw9rZDKIHLlSQA==$1vK4aLmq9qDA4o/am0VuGPUZNz6lnnRQGtj+0wYMWhY=$3.32768.2", "05453456789", "Demir", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_CATEGORIES",
                columns: new[] { "ID", "CREATED_AT", "NAME", "TYPE" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elektronik", false },
                    { 2, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Telefon", false },
                    { 3, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilgisayar", false },
                    { 4, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Televizyon", false },
                    { 5, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ses Sistemleri", false },
                    { 6, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Küçük Ev Aletleri", false }
                });

            migrationBuilder.InsertData(
                table: "SELLERS",
                columns: new[] { "ID", "CREATED_AT", "NAME", "SCORE" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TechStore", null },
                    { 2, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ElektroMarket", null },
                    { 3, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "DigiShop", null }
                });

            migrationBuilder.InsertData(
                table: "CARDS",
                columns: new[] { "ID", "CVV", "CARD_NO", "CREATED_AT", "CUSTOMER_ID", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "000", "4111111111111111", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "12/26" },
                    { 2, "000", "5500000000000004", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "08/27" },
                    { 3, "000", "3714496353984312", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "05/26" }
                });

            migrationBuilder.InsertData(
                table: "DISTRICT",
                columns: new[] { "ID", "CITY_ID", "NAME" },
                values: new object[,]
                {
                    { 1, 1, "Kadıköy" },
                    { 2, 1, "Beşiktaş" },
                    { 3, 1, "Üsküdar" },
                    { 4, 2, "Çankaya" },
                    { 5, 3, "Konak" }
                });

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "ID", "BRAND_ID", "CREATED_AT", "DESCRIPTION", "IMAGE_PATH", "NAME", "PRICE", "SCORE", "SELLER_ID", "SUB_CATEGORY_ID", "SUP_CATEGORY_ID" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A17 Pro çip, 48MP kamera sistemi ve titanyum tasarım ile güçlü bir akıllı telefon.", "/images/products/iphone15pro.jpg", "Apple iPhone 15 Pro", 54999.99m, 4.8f, 1, 2, 1 },
                    { 2, 1, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snapdragon 8 Gen 3 işlemci, 200MP kamera ve dahili S Pen ile üst segment deneyimi.", "/images/products/s24ultra.jpg", "Samsung Galaxy S24 Ultra", 49999.99m, 4.7f, 2, 2, 1 },
                    { 3, 5, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leica kamera ortaklığı, 5000mAh batarya ve 144Hz AMOLED ekran.", "/images/products/xiaomi14tpro.jpg", "Xiaomi 14T Pro", 24999.99m, 4.5f, 3, 2, 1 },
                    { 4, 2, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "M3 çip, 13.6 inç Liquid Retina ekran ve 18 saate kadar pil ömrü.", "/images/products/macbookairm3.jpg", "Apple MacBook Air M3", 44999.99m, 4.9f, 1, 3, 1 },
                    { 5, 1, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core Ultra 7 işlemci, 14 inç AMOLED ekran ve hafif alüminyum gövde.", "/images/products/galaxybook4pro.jpg", "Samsung Galaxy Book4 Pro", 38999.99m, 4.4f, 2, 3, 1 },
                    { 6, 1, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neo Quantum işlemci, Mini LED arka aydınlatma ve Dolby Atmos ses desteği.", "/images/products/samsungneqled65.jpg", "Samsung Neo QLED 4K 65\"", 34999.99m, 4.6f, 3, 4, 1 },
                    { 7, 4, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "OLED evo panel, α9 AI işlemci ve webOS 24 ile sinema kalitesi deneyim.", "/images/products/lgoled c4.jpg", "LG OLED C4 55\"", 29999.99m, 4.8f, 1, 4, 1 },
                    { 8, 3, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sektörün en iyi gürültü engelleme teknolojisi, 30 saat pil ömrü ve katlanabilir tasarım.", "/images/products/sonywh1000xm5.jpg", "Sony WH-1000XM5", 9999.99m, 4.9f, 2, 5, 1 },
                    { 9, 2, new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aktif gürültü engelleme, Adaptif Ses ve H2 çip ile mükemmel ses deneyimi.", "/images/products/airpodspro2.jpg", "Apple AirPods Pro 2", 8499.99m, 4.7f, 3, 5, 1 },
                    { 10, 5, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "OLED ekran, HEPA filtre ve Mi Home uygulaması ile akıllı hava temizleyici.", "/images/products/xiaomipurifier4pro.jpg", "Xiaomi Smart Air Purifier 4 Pro", 3499.99m, 4.3f, 1, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "CART",
                columns: new[] { "ID", "CREATED_AT", "CUSTOMER_ID", "DCOUPON_ID", "ENABLE", "PIECE", "PRODUCT_ID", "SELLER_ID", "TOTAL_PRICE", "UPDATED_AT" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, true, 1, 1, 1, 54999.99m, null },
                    { 2, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, true, 1, 3, 3, 24999.99m, null },
                    { 3, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, true, 2, 8, 2, 19999.98m, null },
                    { 4, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, true, 1, 4, 1, 40499.99m, null },
                    { 5, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, true, 1, 7, 1, 29999.99m, null },
                    { 6, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, true, 3, 9, 3, 25499.97m, null },
                    { 7, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false, 1, 2, 2, 49999.99m, null },
                    { 8, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, false, 2, 10, 1, 6299.98m, null }
                });

            migrationBuilder.InsertData(
                table: "COMMENTS",
                columns: new[] { "ID", "COMMENT", "CREATED_AT", "CUSTOMER_ID", "IMAGE_PATH", "PRODUCT_ID", "SCORE" },
                values: new object[,]
                {
                    { 1, "Great product! Highly recommend.", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, 5 },
                    { 2, "Not bad! Recommend.", new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 1, 3 },
                    { 3, "Wonderful! Highly recommend.", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 1, 5 },
                    { 4, "Recommend.", new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITES",
                columns: new[] { "ID", "CREATED_AT", "CUSTOMER_ID", "PRODUCT_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "NEIGHBOURHOODS",
                columns: new[] { "ID", "CityId", "DISTRICT_ID", "NAME", "ZIP_CODE" },
                values: new object[,]
                {
                    { 1, null, 1, "Moda", null },
                    { 2, null, 1, "Göztepe", null },
                    { 3, null, 2, "Levent", null },
                    { 4, null, 2, "Etiler", null },
                    { 5, null, 4, "Kızılay", null }
                });

            migrationBuilder.InsertData(
                table: "ORDER_HISTORY",
                columns: new[] { "ID", "CARD_ID", "CART_ID", "CUSTOMER_ID", "DELIVERY_DATE", "ORDER_DATE", "PIECE", "PRODUCT_ID", "SELLER_ID", "STATUS", "TOTAL_PRICE" },
                values: new object[,]
                {
                    { 1, 1, null, 1, new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 0, 54999.99m },
                    { 2, 1, null, 1, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, 2, 0, 9999.99m },
                    { 3, 2, 4, 2, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 1, 0, 40499.99m },
                    { 4, 2, null, 2, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9, 3, 0, 16999.98m },
                    { 5, 3, 5, 3, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, 1, 0, 29999.99m },
                    { 6, 3, null, 3, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3, 0, 24999.99m },
                    { 7, 1, null, 1, null, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, 3, 0, 34999.99m },
                    { 8, 2, 8, 2, null, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, 1, 0, 6299.98m }
                });

            migrationBuilder.InsertData(
                table: "ADDRESSES",
                columns: new[] { "ID", "ADDRESS", "ADDRESS_NAME", "CITY_ID", "CREATED_AT", "CUSTOMER_ID", "DISTRICT_ID", "NEIGHBOURHOOD_ID", "RECEIVER_ID", "UPDATED_AT" },
                values: new object[,]
                {
                    { 1, "Moda Cad. No:12 D:3", "Ev", 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 1, null },
                    { 2, "Levent Mah. Büyükdere Cad. No:45 Kat:7", "İş yeri", 1, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 1, null },
                    { 3, "Fenerbahçe Mah. Bağdat Cad. No:78", "Ev", 1, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 2, null },
                    { 4, "Etiler Mah. Nisbetiye Cad. No:5 D:8", "Annem", 1, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 4, 3, null },
                    { 5, "Kızılay Mah. Atatürk Bulvarı No:101 D:2", "Ev", 2, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 5, 3, null }
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
                name: "IX_COMMENTS_PRODUCT_ID",
                table: "COMMENTS",
                column: "PRODUCT_ID");

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
                name: "IX_NEIGHBOURHOODS_CityId",
                table: "NEIGHBOURHOODS",
                column: "CityId");

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
                name: "IX_PRODUCTS_DESCRIPTION",
                table: "PRODUCTS",
                column: "DESCRIPTION");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_NAME",
                table: "PRODUCTS",
                column: "NAME");

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
                name: "EMAIL_VERIFICATION");

            migrationBuilder.DropTable(
                name: "FAVORITES");

            migrationBuilder.DropTable(
                name: "LOG");

            migrationBuilder.DropTable(
                name: "ORDER_HISTORY");

            migrationBuilder.DropTable(
                name: "PAYMENT_SESSIONS");

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
