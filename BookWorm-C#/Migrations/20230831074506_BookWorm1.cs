using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm_C_.Migrations
{
    /// <inheritdoc />
    public partial class BookWorm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeMasters",
                columns: table => new
                {
                    AttributeMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeMasters", x => x.AttributeMasterId);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiarys",
                columns: table => new
                {
                    BeneficiaryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenAccNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenAccType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenBankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benifsc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benpan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarys", x => x.BeneficiaryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPremium = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremiumDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTables",
                columns: table => new
                {
                    InvoiceTableId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTables", x => x.InvoiceTableId);
                    table.ForeignKey(
                        name: "FK_InvoiceTables_Customers_CustId",
                        column: x => x.CustId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Languages_ProductTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLibrary = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    IsRentable = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MinRentDays = table.Column<double>(type: "float", nullable: false),
                    ProductAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductBasePrice = table.Column<double>(type: "float", nullable: false),
                    ProductDescriptionLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescriptionShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Productisbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductOffPriceExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductOfferPrice = table.Column<double>(type: "float", nullable: false),
                    ProductSpCost = table.Column<double>(type: "float", nullable: false),
                    RentPerDay = table.Column<double>(type: "float", nullable: false),
                    ProductGenre = table.Column<long>(type: "bigint", nullable: true),
                    ProductLang = table.Column<long>(type: "bigint", nullable: true),
                    ProductPublisher = table.Column<long>(type: "bigint", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGenreNavigationGenreId = table.Column<long>(type: "bigint", nullable: true),
                    ProductLangNavigationLanguageId = table.Column<long>(type: "bigint", nullable: true),
                    ProductPublisherNavigationPublisherId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Genres_ProductGenreNavigationGenreId",
                        column: x => x.ProductGenreNavigationGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId");
                    table.ForeignKey(
                        name: "FK_Products_Languages_ProductLangNavigationLanguageId",
                        column: x => x.ProductLangNavigationLanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId");
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId");
                    table.ForeignKey(
                        name: "FK_Products_Publishers_ProductPublisherNavigationPublisherId",
                        column: x => x.ProductPublisherNavigationPublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    ProductProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerCustomerId",
                        column: x => x.CustomerCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductProductId",
                        column: x => x.ProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RentNoOfDays = table.Column<int>(type: "int", nullable: false),
                    TranType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceTables_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "InvoiceTables",
                        principalColumn: "InvoiceTableId");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "MyShelves",
                columns: table => new
                {
                    MyShelfId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ProductExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TranType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyShelves", x => x.MyShelfId);
                    table.ForeignKey(
                        name: "FK_MyShelves_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_MyShelves_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    ProductAttributeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    AttributeMastersAttributeMasterId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.ProductAttributeId);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_AttributeMasters_AttributeMastersAttributeMasterId",
                        column: x => x.AttributeMastersAttributeMasterId,
                        principalTable: "AttributeMasters",
                        principalColumn: "AttributeMasterId");
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductBens",
                columns: table => new
                {
                    ProductBenId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdBenPercentage = table.Column<double>(type: "float", nullable: false),
                    ProdBenBenId = table.Column<long>(type: "bigint", nullable: true),
                    ProdBenProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBens", x => x.ProductBenId);
                    table.ForeignKey(
                        name: "FK_ProductBens_Beneficiarys_ProdBenBenId",
                        column: x => x.ProdBenBenId,
                        principalTable: "Beneficiarys",
                        principalColumn: "BeneficiaryId");
                    table.ForeignKey(
                        name: "FK_ProductBens_Products_ProdBenProductId",
                        column: x => x.ProdBenProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "RoyaltyCalculations",
                columns: table => new
                {
                    RoyaltyCalculationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasePrice = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    RoyaltyOnBasePrice = table.Column<double>(type: "float", nullable: false),
                    RoycalTrandate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    TranType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenId = table.Column<long>(type: "bigint", nullable: true),
                    RoyaltyId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoyaltyCalculations", x => x.RoyaltyCalculationId);
                    table.ForeignKey(
                        name: "FK_RoyaltyCalculations_Beneficiarys_BenId",
                        column: x => x.BenId,
                        principalTable: "Beneficiarys",
                        principalColumn: "BeneficiaryId");
                    table.ForeignKey(
                        name: "FK_RoyaltyCalculations_InvoiceTables_RoyaltyId",
                        column: x => x.RoyaltyId,
                        principalTable: "InvoiceTables",
                        principalColumn: "InvoiceTableId");
                    table.ForeignKey(
                        name: "FK_RoyaltyCalculations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerCustomerId",
                table: "Carts",
                column: "CustomerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductProductId",
                table: "Carts",
                column: "ProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_LanguageId",
                table: "Genres",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTables_CustId",
                table: "InvoiceTables",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_TypeId",
                table: "Languages",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MyShelves_CustomerId",
                table: "MyShelves",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MyShelves_ProductId",
                table: "MyShelves",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_AttributeMastersAttributeMasterId",
                table: "ProductAttributes",
                column: "AttributeMastersAttributeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBens_ProdBenBenId",
                table: "ProductBens",
                column: "ProdBenBenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBens_ProdBenProductId",
                table: "ProductBens",
                column: "ProdBenProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGenreNavigationGenreId",
                table: "Products",
                column: "ProductGenreNavigationGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductLangNavigationLanguageId",
                table: "Products",
                column: "ProductLangNavigationLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductPublisherNavigationPublisherId",
                table: "Products",
                column: "ProductPublisherNavigationPublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_BenId",
                table: "RoyaltyCalculations",
                column: "BenId");

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_ProductId",
                table: "RoyaltyCalculations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RoyaltyCalculations_RoyaltyId",
                table: "RoyaltyCalculations",
                column: "RoyaltyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "MyShelves");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductBens");

            migrationBuilder.DropTable(
                name: "RoyaltyCalculations");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "AttributeMasters");

            migrationBuilder.DropTable(
                name: "Beneficiarys");

            migrationBuilder.DropTable(
                name: "InvoiceTables");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
