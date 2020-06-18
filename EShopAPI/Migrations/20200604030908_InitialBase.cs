using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShopAPI.Migrations
{
    public partial class InitialBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    MotificationDate = table.Column<DateTime>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ProductSize = table.Column<int>(nullable: false),
                    ProductVarienty = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<double>(nullable: false),
                    ProductStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    MotificationDate = table.Column<DateTime>(nullable: false),
                    SpName = table.Column<string>(nullable: true),
                    SpEmail = table.Column<string>(nullable: false),
                    SpPhone = table.Column<string>(nullable: true),
                    SpAddress = table.Column<string>(nullable: true),
                    SpCity = table.Column<string>(nullable: true),
                    SpState = table.Column<string>(nullable: true),
                    SpZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    MotificationDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    UserPassword = table.Column<string>(maxLength: 200, nullable: false),
                    UserConfirmPassword = table.Column<string>(maxLength: 200, nullable: false),
                    UserPhone = table.Column<int>(nullable: false),
                    UserAddress = table.Column<string>(nullable: true),
                    UserActiveCode = table.Column<string>(nullable: true),
                    UserIsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    MotificationDate = table.Column<DateTime>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: true),
                    OrderTotal = table.Column<double>(nullable: true),
                    OrderStatus = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    SalesPersonId = table.Column<int>(nullable: true),
                    UsersID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_SalesPerson_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "SalesPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    MotificationDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalesPersonId",
                table: "Orders",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsersID",
                table: "Orders",
                column: "UsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SalesPerson");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
