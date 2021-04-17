using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class pettycashbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PettyCashBooks",
                columns: table => new
                {
                    PettyCashBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpeningCash = table.Column<decimal>(type: "money", nullable: false),
                    ClosingCash = table.Column<decimal>(type: "money", nullable: false),
                    SystemSale = table.Column<decimal>(type: "money", nullable: false),
                    TailoringSale = table.Column<decimal>(type: "money", nullable: false),
                    ManualSale = table.Column<decimal>(type: "money", nullable: false),
                    CashReciepts = table.Column<decimal>(type: "money", nullable: false),
                    OhterReceipts = table.Column<decimal>(type: "money", nullable: false),
                    RecieptRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardSwipe = table.Column<decimal>(type: "money", nullable: false),
                    BankDeposit = table.Column<decimal>(type: "money", nullable: false),
                    TotalExpenses = table.Column<decimal>(type: "money", nullable: false),
                    TotalPayments = table.Column<decimal>(type: "money", nullable: false),
                    PaymentRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDuesNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDues = table.Column<decimal>(type: "money", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PettyCashBooks", x => x.PettyCashBookId);
                    table.ForeignKey(
                        name: "FK_PettyCashBooks_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PettyCashBooks_StoreId",
                table: "PettyCashBooks",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PettyCashBooks");
        }
    }
}
