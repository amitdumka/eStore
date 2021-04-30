using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class dsp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "DailySalePayments",
                newName: "DailySalePaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailySalePaymentId",
                table: "DailySalePayments",
                newName: "PaymentId");
        }
    }
}
