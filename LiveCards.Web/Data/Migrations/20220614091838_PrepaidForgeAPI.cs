using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class PrepaidForgeAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefaultPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<double>(type: "float", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    formattedString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    csvamount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roundedFormattedString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaceValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<double>(type: "float", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    formattedString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    csvamount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roundedFormattedString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAPIDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gtin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faceValueId = table.Column<int>(type: "int", nullable: false),
                    defaultPriceId = table.Column<int>(type: "int", nullable: false),
                    isCurrencyProduct = table.Column<bool>(type: "bit", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    languages2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countries2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    platforms2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    productType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAPIDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAPIDetails_DefaultPrice_defaultPriceId",
                        column: x => x.defaultPriceId,
                        principalTable: "DefaultPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAPIDetails_FaceValue_faceValueId",
                        column: x => x.faceValueId,
                        principalTable: "FaceValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAPIDetails_defaultPriceId",
                table: "ProductAPIDetails",
                column: "defaultPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAPIDetails_faceValueId",
                table: "ProductAPIDetails",
                column: "faceValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAPIDetails");

            migrationBuilder.DropTable(
                name: "DefaultPrice");

            migrationBuilder.DropTable(
                name: "FaceValue");
        }
    }
}
