using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertys_Companies_CompanyId",
                table: "Advertys");

            migrationBuilder.DropForeignKey(
                name: "FK_APILogs_Companies_CompanyId",
                table: "APILogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Companies_CompanyId",
                table: "Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Companies_CompanyId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagesCompanies_Companies_CompanyId",
                table: "PackagesCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertys_Categories_CompanyId",
                table: "Advertys",
                column: "CompanyId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_APILogs_Categories_CompanyId",
                table: "APILogs",
                column: "CompanyId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Categories_CompanyId",
                table: "Numbers",
                column: "CompanyId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Categories_CompanyId",
                table: "Packages",
                column: "CompanyId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagesCompanies_Categories_CompanyId",
                table: "PackagesCompanies",
                column: "CompanyId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertys_Categories_CompanyId",
                table: "Advertys");

            migrationBuilder.DropForeignKey(
                name: "FK_APILogs_Categories_CompanyId",
                table: "APILogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Categories_CompanyId",
                table: "Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Categories_CompanyId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagesCompanies_Categories_CompanyId",
                table: "PackagesCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertys_Companies_CompanyId",
                table: "Advertys",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_APILogs_Companies_CompanyId",
                table: "APILogs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Companies_CompanyId",
                table: "Numbers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Companies_CompanyId",
                table: "Packages",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagesCompanies_Companies_CompanyId",
                table: "PackagesCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
