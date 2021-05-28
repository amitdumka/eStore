using eStore.DL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.BL.Reports.CAReports
{
    public class FinReport
    {
        private eStoreDbContext db;
        private int StoreId;
        private int StartYear, EndYear;
        private const int SM = 4;
        private const int EM = 3;

        private DateTime StartDate,EndDate;
        private string FileName = "FINReport_";
        private string Ext = ".pdf";
        private bool isPDF=true;

        public FinReport(eStoreDbContext con, int storeId, int SYear, int EYear, bool IsPdf)
        {
            db = con; StoreId = storeId; StartYear = SYear; EndYear = EYear;
            StartDate = new DateTime (StartYear, SM, 1).Date;
            EndDate =    new DateTime (EndYear, EM, 31).Date;
            FileName += $"{StartYear}_{EndYear}_{DateTime.UtcNow.ToFileTime ()}";
            isPDF = IsPdf; 
        }


        private void GenerateSaleData() { }
        private void GeneratePurchaseData() { }
        private void GenerateExpensesData() { }
        private void GenerateSalaryData() { }
        private void GenerateBankData() { }
        private void GeneratePaymentData() { }
        private void GenerateReceiptData() { }
        private void GenerateCashBook() { }

    }

    class ToExcel
    {
        public string FileName { get; set; }
        public string PathName { get; set; }


    }
    class ToPDF
    {
        public string FileName { get; set; }
        public string PathName { get; set; }

    }
    class Headers
    {
        
    }
    class Footers
    {

    }

}
