using eStore.BL.Reports.Accounts;
using eStore.DL.Data;
using eStore.Shared.ViewModels;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Path = System.IO.Path;

namespace eStore.BL.Reports.CAReports
{
    internal class ConData
    {
        public const string CName = "Aprajita Retails";
        public const string CAdd = "Bhagalpur Road, Dumka";
        public const string WWWroot = "wwwroot";
    }

    public class FinReport
    {
        private eStoreDbContext db;
        private int StoreId;
        private int StartYear, EndYear;
        private const int SM = 4;
        private const int EM = 3;

        private DateTime StartDate, EndDate;
        private string FileName = "FINReport_";
        private string Ext = ".pdf";
        private bool isPDF = true;

        public FinReport(eStoreDbContext con, int storeId, int SYear, int EYear, bool IsPdf)
        {
            db = con;
            StoreId = storeId;
            StartYear = SYear;
            EndYear = EYear;
            StartDate = new DateTime (StartYear, SM, 1).Date;
            EndDate = new DateTime (EndYear, EM, 31).Date;
            FileName += $"{StartYear}_{EndYear}_{DateTime.UtcNow.ToFileTime ()}";
            isPDF = IsPdf;
        }

        public string GetFinYearReport(int rep)
        {

            switch ( rep )
            {
                case 1:
                    return GenerateSaleData ();
                case 2:
                    return GenerateCashBook ();
                case 3:
                    return GenerateSalaryData ();
                case 4:
                    return GenerateExpensesData ();
                case 5:
                    return GeneratePaymentData ();
                case 6:
                    return GenerateReceiptData ();
                default:
                    return "Error Selection";
            }
        }


        private void GeneratePurchaseData()
        {
        }

        private void GenerateBankData()
        {

        }

        private string GenerateCashBook()
        {
            CashBookManager manager = new CashBookManager (StoreId);

            var data = manager.GetMontlyCashBook (db, DateTime.Today, StoreId);
            List<CashBook> CB = new List<CashBook> ();


            for ( int i = 4 ; i <= 12 ; i++ )
            {
                CB.AddRange (manager.GetMontlyCashBook (db, new DateTime (StartYear, i, 1), StoreId));
            }
            for ( int i = 1 ; i <= 3 ; i++ )
            {
                CB.AddRange (manager.GetMontlyCashBook (db, new DateTime (EndYear, i, 1), StoreId));
            }
            float [] columnWidths = { 1, 5, 15, 5, 5, 15, 5, 5 };
            Cell [] HeaderCell = new Cell []{
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Date").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Particulars").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Cash IN").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Cash Out").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Balance").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("").SetTextAlignment(TextAlignment.CENTER)) };
            Table table = GenTable (columnWidths, HeaderCell);
            int count = 0;
            foreach ( var item in CB )
            {
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.EDate.ToShortDateString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Particulars)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.CashIn.ToString ("0.##"))));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.CashOut.ToString ("0.##"))));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.CashBalance.ToString ("0.##"))));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph ("")));
            }
            List<Table> dataTable = new List<Table> ();
            dataTable.Add (table);
            return PrintPDF ("Sales", dataTable);
        }
        private string GenerateSaleData()
        {
            var sale = db.DailySales.Where (c => !c.IsManualBill && !c.IsSaleReturn && !c.IsTailoringBill && c.StoreId == StoreId && c.SaleDate.Date >= StartDate.Date && c.SaleDate.Date <= EndDate.Date).ToList ();
            var manualBill = db.DailySales.Where (c => c.IsManualBill && !c.IsSaleReturn && c.StoreId == StoreId && c.SaleDate.Date >= StartDate.Date && c.SaleDate.Date <= EndDate.Date).ToList ();
            var tailorBill = db.DailySales.Where (c => !c.IsSaleReturn && !c.IsTailoringBill && c.StoreId == StoreId && c.SaleDate.Date >= StartDate.Date && c.SaleDate.Date <= EndDate.Date).ToList ();
            var salereturn = db.DailySales.Where (c => !c.IsSaleReturn && c.StoreId == StoreId && c.SaleDate.Date >= StartDate.Date && c.SaleDate.Date <= EndDate.Date).ToList ();
            float [] columnWidths = { 1, 5, 15, 5, 5, 15, 5, 5 };
            Cell [] HeaderCell = new Cell []{
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Date").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Invoice No").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Payment Mode").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Remarks").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Cash Amount").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("NON Cash Amount").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Bill Amount").SetTextAlignment(TextAlignment.CENTER))


            };
            Div d = new Div ();
            d.Add (new Paragraph ("On Book Sale(GST Paid)").SetFontColor (ColorConstants.MAGENTA));

            Table table = GenTable (columnWidths, HeaderCell);
            table.SetCaption (d);
            int count = 0;
            foreach ( var item in sale )
            {
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.SaleDate.ToShortDateString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.InvNo)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.CashAmount.ToString ("0.##"))));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( item.Amount - item.CashAmount ).ToString ("0.##"))));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));

            }
            Div d2 = new Div ();                      
            d2.Add (new Paragraph ("Manual Bill Sale").SetFontColor (ColorConstants.MAGENTA));

            Table table2 = GenTable (columnWidths, HeaderCell);
            table.SetCaption (d2);
            count = 0;
            foreach ( var item in manualBill )
            {
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.SaleDate.ToShortDateString ())));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.InvNo)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.CashAmount.ToString ("0.##"))));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( item.Amount - item.CashAmount ).ToString ("0.##"))));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));

            }
            Div d3 = new Div ();
            d3.Add (new Paragraph ("Tailoring Bill Sale").SetFontColor (ColorConstants.MAGENTA));

            Table table3 = GenTable (columnWidths, HeaderCell);
            table.SetCaption (d3);
            count = 0;
            foreach ( var item in tailorBill )
            {
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.SaleDate.ToShortDateString ())));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.InvNo)));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.CashAmount.ToString ("0.##"))));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( item.Amount - item.CashAmount ).ToString ("0.##"))));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));

            }
            Div d4 = new Div ();
            d4.Add (new Paragraph (" Sale Return").SetFontColor (ColorConstants.MAGENTA));

            Table table4 = GenTable (columnWidths, HeaderCell);
            table.SetCaption (d4);
            count = 0;
            foreach ( var item in salereturn )
            {
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.SaleDate.ToShortDateString ())));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.InvNo)));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.CashAmount.ToString ("0.##"))));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( item.Amount - item.CashAmount ).ToString ("0.##"))));
                table3.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));

            }
            List<Table> dataTable = new List<Table> ();
            dataTable.Add (table);
            dataTable.Add (table2);
            dataTable.Add (table3);
            dataTable.Add (table4);
            return PrintPDF ("Sales", dataTable);

        }
        private string GenerateSalaryData()
        {
            var data = db.SalaryPayments.Include (c => c.Employee).Where (c => c.StoreId == StoreId && c.PaymentDate.Date >= StartDate.Date && c.PaymentDate.Date <= EndDate.Date).ToList ();
            var advData = db.StaffAdvanceReceipts.Where (c => c.StoreId == StoreId && c.ReceiptDate.Date >= StartDate.Date && c.ReceiptDate.Date <= EndDate.Date).ToList ();
            float [] columnWidths = { 1, 5, 15, 5, 5, 15, 5, 5 };
            Cell [] HeaderCell = new Cell []{
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Date").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("EmployeeName").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("SalaryMonth").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Payment Mode").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Details").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Amount").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("").SetTextAlignment(TextAlignment.CENTER))


            };
            Div d = new Div ();
            d.Add (new Paragraph ("Salary Payments").SetFontColor (ColorConstants.MAGENTA));

            Table table = GenTable (columnWidths, HeaderCell);
            table.SetCaption (d);
            int count = 0;
            foreach ( var item in data )
            {
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PaymentDate.ToShortDateString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Employee.StaffName)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.SalaryMonth)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Details)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph ("+")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));

            }
            Table table2 = GenTable (columnWidths, HeaderCell);
            Div d2 = new Div ();
            d2.Add (new Paragraph ("Advance Reciepts").SetFontColor (ColorConstants.MAGENTA));
            table2.SetCaption (d2);
            count = 0;
            foreach ( var item in advData )
            {
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.ReceiptDate.ToShortDateString ())));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Employee.StaffName)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph ("")));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Details)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph ("-")));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));

            }
            List<Table> dataTable = new List<Table> ();
            dataTable.Add (table);
            dataTable.Add (table2);
            return PrintPDF ("Salary", dataTable);
        }
        private string GenerateExpensesData()
        {
            var data = db.Expenses.Include (c => c.FromAccount).Where (c => c.StoreId == StoreId && c.OnDate.Date >= StartDate.Date && c.OnDate.Date <= EndDate.Date).ToList ();
            var cashData = db.CashPayments.Include (c => c.Mode).Where (c => c.StoreId == StoreId && c.PaymentDate.Date >= StartDate.Date && c.PaymentDate.Date <= EndDate.Date).ToList ();
            float [] columnWidths = { 1, 5, 15, 15, 5, 5, 15, 10, 5 };

            Cell [] HeaderCell = new Cell []{
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Date").SetTextAlignment(TextAlignment.CENTER)),
                     new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Particulars").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("PartyName").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Payment Details").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Mode").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Bank").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Remarks").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Amount").SetTextAlignment(TextAlignment.CENTER))
            };

            Div d = new Div ();
            d.Add (new Paragraph ("Expenses").SetFontColor (ColorConstants.MAGENTA));

            Table table = GenTable (columnWidths, HeaderCell);
            table.SetCaption (d);
            int count = 0;
            foreach ( var item in data )
            {
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.OnDate.ToShortDateString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Particulars)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PartyName)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PaymentDetails)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.FromAccount.Account)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));
            }

            HeaderCell = new Cell []{
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Date").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Particulars").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("PartyName").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Voucher No").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Remarks").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Amount").SetTextAlignment(TextAlignment.CENTER))
            };
            Table table2 = GenTable (columnWidths, HeaderCell);
            Div d2 = new Div ();
            d2.Add (new Paragraph ("Cash Expenses").SetFontColor (ColorConstants.MAGENTA));
            table2.SetCaption (d2);
            count = 0;
            foreach ( var item in cashData )
            {
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PaymentDate.ToShortDateString ())));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Mode.Transcation)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PaidTo)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.SlipNo)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table2.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));
            }
            List<Table> dataTable = new List<Table> ();
            dataTable.Add (table);
            dataTable.Add (table2);
            return PrintPDF ("Expenses", dataTable);
        }
        private string GeneratePaymentData()
        {
            var data = db.Payments.Include (c => c.FromAccount).Where (c => c.StoreId == StoreId && c.OnDate.Date >= StartDate.Date && c.OnDate.Date <= EndDate.Date).ToList ();
            float [] columnWidths = { 1, 5, 15, 5, 5, 15, 10, 5 };
            Cell [] HeaderCell = new Cell []{
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Date").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("PartyName").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("SlipNo").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Mode").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Bank").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Remarks").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Amount").SetTextAlignment(TextAlignment.CENTER))
            };
            int count = 0;
            Table table = GenTable (columnWidths, HeaderCell);
            foreach ( var item in data )
            {
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.OnDate.ToShortDateString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PartyName)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PaymentSlipNo)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.FromAccount.Account)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));
            }
            List<Table> dataTable = new List<Table> ();
            dataTable.Add (table);

            return PrintPDF ("Payments", dataTable);
        }

        private string GenerateReceiptData()
        {
            var data = db.Receipts.Include (c => c.FromAccount).Where (c => c.StoreId == StoreId && c.OnDate.Date >= StartDate.Date && c.OnDate.Date <= EndDate.Date).ToList ();
            var cashData = db.CashReceipts.Include (c => c.Mode).Where (c => c.StoreId == StoreId && c.InwardDate.Date >= StartDate.Date && c.InwardDate.Date <= EndDate.Date).ToList ();
            float [] columnWidths = { 1, 5, 15, 5, 5, 15, 10, 5 };

            Cell [] HeaderCell = new Cell []{
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Date").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("PartyName").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("SlipNo").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Mode").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Bank").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Remarks").SetTextAlignment(TextAlignment.CENTER)),
                    new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Amount").SetTextAlignment(TextAlignment.CENTER))
            };

            Div d = new Div ();
            d.Add (new Paragraph ("Receipts").SetFontColor (ColorConstants.MAGENTA));

            Table table = GenTable (columnWidths, HeaderCell);
            table.SetCaption (d);
            int count = 0;
            foreach ( var item in data )
            {
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.OnDate.ToShortDateString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PartyName)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.RecieptSlipNo)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.PayMode.ToString ())));
                if(item.FromAccount!=null && !String.IsNullOrEmpty(item.FromAccount.Account))
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.FromAccount.Account)));
                else
                    table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph ("")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));
            }

            Table table2 = GenTable (columnWidths, HeaderCell);
            Div d2 = new Div ();
            d2.Add (new Paragraph ("\nCash Receipts").SetFontColor (ColorConstants.MAGENTA));
            table2.SetCaption (d2);
            count = 0;
            foreach ( var item in cashData )
            {
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (( ++count ) + "")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.InwardDate.ToShortDateString ())));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.ReceiptFrom)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.SlipNo)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Mode.Transcation)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph ("")));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Remarks)));
                table.AddCell (new Cell ().SetTextAlignment (TextAlignment.CENTER).Add (new Paragraph (item.Amount.ToString ("0.##"))));
            }
            List<Table> dataTable = new List<Table> ();
            dataTable.Add (table);
            dataTable.Add (table2);
            return PrintPDF ("Reciepts", dataTable);
        }

        private Table GenTable(float [] columnWidths, Cell [] HeaderCell)
        {
            Cell [] FooterCell = new []
           {
                new Cell(1,4).Add(new Paragraph(ConData.CName +" / "+ConData.CAdd) .SetFontColor(DeviceGray.GRAY)),
                new Cell(1,2).Add(new Paragraph("D:"+DateTime.Now) .SetFontColor(DeviceGray.GRAY)),
            };
            Table table = new Table (UnitValue.CreatePercentArray (columnWidths)).SetBorder (new OutsetBorder (2));
            foreach ( Cell hfCell in HeaderCell )
            {
                table.AddHeaderCell (hfCell);
            }
            foreach ( Cell hfCell in FooterCell )
            {
                table.AddFooterCell (hfCell);
            }
            return table;
        }

        private string PrintPDF(string repName, List<Table> dataTable)
        {
            string fileName = $"FinReport_{repName}_{StartYear}_{EndYear}_{DateTime.Now.ToFileTimeUtc ()}.pdf";
            string path = Path.Combine (ConData.WWWroot, fileName);
            using PdfWriter pdfWriter = new PdfWriter (fileName);
            using PdfDocument pdfDoc = new PdfDocument (pdfWriter);
            using Document doc = new Document (pdfDoc, PageSize.A4);

            Paragraph header = new Paragraph (ConData.CName + "\n")
               .SetTextAlignment (iText.Layout.Properties.TextAlignment.CENTER)
               .SetFontColor (ColorConstants.RED);
            header.Add (ConData.CAdd + $"\n\n {repName} Report\n");
            doc.Add (header);

            Paragraph info = new Paragraph ($"\n\nFinancial Year:\t {StartYear}-{EndYear}")
                .SetTextAlignment (iText.Layout.Properties.TextAlignment.CENTER)
               .SetFontColor (ColorConstants.BLUE);
            doc.Add (info);

            if ( dataTable != null )
                foreach ( var item in dataTable )
                {
                    doc.Add (item);
                }
            else
            {
                Paragraph nodata= new Paragraph("No Data Avilable!").SetTextAlignment (iText.Layout.Properties.TextAlignment.CENTER).SetFontColor (ColorConstants.GREEN);
                doc.Add (nodata);
            }
            doc.Close ();
            pdfDoc.Close ();
            pdfWriter.Close ();
            return fileName;
        }
    }


}