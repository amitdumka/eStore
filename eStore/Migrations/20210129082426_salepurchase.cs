using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class salepurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandName = table.Column<string>(type: "TEXT", nullable: true),
                    BCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "CardMachine",
                columns: table => new
                {
                    EDCId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TID = table.Column<int>(type: "INTEGER", nullable: false),
                    EDCName = table.Column<string>(type: "TEXT", nullable: true),
                    AccountNumberId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsWorking = table.Column<bool>(type: "INTEGER", nullable: false),
                    MID = table.Column<string>(type: "TEXT", nullable: true),
                    Remark = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardMachine", x => x.EDCId);
                    table.ForeignKey(
                        name: "FK_CardMachine_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashInBanks",
                columns: table => new
                {
                    CashInBankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CIBDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OpenningBalance = table.Column<decimal>(type: "money", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "money", nullable: false),
                    CashIn = table.Column<decimal>(type: "money", nullable: false),
                    CashOut = table.Column<decimal>(type: "money", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashInBanks", x => x.CashInBankId);
                    table.ForeignKey(
                        name: "FK_CashInBanks_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashInHands",
                columns: table => new
                {
                    CashInHandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CIHDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OpenningBalance = table.Column<decimal>(type: "money", nullable: false),
                    ClosingBalance = table.Column<decimal>(type: "money", nullable: false),
                    CashIn = table.Column<decimal>(type: "money", nullable: false),
                    CashOut = table.Column<decimal>(type: "money", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashInHands", x => x.CashInHandId);
                    table.ForeignKey(
                        name: "FK_CashInHands_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true),
                    IsPrimaryCategory = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSecondaryCategory = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNo = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    NoOfBills = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "money", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityConnections",
                columns: table => new
                {
                    ElectricityConnectionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", nullable: true),
                    ConnectioName = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    PinCode = table.Column<string>(type: "TEXT", nullable: true),
                    ConsumerNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ConusumerId = table.Column<string>(type: "TEXT", nullable: true),
                    Connection = table.Column<int>(type: "INTEGER", nullable: false),
                    ConnectinDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DisconnectionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    KVLoad = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnedMetter = table.Column<bool>(type: "INTEGER", nullable: false),
                    TotalConnectionCharges = table.Column<decimal>(type: "money", nullable: false),
                    SecurityDeposit = table.Column<decimal>(type: "money", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityConnections", x => x.ElectricityConnectionId);
                    table.ForeignKey(
                        name: "FK_ElectricityConnections_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HSN",
                columns: table => new
                {
                    HSNCode = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Rate = table.Column<int>(type: "INTEGER", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CESS = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSN", x => x.HSNCode);
                });

            migrationBuilder.CreateTable(
                name: "MixPayments",
                columns: table => new
                {
                    MixAndCouponPaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    ModeMixAndCouponPaymentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MixPayments", x => x.MixAndCouponPaymentId);
                    table.ForeignKey(
                        name: "FK_MixPayments_MixPayments_ModeMixAndCouponPaymentId",
                        column: x => x.ModeMixAndCouponPaymentId,
                        principalTable: "MixPayments",
                        principalColumn: "MixAndCouponPaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MixPayments_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineVendors",
                columns: table => new
                {
                    OnlineVendorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VendorName = table.Column<string>(type: "TEXT", nullable: true),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Remark = table.Column<string>(type: "TEXT", nullable: true),
                    OffDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Reason = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineVendors", x => x.OnlineVendorId);
                });

            migrationBuilder.CreateTable(
                name: "RentedLocations",
                columns: table => new
                {
                    RentedLocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaceName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VacatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNo = table.Column<string>(type: "TEXT", nullable: true),
                    RentAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsRented = table.Column<bool>(type: "INTEGER", nullable: false),
                    RentType = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedLocations", x => x.RentedLocationId);
                    table.ForeignKey(
                        name: "FK_RentedLocations_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuppilerName = table.Column<string>(type: "TEXT", nullable: true),
                    Warehouse = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "CardTranscations",
                columns: table => new
                {
                    EDCTranscationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EDCId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CardEndingNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CardTypes = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTranscations", x => x.EDCTranscationId);
                    table.ForeignKey(
                        name: "FK_CardTranscations_CardMachine_EDCId",
                        column: x => x.EDCId,
                        principalTable: "CardMachine",
                        principalColumn: "EDCId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTranscations_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Barcode = table.Column<string>(type: "TEXT", nullable: true),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    StyleCode = table.Column<string>(type: "TEXT", nullable: true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemDesc = table.Column<string>(type: "TEXT", nullable: true),
                    Categorys = table.Column<int>(type: "INTEGER", nullable: false),
                    MainCategoryCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductCategoryCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductTypeCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    MRP = table.Column<decimal>(type: "money", nullable: false),
                    TaxRate = table.Column<decimal>(type: "money", nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    HSNCode = table.Column<string>(type: "TEXT", nullable: true),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    Units = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.ProductItemId);
                    table.ForeignKey(
                        name: "FK_ProductItems_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItems_Category_MainCategoryCategoryId",
                        column: x => x.MainCategoryCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_Category_ProductCategoryCategoryId",
                        column: x => x.ProductCategoryCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_Category_ProductTypeCategoryId",
                        column: x => x.ProductTypeCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegularInvoices",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "TEXT", nullable: false),
                    RegularInvoiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsManualBill = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalItems = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalQty = table.Column<double>(type: "REAL", nullable: false),
                    TotalBillAmount = table.Column<decimal>(type: "money", nullable: false),
                    TotalDiscountAmount = table.Column<decimal>(type: "money", nullable: false),
                    RoundOffAmount = table.Column<decimal>(type: "money", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularInvoices", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_RegularInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegularInvoices_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EletricityBills",
                columns: table => new
                {
                    EletricityBillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElectricityConnectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    BillNumber = table.Column<string>(type: "TEXT", nullable: true),
                    BillDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MeterReadingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CurrentMeterReading = table.Column<double>(type: "REAL", nullable: false),
                    TotalUnit = table.Column<double>(type: "REAL", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "money", nullable: false),
                    ArrearAmount = table.Column<decimal>(type: "money", nullable: false),
                    NetDemand = table.Column<decimal>(type: "money", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EletricityBills", x => x.EletricityBillId);
                    table.ForeignKey(
                        name: "FK_EletricityBills_ElectricityConnections_ElectricityConnectionId",
                        column: x => x.ElectricityConnectionId,
                        principalTable: "ElectricityConnections",
                        principalColumn: "ElectricityConnectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EletricityBills_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineSales",
                columns: table => new
                {
                    OnlineSaleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaleDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InvNo = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    VoyagerInvoiceNo = table.Column<string>(type: "TEXT", nullable: true),
                    VoygerDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VoyagerAmount = table.Column<decimal>(type: "money", nullable: false),
                    ShippingMode = table.Column<string>(type: "TEXT", nullable: true),
                    VendorFee = table.Column<decimal>(type: "money", nullable: false),
                    ProfitValue = table.Column<decimal>(type: "money", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    OnlineVendorId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineSales", x => x.OnlineSaleId);
                    table.ForeignKey(
                        name: "FK_OnlineSales_OnlineVendors_OnlineVendorId",
                        column: x => x.OnlineVendorId,
                        principalTable: "OnlineVendors",
                        principalColumn: "OnlineVendorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineSales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentedLocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentType = table.Column<int>(type: "INTEGER", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Mode = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentDetails = table.Column<string>(type: "TEXT", nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rents_RentedLocations_RentedLocationId",
                        column: x => x.RentedLocationId,
                        principalTable: "RentedLocations",
                        principalColumn: "RentedLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPurchase",
                columns: table => new
                {
                    ProductPurchaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InWardNo = table.Column<string>(type: "TEXT", nullable: true),
                    InWardDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InvoiceNo = table.Column<string>(type: "TEXT", nullable: true),
                    TotalQty = table.Column<double>(type: "REAL", nullable: false),
                    TotalBasicAmount = table.Column<decimal>(type: "money", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "money", nullable: false),
                    TotalTax = table.Column<decimal>(type: "money", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "money", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchase", x => x.ProductPurchaseId);
                    table.ForeignKey(
                        name: "FK_ProductPurchase_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPurchase_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailySales",
                columns: table => new
                {
                    DailySaleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaleDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InvNo = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    PayMode = table.Column<int>(type: "INTEGER", nullable: false),
                    CashAmount = table.Column<decimal>(type: "money", nullable: false),
                    SalesmanId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDue = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsManualBill = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsTailoringBill = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSaleReturn = table.Column<bool>(type: "INTEGER", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    IsMatchedWithVOy = table.Column<bool>(type: "INTEGER", nullable: false),
                    EDCTranscationId = table.Column<int>(type: "INTEGER", nullable: true),
                    MixAndCouponPaymentId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySales", x => x.DailySaleId);
                    table.ForeignKey(
                        name: "FK_DailySales_CardTranscations_EDCTranscationId",
                        column: x => x.EDCTranscationId,
                        principalTable: "CardTranscations",
                        principalColumn: "EDCTranscationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailySales_MixPayments_MixAndCouponPaymentId",
                        column: x => x.MixAndCouponPaymentId,
                        principalTable: "MixPayments",
                        principalColumn: "MixAndCouponPaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailySales_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailySales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    SaleQty = table.Column<double>(type: "REAL", nullable: false),
                    PurchaseQty = table.Column<double>(type: "REAL", nullable: false),
                    Units = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentDetailId = table.Column<int>(type: "INTEGER", nullable: false),
                    PayMode = table.Column<int>(type: "INTEGER", nullable: false),
                    CashAmount = table.Column<decimal>(type: "money", nullable: false),
                    CardAmount = table.Column<decimal>(type: "money", nullable: false),
                    MixAmount = table.Column<decimal>(type: "money", nullable: false),
                    IsManualBill = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_RegularInvoices_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "RegularInvoices",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegularSaleItems",
                columns: table => new
                {
                    RegularSaleItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNo = table.Column<string>(type: "TEXT", nullable: true),
                    InvoiceNo1 = table.Column<string>(type: "TEXT", nullable: true),
                    ProductItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    BarCode = table.Column<string>(type: "TEXT", nullable: true),
                    Qty = table.Column<double>(type: "REAL", nullable: false),
                    Units = table.Column<int>(type: "INTEGER", nullable: false),
                    MRP = table.Column<decimal>(type: "money", nullable: false),
                    BasicAmount = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "money", nullable: false),
                    SaleTaxTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    BillAmount = table.Column<decimal>(type: "money", nullable: false),
                    SalesmanId = table.Column<int>(type: "INTEGER", nullable: false),
                    HSNCode = table.Column<long>(type: "INTEGER", nullable: true),
                    HSNCode1 = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularSaleItems", x => x.RegularSaleItemId);
                    table.ForeignKey(
                        name: "FK_RegularSaleItems_HSN_HSNCode1",
                        column: x => x.HSNCode1,
                        principalTable: "HSN",
                        principalColumn: "HSNCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegularSaleItems_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegularSaleItems_RegularInvoices_InvoiceNo1",
                        column: x => x.InvoiceNo1,
                        principalTable: "RegularInvoices",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegularSaleItems_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "SalesmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegularSaleItems_SaleTaxTypes_SaleTaxTypeId",
                        column: x => x.SaleTaxTypeId,
                        principalTable: "SaleTaxTypes",
                        principalColumn: "SaleTaxTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillPayments",
                columns: table => new
                {
                    EBillPaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EletricityBillId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Mode = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentDetails = table.Column<string>(type: "TEXT", nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    IsPartialPayment = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsBillCleared = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPayments", x => x.EBillPaymentId);
                    table.ForeignKey(
                        name: "FK_BillPayments_EletricityBills_EletricityBillId",
                        column: x => x.EletricityBillId,
                        principalTable: "EletricityBills",
                        principalColumn: "EletricityBillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillPayments_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineSaleReturns",
                columns: table => new
                {
                    OnlineSaleReturnId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OnlineSaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InvNo = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    VoyagerInvoiceNo = table.Column<string>(type: "TEXT", nullable: true),
                    VoygerDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VoyagerAmount = table.Column<decimal>(type: "money", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    IsRecived = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecivedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntryStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineSaleReturns", x => x.OnlineSaleReturnId);
                    table.ForeignKey(
                        name: "FK_OnlineSaleReturns_OnlineSales_OnlineSaleId",
                        column: x => x.OnlineSaleId,
                        principalTable: "OnlineSales",
                        principalColumn: "OnlineSaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineSaleReturns_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    PurchaseItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductPurchaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Barcode = table.Column<string>(type: "TEXT", nullable: true),
                    Qty = table.Column<double>(type: "REAL", nullable: false),
                    Unit = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    TaxAmout = table.Column<decimal>(type: "money", nullable: false),
                    PurchaseTaxTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    CostValue = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.PurchaseItemId);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_ProductPurchase_ProductPurchaseId",
                        column: x => x.ProductPurchaseId,
                        principalTable: "ProductPurchase",
                        principalColumn: "ProductPurchaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_PurchaseTaxTypes_PurchaseTaxTypeId",
                        column: x => x.PurchaseTaxTypeId,
                        principalTable: "PurchaseTaxTypes",
                        principalColumn: "PurchaseTaxTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CouponPayments",
                columns: table => new
                {
                    CouponPaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CouponNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DailySaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Remark = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponPayments", x => x.CouponPaymentId);
                    table.ForeignKey(
                        name: "FK_CouponPayments_DailySales_DailySaleId",
                        column: x => x.DailySaleId,
                        principalTable: "DailySales",
                        principalColumn: "DailySaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuesLists",
                columns: table => new
                {
                    DuesListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    IsRecovered = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecoveryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DailySaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPartialRecovery = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuesLists", x => x.DuesListId);
                    table.ForeignKey(
                        name: "FK_DuesLists_DailySales_DailySaleId",
                        column: x => x.DailySaleId,
                        principalTable: "DailySales",
                        principalColumn: "DailySaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuesLists_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointRedeemeds",
                columns: table => new
                {
                    PointRedeemedId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerMobileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    OnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DailySaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Remark = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointRedeemeds", x => x.PointRedeemedId);
                    table.ForeignKey(
                        name: "FK_PointRedeemeds_DailySales_DailySaleId",
                        column: x => x.DailySaleId,
                        principalTable: "DailySales",
                        principalColumn: "DailySaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    CardDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardType = table.Column<int>(type: "INTEGER", nullable: false),
                    CardCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    AuthCode = table.Column<int>(type: "INTEGER", nullable: false),
                    LastDigit = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceNo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.CardDetailId);
                    table.ForeignKey(
                        name: "FK_CardDetails_PaymentDetails_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "PaymentDetails",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DueRecoverds",
                columns: table => new
                {
                    DueRecoverdId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaidDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DuesListId = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "money", nullable: false),
                    IsPartialPayment = table.Column<bool>(type: "INTEGER", nullable: false),
                    Modes = table.Column<int>(type: "INTEGER", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DueRecoverds", x => x.DueRecoverdId);
                    table.ForeignKey(
                        name: "FK_DueRecoverds_DuesLists_DuesListId",
                        column: x => x.DuesListId,
                        principalTable: "DuesLists",
                        principalColumn: "DuesListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DueRecoverds_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_EletricityBillId",
                table: "BillPayments",
                column: "EletricityBillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_StoreId",
                table: "BillPayments",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CardDetails_InvoiceNo",
                table: "CardDetails",
                column: "InvoiceNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardMachine_StoreId",
                table: "CardMachine",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTranscations_EDCId",
                table: "CardTranscations",
                column: "EDCId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTranscations_StoreId",
                table: "CardTranscations",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CashInBanks_StoreId",
                table: "CashInBanks",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CashInHands_StoreId",
                table: "CashInHands",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponPayments_DailySaleId",
                table: "CouponPayments",
                column: "DailySaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_EDCTranscationId",
                table: "DailySales",
                column: "EDCTranscationId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_MixAndCouponPaymentId",
                table: "DailySales",
                column: "MixAndCouponPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_SalesmanId",
                table: "DailySales",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySales_StoreId",
                table: "DailySales",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DueRecoverds_DuesListId",
                table: "DueRecoverds",
                column: "DuesListId");

            migrationBuilder.CreateIndex(
                name: "IX_DueRecoverds_StoreId",
                table: "DueRecoverds",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DuesLists_DailySaleId",
                table: "DuesLists",
                column: "DailySaleId");

            migrationBuilder.CreateIndex(
                name: "IX_DuesLists_StoreId",
                table: "DuesLists",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityConnections_StoreId",
                table: "ElectricityConnections",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_EletricityBills_ElectricityConnectionId",
                table: "EletricityBills",
                column: "ElectricityConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_EletricityBills_StoreId",
                table: "EletricityBills",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MixPayments_ModeMixAndCouponPaymentId",
                table: "MixPayments",
                column: "ModeMixAndCouponPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_MixPayments_StoreId",
                table: "MixPayments",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineSaleReturns_OnlineSaleId",
                table: "OnlineSaleReturns",
                column: "OnlineSaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineSaleReturns_StoreId",
                table: "OnlineSaleReturns",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineSales_OnlineVendorId",
                table: "OnlineSales",
                column: "OnlineVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineSales_StoreId",
                table: "OnlineSales",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PointRedeemeds_DailySaleId",
                table: "PointRedeemeds",
                column: "DailySaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_BrandId",
                table: "ProductItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_MainCategoryCategoryId",
                table: "ProductItems",
                column: "MainCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductCategoryCategoryId",
                table: "ProductItems",
                column: "ProductCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductTypeCategoryId",
                table: "ProductItems",
                column: "ProductTypeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchase_StoreId",
                table: "ProductPurchase",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchase_SupplierID",
                table: "ProductPurchase",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_ProductItemId",
                table: "PurchaseItem",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_ProductPurchaseId",
                table: "PurchaseItem",
                column: "ProductPurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_PurchaseTaxTypeId",
                table: "PurchaseItem",
                column: "PurchaseTaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularInvoices_CustomerId",
                table: "RegularInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularInvoices_StoreId",
                table: "RegularInvoices",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSaleItems_HSNCode1",
                table: "RegularSaleItems",
                column: "HSNCode1");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSaleItems_InvoiceNo1",
                table: "RegularSaleItems",
                column: "InvoiceNo1");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSaleItems_ProductItemId",
                table: "RegularSaleItems",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSaleItems_SalesmanId",
                table: "RegularSaleItems",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSaleItems_SaleTaxTypeId",
                table: "RegularSaleItems",
                column: "SaleTaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedLocations_StoreId",
                table: "RentedLocations",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RentedLocationId",
                table: "Rents",
                column: "RentedLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_StoreId",
                table: "Rents",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductItemId",
                table: "Stocks",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StoreId",
                table: "Stocks",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillPayments");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "CashInBanks");

            migrationBuilder.DropTable(
                name: "CashInHands");

            migrationBuilder.DropTable(
                name: "CouponPayments");

            migrationBuilder.DropTable(
                name: "DueRecoverds");

            migrationBuilder.DropTable(
                name: "OnlineSaleReturns");

            migrationBuilder.DropTable(
                name: "PointRedeemeds");

            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.DropTable(
                name: "RegularSaleItems");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "EletricityBills");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "DuesLists");

            migrationBuilder.DropTable(
                name: "OnlineSales");

            migrationBuilder.DropTable(
                name: "ProductPurchase");

            migrationBuilder.DropTable(
                name: "HSN");

            migrationBuilder.DropTable(
                name: "RentedLocations");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "ElectricityConnections");

            migrationBuilder.DropTable(
                name: "RegularInvoices");

            migrationBuilder.DropTable(
                name: "DailySales");

            migrationBuilder.DropTable(
                name: "OnlineVendors");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CardTranscations");

            migrationBuilder.DropTable(
                name: "MixPayments");

            migrationBuilder.DropTable(
                name: "CardMachine");
        }
    }
}
