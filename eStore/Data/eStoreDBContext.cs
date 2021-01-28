using System;
using System.Linq;
using eStore.Shared.Models;
using eStore.Shared.Models.Common;
using eStore.Shared.Models.Identity;
using eStore.Shared.Models.Payroll;
using eStore.Shared.Models.Stores;
using eStore.Shared.Models.Todos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//namespace eStore.DL.Data
namespace eStore.DL.Data
{
    public class eStoreDbContext : IdentityDbContext<AppUser>
    {
        public eStoreDbContext(DbContextOptions<eStoreDbContext> options) : base(options)
        {
            ApplyMigrations(this);
        }

        public DbSet<Store> Stores { get; set; } //Ok//UI
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<AppInfo> Apps { get; set; } //ok

        ////Payrolls
        public DbSet<Employee> Employees { get; set; } //ok//UI
        public DbSet<EmployeeUser> EmployeeUsers { get; set; }
        public DbSet<Attendance> Attendances { get; set; } //ok//UI
        public DbSet<Salesman> Salesmen { get; set; } //ok


        public DbSet<TranscationMode> TranscationModes { get; set; } //ok//UI
        public DbSet<SaleTaxType> SaleTaxTypes { get; set; } //ok//UI
        public DbSet<PurchaseTaxType> PurchaseTaxTypes { get; set; }//UI

        ////Banking
        //public DbSet<Bank> Banks { get; set; } //ok

        ////TODO
        public DbSet<ToDoMessage> ToDoMessages { get; set; }

        public DbSet<TodoItem> Todos { get; set; }
        public DbSet<FileInfo> Files { get; set; }
        

        ////Tailoring
        //public DbSet<TalioringBooking> TalioringBookings { get; set; }//UI
        //public DbSet<TalioringDelivery> TailoringDeliveries { get; set; }//UI

        ////End of Day
        //public DbSet<EndOfDay> EndOfDays { get; set; }//UI
        //public DbSet<CashDetail> CashDetail { get; set; }//UI

        ////Rent and Electricity
        //public DbSet<RentedLocation> RentedLocations { get; set; }//UI
        //public DbSet<Rent> Rents { get; set; }//UI
        //public DbSet<ElectricityConnection> ElectricityConnections { get; set; }//UI
        //public DbSet<EletricityBill> EletricityBills { get; set; }//UI
        //public DbSet<EBillPayment> BillPayments { get; set; } //UI

        //public DbSet<Contact> Contacts { get; set; }

        ////Import Table Data
        //public DbSet<ImportSearchList> ImportSearches { get; set; }
        //public DbSet<ImportInWard> ImportInWards { get; set; }
        //public DbSet<ImportPurchase> ImportPurchases { get; set; }
        //public DbSet<ImportSaleItemWise> ImportSaleItemWises { get; set; }
        //public DbSet<ImportSaleRegister> ImportSaleRegisters { get; set; }
        //public DbSet<BookEntry> ImportBookEntries { get; set; }
        //public DbSet<BankStatement> BankStatements { get; set; }

        //Bots
        //public DbSet<TelegramAuthUser> TelegramAuthUsers { get; set; }

        //public DbSet<DailySale> DailySales { get; set; }

        //public DbSet<OnlineSale> OnlineSales { get; set; }
        //public DbSet<OnlineSaleReturn> OnlineSaleReturns { get; set; }
        //public DbSet<OnlineVendor> OnlineVendors { get; set; }


        //public DbSet<RegularInvoice> RegularInvoices { get; set; }
        //public DbSet<RegularSaleItem> RegularSaleItems { get; set; }
        //public DbSet<PaymentDetail> PaymentDetails { get; set; }
        //public DbSet<CardDetail> CardDetails { get; set; }

        //public DbSet<EDC> CardMachine { get; set; }
        //public DbSet<EDCTranscation> CardTranscations { get; set; }
        //public DbSet<MixAndCouponPayment> MixPayments { get; set; }
        //public DbSet<CouponPayment> CouponPayments { get; set; }
        //public DbSet<PointRedeemed> PointRedeemeds { get; set; }
        //public DbSet<DuesList> DuesLists { get; set; }
        //public DbSet<DueRecoverd> DueRecoverds { get; set; }

        //public DbSet<CashInHand> CashInHands { get; set; }
        //public DbSet<CashInBank> CashInBanks { get; set; }

        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<ProductItem> ProductItems { get; set; }
        //public DbSet<Stock> Stocks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<TodoItem>().ToTable("Todo");
            //modelBuilder.Entity<FileInfo>().ToTable("File");
            //modelBuilder.Entity<TodoItem>()
            //    .Property(e => e.Tags)
            //    .HasConversion(v => string.Join(',', v),
            //    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            //modelBuilder.Entity<TranscationMode>()
            //  .HasIndex(b => b.Transcation)
            //  .IsUnique();

            modelBuilder.Entity<Store>().HasData(new Store
            {
                StoreId = 1,
                StoreCode = "JH0006",
                Address = "Bhagalpur Road Dumka",
                City = "Dumka",
                GSTNO = "20AJHPA739P1zv",
                NoOfEmployees = 9,
                OpeningDate = new DateTime(2016, 2, 17).Date,
                PanNo = "AJHPA7396P",
                StoreName = "Aprajita Retails",
                PinCode = "814101",
                Status = true,
                PhoneNo = "06434-224461",
                StoreManagerName = "Alok Kumar",
                StoreManagerPhoneNo = ""
            });

            modelBuilder.Entity<Salesman>().HasData(new Salesman { SalesmanId = 1, SalesmanName = "Sanjeev Mishra", StoreId = 1 });
            modelBuilder.Entity<Salesman>().HasData(new Salesman { SalesmanId = 2, SalesmanName = "Mukesh Mandal", StoreId = 1 });
            modelBuilder.Entity<Salesman>().HasData(new Salesman { SalesmanId = 3, SalesmanName = "Manager", StoreId = 1 });
            modelBuilder.Entity<Salesman>().HasData(new Salesman { SalesmanId = 4, SalesmanName = "Bikash Kumar Sah", StoreId = 1 });

            //modelBuilder.Entity<Bank>().HasData(new Bank() { BankId = 1, BankName = "State Bank of India" });
            //modelBuilder.Entity<Bank>().HasData(new Bank() { BankId = 2, BankName = "ICICI Bank" });
            //modelBuilder.Entity<Bank>().HasData(new Bank() { BankId = 3, BankName = "Bandhan Bank" });
            //modelBuilder.Entity<Bank>().HasData(new Bank() { BankId = 4, BankName = "Punjab National Bank" });
            //modelBuilder.Entity<Bank>().HasData(new Bank() { BankId = 5, BankName = "Bank of Baroda" });
            //modelBuilder.Entity<Bank>().HasData(new Bank() { BankId = 6, BankName = "Axis Bank" });
            //modelBuilder.Entity<Bank>().HasData(new Bank() { BankId = 7, BankName = "HDFC Bank" });

            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 1, Transcation = "Home Expenses" });
            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 2, Transcation = "Other Home Expenses" });
            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 3, Transcation = "Mukesh(Home Staff)" });
            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 4, Transcation = "Amit Kumar" });
            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 5, Transcation = "Amit Kumar Expenses" });
            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 6, Transcation = "CashIn" });
            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 7, Transcation = "CashOut" });
            //modelBuilder.Entity<TranscationMode>().HasData(new TranscationMode { TranscationModeId = 8, Transcation = "Regular" });

            //modelBuilder.Entity<SaleTaxType>().HasData(new SaleTaxType { SaleTaxTypeId = 1, CompositeRate = 5, TaxName = "Local Output GST@ 5%  ", TaxType = TaxType.GST });
            //modelBuilder.Entity<SaleTaxType>().HasData(new SaleTaxType { SaleTaxTypeId = 2, CompositeRate = 12, TaxName = "Local Output GST@ 12%  ", TaxType = TaxType.GST });
            //modelBuilder.Entity<SaleTaxType>().HasData(new SaleTaxType { SaleTaxTypeId = 3, CompositeRate = 5, TaxName = "Output IGST@ 5%  ", TaxType = TaxType.IGST });
            //modelBuilder.Entity<SaleTaxType>().HasData(new SaleTaxType { SaleTaxTypeId = 4, CompositeRate = 12, TaxName = "Output IGST@ 12%  ", TaxType = TaxType.IGST });
            //modelBuilder.Entity<SaleTaxType>().HasData(new SaleTaxType { SaleTaxTypeId = 5, CompositeRate = 5, TaxName = "Output Vat@ 12%  ", TaxType = TaxType.VAT });
            //modelBuilder.Entity<SaleTaxType>().HasData(new SaleTaxType { SaleTaxTypeId = 6, CompositeRate = 12, TaxName = "Output VAT@ 5%  ", TaxType = TaxType.VAT });
            //modelBuilder.Entity<SaleTaxType>().HasData(new SaleTaxType { SaleTaxTypeId = 7, CompositeRate = 5, TaxName = "Output Vat Free  ", TaxType = TaxType.VAT });

        }

        public void ApplyMigrations(eStoreDbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
