using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User_Rating");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "User_Rating",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "User_Rating");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "User_Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
