using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class AddedZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_ZipCode",
                table: "User_Data",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_ZipCode",
                table: "User_Data");
        }
    }
}
