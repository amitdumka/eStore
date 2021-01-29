using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class Tailoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "StoreCloses",
                columns: table => new
                {
                    StoreCloseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClosingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCloses", x => x.StoreCloseId);
                    table.ForeignKey(
                        name: "FK_StoreCloses_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreHolidays",
                columns: table => new
                {
                    StoreHolidayId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reason = table.Column<int>(type: "INTEGER", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    ApprovedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreHolidays", x => x.StoreHolidayId);
                    table.ForeignKey(
                        name: "FK_StoreHolidays_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreOpens",
                columns: table => new
                {
                    StoreOpenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OpenningTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOpens", x => x.StoreOpenId);
                    table.ForeignKey(
                        name: "FK_StoreOpens_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TalioringBookings",
                columns: table => new
                {
                    TalioringBookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustName = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookingSlipNo = table.Column<string>(type: "TEXT", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "money", nullable: false),
                    TotalQty = table.Column<int>(type: "INTEGER", nullable: false),
                    ShirtQty = table.Column<int>(type: "INTEGER", nullable: false),
                    ShirtPrice = table.Column<decimal>(type: "money", nullable: false),
                    PantQty = table.Column<int>(type: "INTEGER", nullable: false),
                    PantPrice = table.Column<decimal>(type: "money", nullable: false),
                    CoatQty = table.Column<int>(type: "INTEGER", nullable: false),
                    CoatPrice = table.Column<decimal>(type: "money", nullable: false),
                    KurtaQty = table.Column<int>(type: "INTEGER", nullable: false),
                    KurtaPrice = table.Column<decimal>(type: "money", nullable: false),
                    BundiQty = table.Column<int>(type: "INTEGER", nullable: false),
                    BundiPrice = table.Column<decimal>(type: "money", nullable: false),
                    Others = table.Column<int>(type: "INTEGER", nullable: false),
                    OthersPrice = table.Column<decimal>(type: "money", nullable: false),
                    IsDelivered = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalioringBookings", x => x.TalioringBookingId);
                    table.ForeignKey(
                        name: "FK_TalioringBookings_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TailoringDeliveries",
                columns: table => new
                {
                    TalioringDeliveryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TalioringBookingId = table.Column<int>(type: "INTEGER", nullable: false),
                    InvNo = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TailoringDeliveries", x => x.TalioringDeliveryId);
                    table.ForeignKey(
                        name: "FK_TailoringDeliveries_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TailoringDeliveries_TalioringBookings_TalioringBookingId",
                        column: x => x.TalioringBookingId,
                        principalTable: "TalioringBookings",
                        principalColumn: "TalioringBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[] { 1, "State Bank of India" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[] { 2, "ICICI Bank" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[] { 3, "Bandhan Bank" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[] { 4, "Punjab National Bank" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[] { 5, "Bank of Baroda" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[] { 6, "Axis Bank" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "BankId", "BankName" },
                values: new object[] { 7, "HDFC Bank" });

            migrationBuilder.InsertData(
                table: "SaleTaxTypes",
                columns: new[] { "SaleTaxTypeId", "CompositeRate", "TaxName", "TaxType" },
                values: new object[] { 7, 5m, "Output Vat Free  ", 4 });

            migrationBuilder.InsertData(
                table: "SaleTaxTypes",
                columns: new[] { "SaleTaxTypeId", "CompositeRate", "TaxName", "TaxType" },
                values: new object[] { 6, 12m, "Output VAT@ 5%  ", 4 });

            migrationBuilder.InsertData(
                table: "SaleTaxTypes",
                columns: new[] { "SaleTaxTypeId", "CompositeRate", "TaxName", "TaxType" },
                values: new object[] { 5, 5m, "Output Vat@ 12%  ", 4 });

            migrationBuilder.InsertData(
                table: "SaleTaxTypes",
                columns: new[] { "SaleTaxTypeId", "CompositeRate", "TaxName", "TaxType" },
                values: new object[] { 4, 12m, "Output IGST@ 12%  ", 3 });

            migrationBuilder.InsertData(
                table: "SaleTaxTypes",
                columns: new[] { "SaleTaxTypeId", "CompositeRate", "TaxName", "TaxType" },
                values: new object[] { 3, 5m, "Output IGST@ 5%  ", 3 });

            migrationBuilder.InsertData(
                table: "SaleTaxTypes",
                columns: new[] { "SaleTaxTypeId", "CompositeRate", "TaxName", "TaxType" },
                values: new object[] { 2, 12m, "Local Output GST@ 12%  ", 0 });

            migrationBuilder.InsertData(
                table: "SaleTaxTypes",
                columns: new[] { "SaleTaxTypeId", "CompositeRate", "TaxName", "TaxType" },
                values: new object[] { 1, 5m, "Local Output GST@ 5%  ", 0 });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 1, "Home Expenses" });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 2, "Other Home Expenses" });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 3, "Mukesh(Home Staff)" });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 4, "Amit Kumar" });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 5, "Amit Kumar Expenses" });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 6, "CashIn" });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 7, "CashOut" });

            migrationBuilder.InsertData(
                table: "TranscationModes",
                columns: new[] { "TranscationModeId", "Transcation" },
                values: new object[] { 8, "Regular" });

            migrationBuilder.CreateIndex(
                name: "IX_TranscationModes_Transcation",
                table: "TranscationModes",
                column: "Transcation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreCloses_StoreId",
                table: "StoreCloses",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreHolidays_StoreId",
                table: "StoreHolidays",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOpens_StoreId",
                table: "StoreOpens",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TailoringDeliveries_StoreId",
                table: "TailoringDeliveries",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TailoringDeliveries_TalioringBookingId",
                table: "TailoringDeliveries",
                column: "TalioringBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TalioringBookings_StoreId",
                table: "TalioringBookings",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "StoreCloses");

            migrationBuilder.DropTable(
                name: "StoreHolidays");

            migrationBuilder.DropTable(
                name: "StoreOpens");

            migrationBuilder.DropTable(
                name: "TailoringDeliveries");

            migrationBuilder.DropTable(
                name: "TalioringBookings");

            migrationBuilder.DropIndex(
                name: "IX_TranscationModes_Transcation",
                table: "TranscationModes");

            migrationBuilder.DeleteData(
                table: "SaleTaxTypes",
                keyColumn: "SaleTaxTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SaleTaxTypes",
                keyColumn: "SaleTaxTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SaleTaxTypes",
                keyColumn: "SaleTaxTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SaleTaxTypes",
                keyColumn: "SaleTaxTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SaleTaxTypes",
                keyColumn: "SaleTaxTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SaleTaxTypes",
                keyColumn: "SaleTaxTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SaleTaxTypes",
                keyColumn: "SaleTaxTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TranscationModes",
                keyColumn: "TranscationModeId",
                keyValue: 8);
        }
    }
}
