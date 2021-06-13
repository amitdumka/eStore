using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class SalePurchaseU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Brand_BrandId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Category_MainCategoryCategoryId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Category_ProductCategoryCategoryId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Category_ProductTypeCategoryId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchase_Stores_StoreId",
                table: "ProductPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchase_Supplier_SupplierID",
                table: "ProductPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_ProductItems_ProductItemId",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_ProductPurchase_ProductPurchaseId",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RegularSaleItems_ProductItems_ProductItemId",
                table: "RegularSaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ProductItems_ProductItemId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductItemId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_RegularSaleItems_ProductItemId",
                table: "RegularSaleItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItem_ProductItemId",
                table: "PurchaseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductItems",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPurchase",
                table: "ProductPurchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "ProductPurchase",
                newName: "ProductPurchases");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stocks",
                newName: "HoldQty");

            migrationBuilder.RenameColumn(
                name: "CardDetailId",
                table: "CardDetails",
                newName: "RegularCardDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPurchase_SupplierID",
                table: "ProductPurchases",
                newName: "IX_ProductPurchases_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPurchase_StoreId",
                table: "ProductPurchases",
                newName: "IX_ProductPurchases_StoreId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductItemId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductItemBarcode",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductItemBarcode",
                table: "RegularSaleItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductItemBarcode",
                table: "PurchaseItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "ProductItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "DailySales",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "ProductPurchases",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMRPValue",
                table: "ProductPurchases",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductItems",
                table: "ProductItems",
                column: "Barcode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPurchases",
                table: "ProductPurchases",
                column: "ProductPurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "BrandId");

            migrationBuilder.CreateTable(
                name: "LocationMasters",
                columns: table => new
                {
                    LOCATIONCODE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LOCATIONNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMasters", x => x.LOCATIONCODE);
                });

            migrationBuilder.CreateTable(
                name: "SaleCardDetails",
                columns: table => new
                {
                    SaleCardDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    CardCode = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    AuthCode = table.Column<int>(type: "int", nullable: false),
                    LastDigit = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleCardDetails", x => x.SaleCardDetailId);
                    table.ForeignKey(
                        name: "FK_SaleCardDetails_PaymentDetails_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "PaymentDetails",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoices",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SaleInvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsNonVendor = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryStatus = table.Column<int>(type: "int", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    TotalQty = table.Column<double>(type: "float", nullable: false),
                    TotalBillAmount = table.Column<decimal>(type: "money", nullable: false),
                    TotalDiscountAmount = table.Column<decimal>(type: "money", nullable: false),
                    RoundOffAmount = table.Column<decimal>(type: "money", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoices", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoicePayments",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoicePaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayMode = table.Column<int>(type: "int", nullable: false),
                    CashAmount = table.Column<decimal>(type: "money", nullable: false),
                    NonCashAmount = table.Column<decimal>(type: "money", nullable: false),
                    OtherAmount = table.Column<decimal>(type: "money", nullable: false),
                    CardDetailSaleCardDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoicePayments", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_SaleInvoicePayments_SaleCardDetails_CardDetailSaleCardDetailId",
                        column: x => x.CardDetailSaleCardDetailId,
                        principalTable: "SaleCardDetails",
                        principalColumn: "SaleCardDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoicePayments_SaleInvoices_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "SaleInvoices",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    SaleItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    ProductItemBarcode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<decimal>(type: "money", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "money", nullable: false),
                    SaleTaxTypeId = table.Column<int>(type: "int", nullable: true),
                    BillAmount = table.Column<decimal>(type: "money", nullable: false),
                    SalesmanId = table.Column<int>(type: "int", nullable: false),
                    HSNCode = table.Column<long>(type: "bigint", nullable: true),
                    HSNCode1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.SaleItemId);
                    table.ForeignKey(
                        name: "FK_SaleItems_HSN_HSNCode1",
                        column: x => x.HSNCode1,
                        principalTable: "HSN",
                        principalColumn: "HSNCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItems_ProductItems_ProductItemBarcode",
                        column: x => x.ProductItemBarcode,
                        principalTable: "ProductItems",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItems_SaleInvoices_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "SaleInvoices",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItems_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItems_SaleTaxTypes_SaleTaxTypeId",
                        column: x => x.SaleTaxTypeId,
                        principalTable: "SaleTaxTypes",
                        principalColumn: "SaleTaxTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductItemBarcode",
                table: "Stocks",
                column: "ProductItemBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSaleItems_ProductItemBarcode",
                table: "RegularSaleItems",
                column: "ProductItemBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_ProductItemBarcode",
                table: "PurchaseItem",
                column: "ProductItemBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_SaleCardDetails_InvoiceNo",
                table: "SaleCardDetails",
                column: "InvoiceNo");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoicePayments_CardDetailSaleCardDetailId",
                table: "SaleInvoicePayments",
                column: "CardDetailSaleCardDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_CustomerId",
                table: "SaleInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_StoreId",
                table: "SaleInvoices",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_HSNCode1",
                table: "SaleItems",
                column: "HSNCode1");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_InvoiceNo",
                table: "SaleItems",
                column: "InvoiceNo");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductItemBarcode",
                table: "SaleItems",
                column: "ProductItemBarcode");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SalesmanId",
                table: "SaleItems",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleTaxTypeId",
                table: "SaleItems",
                column: "SaleTaxTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Brands_BrandId",
                table: "ProductItems",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Categories_MainCategoryCategoryId",
                table: "ProductItems",
                column: "MainCategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Categories_ProductCategoryCategoryId",
                table: "ProductItems",
                column: "ProductCategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Categories_ProductTypeCategoryId",
                table: "ProductItems",
                column: "ProductTypeCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchases_Stores_StoreId",
                table: "ProductPurchases",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchases_Suppliers_SupplierID",
                table: "ProductPurchases",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_ProductItems_ProductItemBarcode",
                table: "PurchaseItem",
                column: "ProductItemBarcode",
                principalTable: "ProductItems",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_ProductPurchases_ProductPurchaseId",
                table: "PurchaseItem",
                column: "ProductPurchaseId",
                principalTable: "ProductPurchases",
                principalColumn: "ProductPurchaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegularSaleItems_ProductItems_ProductItemBarcode",
                table: "RegularSaleItems",
                column: "ProductItemBarcode",
                principalTable: "ProductItems",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ProductItems_ProductItemBarcode",
                table: "Stocks",
                column: "ProductItemBarcode",
                principalTable: "ProductItems",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Brands_BrandId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Categories_MainCategoryCategoryId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Categories_ProductCategoryCategoryId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Categories_ProductTypeCategoryId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchases_Stores_StoreId",
                table: "ProductPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchases_Suppliers_SupplierID",
                table: "ProductPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_ProductItems_ProductItemBarcode",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_ProductPurchases_ProductPurchaseId",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RegularSaleItems_ProductItems_ProductItemBarcode",
                table: "RegularSaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ProductItems_ProductItemBarcode",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "LocationMasters");

            migrationBuilder.DropTable(
                name: "SaleInvoicePayments");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "SaleCardDetails");

            migrationBuilder.DropTable(
                name: "SaleInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductItemBarcode",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_RegularSaleItems_ProductItemBarcode",
                table: "RegularSaleItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItem_ProductItemBarcode",
                table: "PurchaseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductItems",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPurchases",
                table: "ProductPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "BarCode",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductItemBarcode",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductItemBarcode",
                table: "RegularSaleItems");

            migrationBuilder.DropColumn(
                name: "ProductItemBarcode",
                table: "PurchaseItem");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "DailySales");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "ProductPurchases");

            migrationBuilder.DropColumn(
                name: "TotalMRPValue",
                table: "ProductPurchases");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "ProductPurchases",
                newName: "ProductPurchase");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "HoldQty",
                table: "Stocks",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "RegularCardDetailId",
                table: "CardDetails",
                newName: "CardDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPurchases_SupplierID",
                table: "ProductPurchase",
                newName: "IX_ProductPurchase_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPurchases_StoreId",
                table: "ProductPurchase",
                newName: "IX_ProductPurchase_StoreId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductItemId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductItems",
                table: "ProductItems",
                column: "ProductItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SupplierID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPurchase",
                table: "ProductPurchase",
                column: "ProductPurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductItemId",
                table: "Stocks",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSaleItems_ProductItemId",
                table: "RegularSaleItems",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_ProductItemId",
                table: "PurchaseItem",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Brand_BrandId",
                table: "ProductItems",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Category_MainCategoryCategoryId",
                table: "ProductItems",
                column: "MainCategoryCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Category_ProductCategoryCategoryId",
                table: "ProductItems",
                column: "ProductCategoryCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Category_ProductTypeCategoryId",
                table: "ProductItems",
                column: "ProductTypeCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchase_Stores_StoreId",
                table: "ProductPurchase",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchase_Supplier_SupplierID",
                table: "ProductPurchase",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_ProductItems_ProductItemId",
                table: "PurchaseItem",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "ProductItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_ProductPurchase_ProductPurchaseId",
                table: "PurchaseItem",
                column: "ProductPurchaseId",
                principalTable: "ProductPurchase",
                principalColumn: "ProductPurchaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegularSaleItems_ProductItems_ProductItemId",
                table: "RegularSaleItems",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "ProductItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ProductItems_ProductItemId",
                table: "Stocks",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "ProductItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
