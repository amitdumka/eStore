using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class DailySalePaymentsSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "PointRedeemeds",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "CouponPayments",
                newName: "UserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "PointRedeemeds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PointRedeemeds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "PointRedeemeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailySaleId",
                table: "MixPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LinkInfo",
                table: "DailySalePayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "CouponPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "CouponPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "CouponPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BankPayments",
                columns: table => new
                {
                    BankPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    DailySaleId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankPayments", x => x.BankPaymentId);
                    table.ForeignKey(
                        name: "FK_BankPayments_DailySales_DailySaleId",
                        column: x => x.DailySaleId,
                        principalTable: "DailySales",
                        principalColumn: "DailySaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankPayments_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WalletPayments",
                columns: table => new
                {
                    WalletPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletType = table.Column<int>(type: "int", nullable: false),
                    CustomerMobileNoRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    DailySaleId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletPayments", x => x.WalletPaymentId);
                    table.ForeignKey(
                        name: "FK_WalletPayments_DailySales_DailySaleId",
                        column: x => x.DailySaleId,
                        principalTable: "DailySales",
                        principalColumn: "DailySaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletPayments_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointRedeemeds_StoreId",
                table: "PointRedeemeds",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MixPayments_DailySaleId",
                table: "MixPayments",
                column: "DailySaleId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponPayments_StoreId",
                table: "CouponPayments",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPayments_DailySaleId",
                table: "BankPayments",
                column: "DailySaleId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPayments_StoreId",
                table: "BankPayments",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletPayments_DailySaleId",
                table: "WalletPayments",
                column: "DailySaleId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletPayments_StoreId",
                table: "WalletPayments",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponPayments_Stores_StoreId",
                table: "CouponPayments",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MixPayments_DailySales_DailySaleId",
                table: "MixPayments",
                column: "DailySaleId",
                principalTable: "DailySales",
                principalColumn: "DailySaleId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PointRedeemeds_Stores_StoreId",
                table: "PointRedeemeds",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponPayments_Stores_StoreId",
                table: "CouponPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_MixPayments_DailySales_DailySaleId",
                table: "MixPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PointRedeemeds_Stores_StoreId",
                table: "PointRedeemeds");

            migrationBuilder.DropTable(
                name: "BankPayments");

            migrationBuilder.DropTable(
                name: "WalletPayments");

            migrationBuilder.DropIndex(
                name: "IX_PointRedeemeds_StoreId",
                table: "PointRedeemeds");

            migrationBuilder.DropIndex(
                name: "IX_MixPayments_DailySaleId",
                table: "MixPayments");

            migrationBuilder.DropIndex(
                name: "IX_CouponPayments_StoreId",
                table: "CouponPayments");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "PointRedeemeds");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PointRedeemeds");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "PointRedeemeds");

            migrationBuilder.DropColumn(
                name: "DailySaleId",
                table: "MixPayments");

            migrationBuilder.DropColumn(
                name: "LinkInfo",
                table: "DailySalePayments");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "CouponPayments");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "CouponPayments");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "CouponPayments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PointRedeemeds",
                newName: "Remark");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CouponPayments",
                newName: "Remark");
        }
    }
}
