using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class card_api_details0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddCardToAllAgents",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "languages",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "languages",
                table: "Cards");

            migrationBuilder.AddColumn<bool>(
                name: "AddCardToAllAgents",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
