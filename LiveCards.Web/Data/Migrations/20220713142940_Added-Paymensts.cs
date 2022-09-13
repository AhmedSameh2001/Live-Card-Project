using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class AddedPaymensts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Paymensts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExhangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paymensts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentId",
                table: "Agents",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Paymensts_AgentId",
                table: "Agents",
                column: "AgentId",
                principalTable: "Paymensts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Paymensts_AgentId",
                table: "Agents");

            migrationBuilder.DropTable(
                name: "Paymensts");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AgentId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Agents");
        }
    }
}
