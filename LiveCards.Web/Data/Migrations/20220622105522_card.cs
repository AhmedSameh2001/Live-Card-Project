using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Packages_PackageId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "PackageDealers");

            migrationBuilder.DropTable(
                name: "PackagesCompaniesDealers");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "PackagesCompanies");

            migrationBuilder.DropTable(
                name: "PackageOffers");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_PackageId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Cards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AgentCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAgent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceCustomer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentCards_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CardId",
                table: "Subscriptions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCards_AgentId",
                table: "AgentCards",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCards_CardId",
                table: "AgentCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Cards_CardId",
                table: "Subscriptions",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Cards_CardId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "AgentCards");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_CardId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "PackageOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Months = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    PackageOfferId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanCutDuringOffer = table.Column<bool>(type: "bit", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GB = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: true),
                    Old_Id = table.Column<int>(type: "int", nullable: true),
                    Prepaid = table.Column<bool>(type: "bit", nullable: true),
                    PriceCustomer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceDealer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceOfferCustomer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceOfferDealer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceOfferShop = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceShop = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SMS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Categories_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Packages_PackageOffers_PackageOfferId",
                        column: x => x.PackageOfferId,
                        principalTable: "PackageOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackagesCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    PackageOfferId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanCutDuringOffer = table.Column<bool>(type: "bit", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: true),
                    Prepaid = table.Column<bool>(type: "bit", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceOffer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SMS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagesCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackagesCompanies_Categories_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PackagesCompanies_PackageOffers_PackageOfferId",
                        column: x => x.PackageOfferId,
                        principalTable: "PackageOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageDealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorId = table.Column<int>(type: "int", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DealerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: true),
                    PriceCostOffer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceCustomer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceCustomerOffer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceDealer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceDealerOffer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceReseller = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageDealers_Agents_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PackageDealers_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackagesCompaniesDealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorId = table.Column<int>(type: "int", nullable: true),
                    PackagesCompanyId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DealerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: true),
                    PackagesCompaniesId = table.Column<int>(type: "int", nullable: true),
                    PriceCostOffer = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagesCompaniesDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackagesCompaniesDealers_Agents_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Agents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PackagesCompaniesDealers_PackagesCompanies_PackagesCompanyId",
                        column: x => x.PackagesCompanyId,
                        principalTable: "PackagesCompanies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PackageId",
                table: "Subscriptions",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDealers_DistributorId",
                table: "PackageDealers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDealers_PackageId",
                table: "PackageDealers",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CompanyId",
                table: "Packages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackageOfferId",
                table: "Packages",
                column: "PackageOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesCompanies_CompanyId",
                table: "PackagesCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesCompanies_PackageOfferId",
                table: "PackagesCompanies",
                column: "PackageOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesCompaniesDealers_DistributorId",
                table: "PackagesCompaniesDealers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesCompaniesDealers_PackagesCompanyId",
                table: "PackagesCompaniesDealers",
                column: "PackagesCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Packages_PackageId",
                table: "Subscriptions",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");
        }
    }
}
