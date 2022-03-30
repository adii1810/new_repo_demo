using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Rating_Product_ProductId",
                table: "User_Rating");

            migrationBuilder.DropIndex(
                name: "IX_User_Rating_ProductId",
                table: "User_Rating");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "User_Rating");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "User_Rating");

            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "User_Rating",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "User_Rating",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UId",
                table: "User_Rating",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_Rating_Product_Id",
                table: "User_Rating",
                column: "Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Rating_Product_Product_Id",
                table: "User_Rating",
                column: "Product_Id",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Rating_Product_Product_Id",
                table: "User_Rating");

            migrationBuilder.DropIndex(
                name: "IX_User_Rating_Product_Id",
                table: "User_Rating");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "User_Rating");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "User_Rating");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "User_Rating");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User_Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "User_Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_Rating_ProductId",
                table: "User_Rating",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Rating_Product_ProductId",
                table: "User_Rating",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
