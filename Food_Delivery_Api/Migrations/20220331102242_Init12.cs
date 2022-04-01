using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Delivery_Api.Migrations
{
    public partial class Init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status_by_Admin",
                table: "Restaurant_Detail",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status_by_Admin",
                table: "Restaurant_Detail");
        }
    }
}
