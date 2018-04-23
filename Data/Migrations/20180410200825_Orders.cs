using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ECommerce.Data.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PaymentStatus = table.Column<int>(nullable: false),
                    Placed = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DeliveryAddress_Address1 = table.Column<string>(nullable: false),
                    DeliveryAddress_Address2 = table.Column<string>(nullable: true),
                    DeliveryAddress_County = table.Column<string>(nullable: false),
                    DeliveryAddress_FirstName = table.Column<string>(nullable: false),
                    DeliveryAddress_LastName = table.Column<string>(nullable: false),
                    DeliveryAddress_Postcode = table.Column<string>(nullable: false),
                    DeliveryAddress_TownCity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ColourId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_ProductVariants_ProductId_ColourId_StorageId",
                        columns: x => new { x.ProductId, x.ColourId, x.StorageId },
                        principalTable: "ProductVariants",
                        principalColumns: new[] { "ProductId", "ColourId", "StorageId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId_ColourId_StorageId",
                table: "OrderItem",
                columns: new[] { "ProductId", "ColourId", "StorageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
