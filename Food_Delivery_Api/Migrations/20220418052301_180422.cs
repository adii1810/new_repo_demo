using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class _180422 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tempOrder",
                columns: table => new
                {
                    Order_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Date = table.Column<DateTime>(nullable: false),
                    User_DataId = table.Column<int>(nullable: false),
                    ValetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tempOrder", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_tempOrder_User_Data_User_DataId",
                        column: x => x.User_DataId,
                        principalTable: "User_Data",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tempOrder_Valet_ValetId",
                        column: x => x.ValetId,
                        principalTable: "Valet",
                        principalColumn: "Valet_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tempOrder_Detail",
                columns: table => new
                {
                    Order_Detail_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tempOrder_Detail", x => x.Order_Detail_Id);
                    table.ForeignKey(
                        name: "FK_tempOrder_Detail_tempOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tempOrder",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tempOrder_Detail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tempOrder_User_DataId",
                table: "tempOrder",
                column: "User_DataId");

            migrationBuilder.CreateIndex(
                name: "IX_tempOrder_ValetId",
                table: "tempOrder",
                column: "ValetId");

            migrationBuilder.CreateIndex(
                name: "IX_tempOrder_Detail_OrderId",
                table: "tempOrder_Detail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tempOrder_Detail_ProductId",
                table: "tempOrder_Detail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tempOrder_Detail");

            migrationBuilder.DropTable(
                name: "tempOrder");
        }
    }
}
