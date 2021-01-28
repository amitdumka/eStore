﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eStore.DL.Data;

namespace eStore.Migrations
{
    [DbContext(typeof(eStoreDbContext))]
    partial class eStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("eStore.Shared.Models.AppInfo", b =>
                {
                    b.Property<int>("AppInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DatabaseVersion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEffective")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT");

                    b.HasKey("AppInfoId");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("eStore.Shared.Models.Common.PurchaseTaxType", b =>
                {
                    b.Property<int>("PurchaseTaxTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CompositeRate")
                        .HasColumnType("money");

                    b.Property<string>("TaxName")
                        .HasColumnType("TEXT");

                    b.Property<int>("TaxType")
                        .HasColumnType("INTEGER");

                    b.HasKey("PurchaseTaxTypeId");

                    b.ToTable("PurchaseTaxTypes");
                });

            modelBuilder.Entity("eStore.Shared.Models.Common.SaleTaxType", b =>
                {
                    b.Property<int>("SaleTaxTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CompositeRate")
                        .HasColumnType("money");

                    b.Property<string>("TaxName")
                        .HasColumnType("TEXT");

                    b.Property<int>("TaxType")
                        .HasColumnType("INTEGER");

                    b.HasKey("SaleTaxTypeId");

                    b.ToTable("SaleTaxTypes");
                });

            modelBuilder.Entity("eStore.Shared.Models.Common.TranscationMode", b =>
                {
                    b.Property<int>("TranscationModeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Transcation")
                        .HasColumnType("TEXT");

                    b.HasKey("TranscationModeId");

                    b.ToTable("TranscationModes");
                });

            modelBuilder.Entity("eStore.Shared.Models.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("eStore.Shared.Models.Identity.RegisteredUser", b =>
                {
                    b.Property<int>("RegisteredUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsUserLoggedIn")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastLoggedIn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("RegisteredUserId");

                    b.ToTable("RegisteredUsers");
                });

            modelBuilder.Entity("eStore.Shared.Models.Payroll.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AttDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EntryTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTailoring")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Remarks")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("AttendanceId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("eStore.Shared.Models.Payroll.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdharNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("EMail")
                        .HasColumnType("TEXT");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FatherName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("HighestQualification")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTailors")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MobileNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherIdDetails")
                        .HasColumnType("TEXT");

                    b.Property<string>("PanNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("eStore.Shared.Models.Payroll.EmployeeUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("EmployeeUsers");
                });

            modelBuilder.Entity("eStore.Shared.Models.Stores.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPersonEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPersonName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPersonPhoneNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("eStore.Shared.Models.Stores.Salesman", b =>
                {
                    b.Property<int>("SalesmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SalesmanName")
                        .HasColumnType("TEXT");

                    b.Property<int>("StoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("SalesmanId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Salesmen");

                    b.HasData(
                        new
                        {
                            SalesmanId = 1,
                            EntryStatus = 0,
                            IsReadOnly = false,
                            SalesmanName = "Sanjeev Mishra",
                            StoreId = 1
                        },
                        new
                        {
                            SalesmanId = 2,
                            EntryStatus = 0,
                            IsReadOnly = false,
                            SalesmanName = "Mukesh Mandal",
                            StoreId = 1
                        },
                        new
                        {
                            SalesmanId = 3,
                            EntryStatus = 0,
                            IsReadOnly = false,
                            SalesmanName = "Manager",
                            StoreId = 1
                        },
                        new
                        {
                            SalesmanId = 4,
                            EntryStatus = 0,
                            IsReadOnly = false,
                            SalesmanName = "Bikash Kumar Sah",
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("eStore.Shared.Models.Stores.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntryStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GSTNO")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoOfEmployees")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PanNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("PinCode")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoreCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreManagerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreManagerPhoneNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("StoreName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("StoreId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            Address = "Bhagalpur Road Dumka",
                            City = "Dumka",
                            EntryStatus = 0,
                            GSTNO = "20AJHPA739P1zv",
                            IsReadOnly = false,
                            NoOfEmployees = 9,
                            OpeningDate = new DateTime(2016, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PanNo = "AJHPA7396P",
                            PhoneNo = "06434-224461",
                            PinCode = "814101",
                            Status = true,
                            StoreCode = "JH0006",
                            StoreManagerName = "Alok Kumar",
                            StoreManagerPhoneNo = "",
                            StoreName = "Aprajita Retails"
                        });
                });

            modelBuilder.Entity("eStore.Shared.Models.Todos.FileInfo", b =>
                {
                    b.Property<Guid>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("eStore.Shared.Models.Todos.ToDoMessage", b =>
                {
                    b.Property<int>("ToDoMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOver")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("OverDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ToDoMessageId");

                    b.ToTable("ToDoMessages");
                });

            modelBuilder.Entity("eStore.Shared.Models.Todos.TodoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Added")
                        .HasColumnType("TEXT")
                        .HasColumnName("Added");

                    b.Property<string>("Content")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DueTo")
                        .HasColumnType("TEXT")
                        .HasColumnName("DueTo");

                    b.Property<Guid?>("FileTodoId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FileTodoId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("eStore.Shared.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("eStore.Shared.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eStore.Shared.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("eStore.Shared.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eStore.Shared.Models.Payroll.Attendance", b =>
                {
                    b.HasOne("eStore.Shared.Models.Payroll.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eStore.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("eStore.Shared.Models.Payroll.Employee", b =>
                {
                    b.HasOne("eStore.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("eStore.Shared.Models.Payroll.EmployeeUser", b =>
                {
                    b.HasOne("eStore.Shared.Models.Payroll.Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("eStore.Shared.Models.Payroll.EmployeeUser", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("eStore.Shared.Models.Stores.Salesman", b =>
                {
                    b.HasOne("eStore.Shared.Models.Payroll.Employee", "Employee")
                        .WithMany("Salesmen")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("eStore.Shared.Models.Stores.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("eStore.Shared.Models.Stores.Store", b =>
                {
                    b.HasOne("eStore.Shared.Models.Stores.Company", "Company")
                        .WithMany("Stores")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("eStore.Shared.Models.Todos.TodoItem", b =>
                {
                    b.HasOne("eStore.Shared.Models.Todos.FileInfo", "File")
                        .WithMany()
                        .HasForeignKey("FileTodoId");

                    b.Navigation("File");
                });

            modelBuilder.Entity("eStore.Shared.Models.Payroll.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Salesmen");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eStore.Shared.Models.Stores.Company", b =>
                {
                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
