using System;
using eStore.BL.Exporter.Database;
using eStore.DL.Data;
using eStore.Shared.Models.Stores;

namespace eStore.BL.Exporter.Importer
{


    public class StoreInfoImport
    {
        private XSReader xS;
        private eStoreDbContext db;

        public StoreInfoImport(eStoreDbContext dbContext)
        {
            db = dbContext;
        }

        public async System.Threading.Tasks.Task ReadAsync(string fileName)
        {
            xS = new XSReader(fileName);

            if (xS.WorkBookName == "Stores")
            {
                await AddContactsAsync();
                await AddCustomersAsync();
                await AddEndOfDaysAsync();

            }
            else
            {
                throw new Exception();
            }

        }
        public async System.Threading.Tasks.Task ReadAsync(XSReader ixs)
        {
            xS = ixs;

            if (xS.WorkBookName == "Stores")
            {
                await AddContactsAsync();
                await AddCustomersAsync();
                await AddEndOfDaysAsync();

            }
            else
            {
                throw new Exception();
            }

        }

        private async System.Threading.Tasks.Task AddContactsAsync()
        {
            //ContactId	FirstName	LastName	MobileNo	PhoneNo	EMailAddress	Remarks	UserName

            var ws = xS.GetWS("Contacts");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    Contact con = new Contact
                    {
                        FirstName = dR.Cell(2).GetValue<string>(),
                        LastName = dR.Cell(3).GetValue<string>(),
                        MobileNo = dR.Cell(4).GetValue<string>(),
                        PhoneNo = dR.Cell(5).GetValue<string>(),
                        EMailAddress = dR.Cell(6).GetValue<string>(),
                        Remarks = dR.Cell(7).GetValue<string>(),

                    };

                    db.Contacts.Add(con);
                }
            }

            await db.SaveChangesAsync();
        }
        private async System.Threading.Tasks.Task AddCustomersAsync()
        {
            //CustomerId	FirstName	LastName	Age	DateOfBirth	City	MobileNo	Gender	NoOfBills	TotalAmount	CreatedDate	FullName	Invoices

            var ws = xS.GetWS("Customers");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    Customer cust = new Customer
                    {

                        FirstName = dR.Cell(2).Value.ToString(),
                        LastName = dR.Cell(3).Value.ToString(),
                        Age = dR.Cell(4).GetValue<int>(),
                        DateOfBirth = dR.Cell(5).GetDateTime(),
                        City = dR.Cell(6).Value.ToString(),
                        MobileNo = dR.Cell(7).Value.ToString(),
                        Gender = dR.Cell(8).GetValue<Gender>(),
                        NoOfBills = dR.Cell(9).GetValue<int>(),
                        TotalAmount = dR.Cell(10).GetValue<decimal>(),
                        //FullName = dR.Cell(9).GetValue<string>(),

                    };
                    db.Customers.Add(cust);

                    try
                    {


                    }
                    catch (Exception e)
                    {


                    }

                }
            }

            await db.SaveChangesAsync();
        }

        private async System.Threading.Tasks.Task AddEndOfDaysAsync()
        {
            //EndOfDayId	EOD_Date	Shirting	Suiting	USPA	FM_Arrow	RWT	Access	CashInHand	StoreId

            var ws = xS.GetWS("EndOfDays");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    EndOfDay eod = new EndOfDay
                    {
                        EOD_Date = dR.Cell(2).GetDateTime(),
                        Shirting = dR.Cell(3).GetValue<float>(),
                        Suiting = dR.Cell(4).GetValue<float>(),
                        USPA = dR.Cell(5).GetValue<int>(),
                        FM_Arrow = dR.Cell(6).GetValue<int>(),
                        RWT = dR.Cell(7).GetValue<int>(),
                        Access = dR.Cell(8).GetValue<int>(),
                        CashInHand = dR.Cell(9).GetValue<decimal>(),
                        StoreId =1,// dR.Cell(10).GetValue<int>(),
                        EntryStatus = 0,
                        IsReadOnly = true,
                        UserId = "Admin"



                    };
                    db.EndOfDays.Add(eod);

                    //try
                    //{


                    //}
                    //catch (Exception e)
                    //{


                    //}

                }
            }

            await db.SaveChangesAsync();

        }

    }
}
