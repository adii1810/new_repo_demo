using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class _180422of2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_tempOrder_Valet_ValetId",
                table: "tempOrder");

            migrationBuilder.AlterColumn<int>(
                name: "ValetId",
                table: "tempOrder",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ValetId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order",
                column: "ValetId",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tempOrder_Valet_ValetId",
                table: "tempOrder",
                column: "ValetId",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_tempOrder_Valet_ValetId",
                table: "tempOrder");

            migrationBuilder.AlterColumn<int>(
                name: "ValetId",
                table: "tempOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ValetId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Valet_ValetId",
                table: "Order",
                column: "ValetId",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tempOrder_Valet_ValetId",
                table: "tempOrder",
                column: "ValetId",
                principalTable: "Valet",
                principalColumn: "Valet_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
