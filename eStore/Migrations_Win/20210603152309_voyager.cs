using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class voyager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "WalletPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "PointRedeemeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "CouponPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "BankPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InwardSummaries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InwardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InwardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalMRPValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InwardSummaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRINCIPAL_FCD = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCTCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRODUCTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleWithCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleWithCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxDesc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoyBrandNames",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoyBrandNames", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VoyPurchaseInwards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRNNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GRNDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRPValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExmillCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Excise1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Excise2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Excise3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoyPurchaseInwards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VoySaleInvoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HSNCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SGSTAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CGSTAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CESSAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoundOff = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesManName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coupon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponAmt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUBTYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillDiscount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LPFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstOrderCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TailoringFlag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoySaleInvoices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VoySaleInvoiceSums",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoundOff = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coupon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponAmt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LPFlag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstOrderCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TailoringFlag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoySaleInvoiceSums", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InwardSummaries");

            migrationBuilder.DropTable(
                name: "ProductLists");

            migrationBuilder.DropTable(
                name: "ProductMasters");

            migrationBuilder.DropTable(
                name: "SaleWithCustomers");

            migrationBuilder.DropTable(
                name: "TaxRegisters");

            migrationBuilder.DropTable(
                name: "VoyBrandNames");

            migrationBuilder.DropTable(
                name: "VoyPurchaseInwards");

            migrationBuilder.DropTable(
                name: "VoySaleInvoices");

            migrationBuilder.DropTable(
                name: "VoySaleInvoiceSums");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "WalletPayments");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "PointRedeemeds");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "CouponPayments");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "BankPayments");
        }
    }
}
