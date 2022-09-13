using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerInvoices_Dealers_DealerId",
                table: "DealerInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Dealers_DealerId",
                table: "Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageDealers_Dealers_DealerId",
                table: "PackageDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagesCompaniesDealers_Dealers_DealerId",
                table: "PackagesCompaniesDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionBills_Dealers_DealerId",
                table: "SubscriptionBills");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPrices_Dealers_DealerId",
                table: "SubscriptionPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Dealers_DealerId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_DealerId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPrices_DealerId",
                table: "SubscriptionPrices");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionBills_DealerId",
                table: "SubscriptionBills");

            migrationBuilder.DropIndex(
                name: "IX_PackagesCompaniesDealers_DealerId",
                table: "PackagesCompaniesDealers");

            migrationBuilder.DropIndex(
                name: "IX_PackageDealers_DealerId",
                table: "PackageDealers");

            migrationBuilder.DropIndex(
                name: "IX_Numbers_DealerId",
                table: "Numbers");

            migrationBuilder.DropIndex(
                name: "IX_DealerInvoices_DealerId",
                table: "DealerInvoices");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SIMLength",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Companies",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "SubscriptionPrices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "SubscriptionBills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "PackagesCompaniesDealers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "PackageDealers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "Numbers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "DealerInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_DistributorId",
                table: "Subscriptions",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPrices_DistributorId",
                table: "SubscriptionPrices",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionBills_DistributorId",
                table: "SubscriptionBills",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesCompaniesDealers_DistributorId",
                table: "PackagesCompaniesDealers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDealers_DistributorId",
                table: "PackageDealers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_DistributorId",
                table: "Numbers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerInvoices_DistributorId",
                table: "DealerInvoices",
                column: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInvoices_Dealers_DistributorId",
                table: "DealerInvoices",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Dealers_DistributorId",
                table: "Numbers",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageDealers_Dealers_DistributorId",
                table: "PackageDealers",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagesCompaniesDealers_Dealers_DistributorId",
                table: "PackagesCompaniesDealers",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionBills_Dealers_DistributorId",
                table: "SubscriptionBills",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPrices_Dealers_DistributorId",
                table: "SubscriptionPrices",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Dealers_DistributorId",
                table: "Subscriptions",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerInvoices_Dealers_DistributorId",
                table: "DealerInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Dealers_DistributorId",
                table: "Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageDealers_Dealers_DistributorId",
                table: "PackageDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagesCompaniesDealers_Dealers_DistributorId",
                table: "PackagesCompaniesDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionBills_Dealers_DistributorId",
                table: "SubscriptionBills");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPrices_Dealers_DistributorId",
                table: "SubscriptionPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Dealers_DistributorId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_DistributorId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPrices_DistributorId",
                table: "SubscriptionPrices");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionBills_DistributorId",
                table: "SubscriptionBills");

            migrationBuilder.DropIndex(
                name: "IX_PackagesCompaniesDealers_DistributorId",
                table: "PackagesCompaniesDealers");

            migrationBuilder.DropIndex(
                name: "IX_PackageDealers_DistributorId",
                table: "PackageDealers");

            migrationBuilder.DropIndex(
                name: "IX_Numbers_DistributorId",
                table: "Numbers");

            migrationBuilder.DropIndex(
                name: "IX_DealerInvoices_DistributorId",
                table: "DealerInvoices");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "SubscriptionPrices");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "SubscriptionBills");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "PackagesCompaniesDealers");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "PackageDealers");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "DealerInvoices");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SIMLength",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_DealerId",
                table: "Subscriptions",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPrices_DealerId",
                table: "SubscriptionPrices",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionBills_DealerId",
                table: "SubscriptionBills",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesCompaniesDealers_DealerId",
                table: "PackagesCompaniesDealers",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDealers_DealerId",
                table: "PackageDealers",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_DealerId",
                table: "Numbers",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerInvoices_DealerId",
                table: "DealerInvoices",
                column: "DealerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInvoices_Dealers_DealerId",
                table: "DealerInvoices",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Dealers_DealerId",
                table: "Numbers",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageDealers_Dealers_DealerId",
                table: "PackageDealers",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagesCompaniesDealers_Dealers_DealerId",
                table: "PackagesCompaniesDealers",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionBills_Dealers_DealerId",
                table: "SubscriptionBills",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPrices_Dealers_DealerId",
                table: "SubscriptionPrices",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Dealers_DealerId",
                table: "Subscriptions",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");
        }
    }
}
