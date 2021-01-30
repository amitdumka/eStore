using System;
using System.Linq;
using eStore.DL.Data;


namespace eStore.Shared.ViewModels.SalePuchase
{
    public class SaleInfoUIVM
    {
            public decimal TodaySale {get;set;}// totalSale;
            public decimal ManualSale {get;set;}// totalManualSale;
            public decimal MonthlySale {get;set;}// totalMonthlySale;
            public decimal DuesAmount {get;set;}// duesamt;
            public decimal CashInHand {get;set;}// cashinhand;
            public decimal LastMonthSale {get;set;}// totalLastMonthlySale;

        public  SaleInfoUIVM GetSaleInfo(eStoreDbContext db, int StoreId)
        {
            //TODO: FixedUI Data
            var totalSale = db.DailySales.Where(c => c.IsManualBill == false && c.SaleDate.Date == DateTime.Today.Date && c.StoreId ==  StoreId).Sum(c => (decimal?)c.Amount) ?? 0;
            var totalManualSale = db.DailySales.Where(c => c.IsManualBill == true && c.SaleDate.Date == DateTime.Today.Date && c.StoreId ==  StoreId).Sum(c => (decimal?)c.Amount) ?? 0;
            var totalMonthlySale = db.DailySales.Where(c => c.SaleDate.Year == DateTime.Today.Year && c.SaleDate.Month == DateTime.Today.Month && c.StoreId ==  StoreId).Sum(c => (decimal?)c.Amount) ?? 0;
            var totalLastMonthlySale = db.DailySales.Where(c => c.SaleDate.Year == DateTime.Today.Year && c.SaleDate.Month == DateTime.Today.Month - 1 && c.StoreId ==  StoreId).Sum(c => (decimal?)c.Amount) ?? 0;
            var duesamt = db.DuesLists.Where(c => c.IsRecovered == false && c.StoreId ==  StoreId).Sum(c => (decimal?)c.Amount) ?? 0;
            var cashinhand = (decimal)0.00;
            return this;
        }
    }
}
