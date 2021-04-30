using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class DailySalePayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailySales_MixPayments_MixAndCouponPaymentId",
                table: "DailySales");

            migrationBuilder.DropIndex(
                name: "IX_DailySales_MixAndCouponPaymentId",
                table: "DailySales");

            migrationBuilder.DropColumn(
                name: "MixAndCouponPaymentId",
                table: "DailySales");

            migrationBuilder.CreateTable(
                name: "DailySalePayments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    DailySaleId = table.Column<int>(type: "int", nullable: false),
                    InvNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentRefNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySalePayments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_DailySalePayments_DailySales_DailySaleId",
                        column: x => x.DailySaleId,
                        principalTable: "DailySales",
                        principalColumn: "DailySaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailySalePayments_DailySaleId",
                table: "DailySalePayments",
                column: "DailySaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySalePayments");

            migrationBuilder.AddColumn<int>(
                name: "MixAndCouponPaymentId",
                table: "DailySales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_MixAndCouponPaymentId",
                table: "DailySales",
                column: "MixAndCouponPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailySales_MixPayments_MixAndCouponPaymentId",
                table: "DailySales",
                column: "MixAndCouponPaymentId",
                principalTable: "MixPayments",
                principalColumn: "MixAndCouponPaymentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
