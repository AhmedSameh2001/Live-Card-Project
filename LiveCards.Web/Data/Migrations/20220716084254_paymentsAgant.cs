using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveCards.Data.Migrations
{
    public partial class paymentsAgant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Payments_AgentId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_AgentId",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AgentId",
                table: "Payments",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AgentId",
                table: "Payment",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Agents_AgentId",
                table: "Payment",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Agents_AgentId",
                table: "Payments",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Agents_AgentId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Agents_AgentId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_AgentId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payment_AgentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentId",
                table: "Agents",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Payments_AgentId",
                table: "Agents",
                column: "AgentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
