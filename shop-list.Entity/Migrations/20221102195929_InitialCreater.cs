using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopList.Entity.Migrations
{
    public partial class InitialCreater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IDUser",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IDBuyer",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "IDProductList",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "IDSalesmen",
                table: "Salesmen");
            migrationBuilder.DropColumn(
                name: "IDProduct",
                table: "Product");
            migrationBuilder.DropColumn(
                name: "IDDiscription",
                table: "Discription");
            migrationBuilder.DropColumn(
                name: "IDProductInStock",
                table: "ProductInStock");

            migrationBuilder.DropColumn(
                name: "IDAdmin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "admin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admin",
                table: "admin",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_admin",
                table: "admin");

            migrationBuilder.RenameTable(
                name: "admin",
                newName: "Admin");

            migrationBuilder.AddColumn<Guid>(
                name: "IDUser",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDBuyer",
                table: "Buyer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDProductInList",
                table: "ProductInList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDSalesmen",
                table: "Salesmen",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDProduct",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDDiscription",
                table: "Discription",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDProductInStock",
                table: "ProductInStock",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDAdmin",
                table: "Admin",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");
        }
    }
}
