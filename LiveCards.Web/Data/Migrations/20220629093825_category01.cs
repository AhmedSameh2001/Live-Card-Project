using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class category01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Categories",
                newName: "NameHe");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Categories",
                newName: "NameEn");

            migrationBuilder.AddColumn<bool>(
                name: "ShowInMenu",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInMenu",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "NameHe",
                table: "Categories",
                newName: "LogoUrl");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Categories",
                newName: "Color");
        }
    }
}
