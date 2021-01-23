using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eStore.Shared.Models.Stores;


namespace eStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Store> Stores { get; set; }
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
        }

    }
}
