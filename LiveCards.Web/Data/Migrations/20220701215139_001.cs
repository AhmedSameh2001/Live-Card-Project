using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAPIStock",
                table: "ProductAPIStock");

            migrationBuilder.RenameTable(
                name: "ProductAPIStock",
                newName: "ProductAPIStocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAPIStocks",
                table: "ProductAPIStocks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Temp_PrepaidForgeStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp_PrepaidForgeStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temp_ProductAPIDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gtin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    faceValueId = table.Column<int>(type: "int", nullable: false),
                    defaultPriceId = table.Column<int>(type: "int", nullable: false),
                    isCurrencyProduct = table.Column<bool>(type: "bit", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    languages2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countries2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    platforms2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false),
                    productType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp_ProductAPIDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temp_ProductAPIDetails_DefaultPrice_defaultPriceId",
                        column: x => x.defaultPriceId,
                        principalTable: "DefaultPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temp_ProductAPIDetails_FaceValue_faceValueId",
                        column: x => x.faceValueId,
                        principalTable: "FaceValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temp_ProductAPIDetails_defaultPriceId",
                table: "Temp_ProductAPIDetails",
                column: "defaultPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Temp_ProductAPIDetails_faceValueId",
                table: "Temp_ProductAPIDetails",
                column: "faceValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temp_PrepaidForgeStocks");

            migrationBuilder.DropTable(
                name: "Temp_ProductAPIDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAPIStocks",
                table: "ProductAPIStocks");

            migrationBuilder.RenameTable(
                name: "ProductAPIStocks",
                newName: "ProductAPIStock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAPIStock",
                table: "ProductAPIStock",
                column: "Id");
        }
    }
}
