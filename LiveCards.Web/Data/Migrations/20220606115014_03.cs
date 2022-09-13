using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerBills_Dealers_DistributorId",
                table: "DealerBills");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInvoices_Dealers_DistributorId",
                table: "DealerInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_AspNetUsers_ApplicationUserId",
                table: "Dealers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dealers_Dealers_Distributor1Id",
                table: "Dealers");

            migrationBuilder.DropForeignKey(
                name: "FK_DelearsAdvertys_Dealers_DistributorId",
                table: "DelearsAdvertys");

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

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Dealers_DistributorId",
                table: "UploadedFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dealers",
                table: "Dealers");

            migrationBuilder.DropIndex(
                name: "IX_Dealers_Distributor1Id",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "CompanyGUID",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "CreditChanges",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DataBaseName",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "Distributor1Id",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "IsCompany",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "MaxNegativeCredit",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "NegativeCredit",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "PaymentCycle",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "ShowAPIData",
                table: "Dealers");

            migrationBuilder.RenameTable(
                name: "Dealers",
                newName: "Agents");

            migrationBuilder.RenameColumn(
                name: "Phone2",
                table: "Agents",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "Old_Id",
                table: "Agents",
                newName: "ParentAgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Dealers_ApplicationUserId",
                table: "Agents",
                newName: "IX_Agents_ApplicationUserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Agents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AllowSub",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowLoan",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ProfitPercentage",
                table: "Agents",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ParentAgentId",
                table: "Agents",
                column: "ParentAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Agents_ParentAgentId",
                table: "Agents",
                column: "ParentAgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_AspNetUsers_ApplicationUserId",
                table: "Agents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerBills_Agents_DistributorId",
                table: "DealerBills",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInvoices_Agents_DistributorId",
                table: "DealerInvoices",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DelearsAdvertys_Agents_DistributorId",
                table: "DelearsAdvertys",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Agents_DistributorId",
                table: "Numbers",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageDealers_Agents_DistributorId",
                table: "PackageDealers",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagesCompaniesDealers_Agents_DistributorId",
                table: "PackagesCompaniesDealers",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionBills_Agents_DistributorId",
                table: "SubscriptionBills",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPrices_Agents_DistributorId",
                table: "SubscriptionPrices",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Agents_DistributorId",
                table: "Subscriptions",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Agents_DistributorId",
                table: "UploadedFiles",
                column: "DistributorId",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Agents_ParentAgentId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AspNetUsers_ApplicationUserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerBills_Agents_DistributorId",
                table: "DealerBills");

            migrationBuilder.DropForeignKey(
                name: "FK_DealerInvoices_Agents_DistributorId",
                table: "DealerInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_DelearsAdvertys_Agents_DistributorId",
                table: "DelearsAdvertys");

            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Agents_DistributorId",
                table: "Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageDealers_Agents_DistributorId",
                table: "PackageDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagesCompaniesDealers_Agents_DistributorId",
                table: "PackagesCompaniesDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionBills_Agents_DistributorId",
                table: "SubscriptionBills");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPrices_Agents_DistributorId",
                table: "SubscriptionPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Agents_DistributorId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Agents_DistributorId",
                table: "UploadedFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_ParentAgentId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AllowLoan",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ProfitPercentage",
                table: "Agents");

            migrationBuilder.RenameTable(
                name: "Agents",
                newName: "Dealers");

            migrationBuilder.RenameColumn(
                name: "ParentAgentId",
                table: "Dealers",
                newName: "Old_Id");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Dealers",
                newName: "Phone2");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_ApplicationUserId",
                table: "Dealers",
                newName: "IX_Dealers_ApplicationUserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Dealers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Dealers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "AllowSub",
                table: "Dealers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Dealers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyGUID",
                table: "Dealers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditChanges",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataBaseName",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Distributor1Id",
                table: "Dealers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompany",
                table: "Dealers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Dealers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Dealers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNegativeCredit",
                table: "Dealers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NegativeCredit",
                table: "Dealers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCycle",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowAPIData",
                table: "Dealers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dealers",
                table: "Dealers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_Distributor1Id",
                table: "Dealers",
                column: "Distributor1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerBills_Dealers_DistributorId",
                table: "DealerBills",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerInvoices_Dealers_DistributorId",
                table: "DealerInvoices",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_AspNetUsers_ApplicationUserId",
                table: "Dealers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealers_Dealers_Distributor1Id",
                table: "Dealers",
                column: "Distributor1Id",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DelearsAdvertys_Dealers_DistributorId",
                table: "DelearsAdvertys",
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

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Dealers_DistributorId",
                table: "UploadedFiles",
                column: "DistributorId",
                principalTable: "Dealers",
                principalColumn: "Id");
        }
    }
}
