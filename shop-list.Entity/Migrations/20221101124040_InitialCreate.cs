using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopList.Entity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDAdmin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDBuyers.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<int>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buyers_user_userlId",
                        column: x => x.ChannelId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegestrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductLustl = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productList_products_productslId",
                        column: x => x.ChannelId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
                 migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSalesmen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salesmen_users_userId",
                        column: x => x.ChannelId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
                 migrationBuilder.CreateTable(
                name: "ProductInStock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductInStock = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "nvarchar(max)", nullable: true),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInStock", x => x.Id);
                });
                 migrationBuilder.CreateTable(
                name: "Discription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDDiscription = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "nvarchar(max)", nullable: true),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discription", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducts = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesmenlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductInStocklId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescriptionlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_salesmens_SalesmenlId",
                        column: x => x.SalesmenId,
                        principalTable: "salesmens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_productInStock_ProductInStockId",
                        column: x => x.ProductInStockId,
                        principalTable: "productInStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_descriptions_DescriptionId",
                        column: x => x.ProductInStockId,
                        principalTable: "description",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);    
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_SalesmenId",
                table: "product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductInStockId",
                table: "product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_description_ProductId",
                table: "product",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");
            migrationBuilder.CreateTable(
                name: "Buyer");
            migrationBuilder.CreateTable(
                name: "User");
            migrationBuilder.CreateTable(
                name: "ProductList");
            migrationBuilder.CreateTable(
                name: "Salesmen");
            migrationBuilder.CreateTable(
                name: "productInStock");
            migrationBuilder.CreateTable(
                name: "Discription");
            migrationBuilder.CreateTable(
                name: "Product");
        }
    }
}
