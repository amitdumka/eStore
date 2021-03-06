﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    class Expenses : IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet xs = new XSheet(path, "Expenses");
            xs.AddSheet<Expense>("Expenses", db.Expenses.OrderBy(c => c.ExpDate));
            xs.AddSheet<Payment>("Payments", db.Payments.OrderBy(c => c.PayDate));
            xs.AddSheet<Receipt>("Receipts", db.Receipts.OrderBy(c => c.RecieptDate));
            xs.AddSheet<CashReceipt>("CashReceipts", db.CashReceipts.OrderBy(c => c.InwardDate));
            xs.AddSheet<CashPayment>("CashPayments", db.CashPayments.OrderBy(c => c.PaymentDate));
            xs.AddSheet<PettyCashExpense>("PettyCashExpenses", db.PettyCashExpenses.OrderBy(c => c.ExpDate));
            xs.AddSheet<ArvindPayment>("ArvindPayments", db.ArvindPayments.OrderBy(c => c.OnDate));
            //Rent
            xs.AddSheet<Rent>("Rent", db.Rents.OrderBy(c => c.OnDate));
            xs.AddSheet<RentedLocation>("RentedLocation", db.RentedLocations.OrderBy(c => c.RentedLocationId));
            //Electricity
            xs.AddSheet<ElectricityConnection>("ElectricityConnection", db.ElectricityConnections.OrderBy(c => c.ConusumerId));
            xs.AddSheet<EletricityBill>("EletricityBill", db.EletricityBills.OrderBy(c => c.BillDate));
            xs.AddSheet<EBillPayment>("BillPayments", db.BillPayments.OrderBy(c => c.PaymentDate));
            return xs.WB;
        }

         Task<XLWorkbook> IXSE.ToExcelAsync(AprajitaRetailsDbContext db, string path)
        {
            throw new System.NotImplementedException();
        }
    }
}

