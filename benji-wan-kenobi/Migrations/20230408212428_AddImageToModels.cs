using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace benji_wan_kenobi.Migrations
{
    public partial class AddImageToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Characters");
        }
    }
}
