using AprajitaRetails.ImportDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace eStore.ImportDatabase.Data
{
    /// <summary>
    /// @version 4.0
    /// @Author Amit Kumar
    /// </summary>
    public class AprajitaRetailsDbContext : DbContext
    {
        public AprajitaRetailsDbContext(DbContextOptions<AprajitaRetailsDbContext> options) : base(options)
        {
            //ApplyMigrations(this);
        }

        //Done
        public DbSet<DailySale> DailySales { get; set; }   //Version 3.0
        public DbSet<Salesman> Salesmen { get; set; }      //Version 3.0
        public DbSet<DuesList> DuesLists { get; set; }     //Version 3.0
        public DbSet<TranscationMode> TranscationModes { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }
        public DbSet<CashReceipt> CashReceipts { get; set; }

        public DbSet<SalaryPayment> SalaryPayments { get; set; }
        public DbSet<StaffAdvancePayment> StaffAdvancePayments { get; set; }
        public DbSet<StaffAdvanceReceipt> StaffAdvanceReceipts { get; set; }

        public DbSet<CurrentSalary> CurrentSalaries { get; set; }
        public DbSet<PaySlip> PaySlips { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<AccountNumber> AccountNumbers { get; set; }
        public DbSet<BankDeposit> BankDeposits { get; set; }
        public DbSet<BankWithdrawal> BankWithdrawals { get; set; }
        //BankAccount Info
        public DbSet<BankAccountInfo> BankAccountInfos { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<PettyCashExpense> PettyCashExpenses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<TalioringBooking> TalioringBookings { get; set; }
        public DbSet<TalioringDelivery> TailoringDeliveries { get; set; }
        public DbSet<EndOfDay> EndOfDays { get; set; }
        public DbSet<DueRecoverd> DueRecoverds { get; set; }
        public DbSet<ChequesLog> ChequesLogs { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<CashDetail> CashDetail { get; set; }
        public DbSet<Store> Stores { get; set; } // Adding to relevent classes
        public DbSet<Shared.Models.Stores.Customer> Customers { get; set; }
        public DbSet<EDC> CardMachine { get; set; } //ok
        public DbSet<EDCTranscation> CardTranscations { get; set; } //ok
        public DbSet<RentedLocation> RentedLocations { get; set; } //ok
        public DbSet<Rent> Rents { get; set; } //ok
        public DbSet<ElectricityConnection> ElectricityConnections { get; set; } //ok
        public DbSet<EletricityBill> EletricityBills { get; set; } //ok
        public DbSet<EBillPayment> BillPayments { get; set; } //ok
        public DbSet<ArvindPayment> ArvindPayments { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        //Purchase Entry System
        public DbSet<ProductPurchase> ProductPurchases { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<PurchaseTaxType> PurchaseTaxTypes { get; set; }

        //Import Table
        public DbSet<ImportInWard> ImportInWards { get; set; }
        public DbSet<ImportPurchase> ImportPurchases { get; set; }
        public DbSet<ImportSaleItemWise> ImportSaleItemWises { get; set; }
        public DbSet<ImportSaleRegister> ImportSaleRegisters { get; set; }
        public DbSet<BookEntry> ImportBookEntries { get; set; }
        public DbSet<BankStatement> BankStatements { get; set; } //NoData
        public DbSet<ImportSearchList> ImportSearches { get; set; }

        //Pending

        // public DbSet<EmployeeUser> EmployeeUsers { get; set; }//Data
        // public DbSet<BankAccountSecurityInfo> AccountSecurityInfos { get; set; }
        // public DbSet<MixAndCouponPayment> MixPayments { get; set; } //No Data
        // public DbSet<CouponPayment> CouponPayments { get; set; }//NoData
        // public DbSet<PointRedeemed> PointRedeemeds { get; set; }//NoData


    }

}
