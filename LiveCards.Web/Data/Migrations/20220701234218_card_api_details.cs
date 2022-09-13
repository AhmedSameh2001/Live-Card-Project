using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class card_api_details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Cards",
                newName: "CostUSD");

            migrationBuilder.AddColumn<string>(
                name: "DefaultPriceAmount",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultPriceCurrency",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaceValueAmount",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaceValueCurrency",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "countries",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "platforms",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultPriceAmount",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DefaultPriceCurrency",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FaceValueAmount",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FaceValueCurrency",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "countries",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "platforms",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "CostUSD",
                table: "Cards",
                newName: "Cost");
        }
    }
}
