using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class NewDBUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "SalaryPayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDyn",
                table: "Receipts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDyn",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDyn",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_StaffAdvanceReceipts_PartyId",
                table: "StaffAdvanceReceipts",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryPayments_PartyId",
                table: "SalaryPayments",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryPayments_Parties_PartyId",
                table: "SalaryPayments",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "PartyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAdvanceReceipts_Parties_PartyId",
                table: "StaffAdvanceReceipts",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "PartyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryPayments_Parties_PartyId",
                table: "SalaryPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffAdvanceReceipts_Parties_PartyId",
                table: "StaffAdvanceReceipts");

            migrationBuilder.DropIndex(
                name: "IX_StaffAdvanceReceipts_PartyId",
                table: "StaffAdvanceReceipts");

            migrationBuilder.DropIndex(
                name: "IX_SalaryPayments_PartyId",
                table: "SalaryPayments");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "SalaryPayments");

            migrationBuilder.DropColumn(
                name: "IsDyn",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "IsDyn",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsDyn",
                table: "Expenses");
        }
    }
}
