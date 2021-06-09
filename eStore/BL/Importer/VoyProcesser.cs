using System;
using System.Linq;
using eStore.DL.Data;
using eStore.Shared.Models.Purchases;
using eStore.Shared.Models.Sales;

namespace eStore.BL.Importer
{
    public class VoyProcesser
    {
        public VoyProcesser()
        {
        }

        public static int ProcessBrand(eStoreDbContext db)
        {
            var data = db.VoyBrandNames.ToList();
            foreach (var item in data)
            {
                Brand b = new Brand {BCode=item.BRANDCODE, BrandName=item.BRANDNAME };
                db.Brands.Add(b);

            }
            return db.SaveChanges(); 
        }
        

        public static int ProcessSaleSummary(eStoreDbContext db, int StoreId, int year) 
        {
            var data = db.VoySaleInvoiceSums.Where(c => c.InvoiceDate.Year == year).ToList();
            var sData = db.DailySales.Where(c => c.SaleDate.Year == year && c.StoreId == StoreId && !c.IsManualBill).ToList();
            var idata = db.VoySaleInvoices.Where(c => c.InvoiceDate.EndsWith("" + year)).Select(c => new { c.InvoiceNo, c.SalesManName }).ToList();
            var sms=db.Salesmen.ToList();
            foreach (var item in data)
            {
                var eD = sData.Where(c => c.InvNo == item.InvoiceNo).FirstOrDefault();

                if (eD != null)
                {
                    if (eD.SaleDate.Date == item.InvoiceDate.Date) eD.IsMatchedWithVOy = true; else eD.IsMatchedWithVOy = false;
                    if (eD.Amount == item.BillAmt) eD.IsMatchedWithVOy = true; else eD.IsMatchedWithVOy = false;

                    if (eD.TaxAmount == item.TaxAmt) eD.IsMatchedWithVOy = true;
                    else { eD.TaxAmount = item.TaxAmt; eD.IsMatchedWithVOy = true; }

                    switch (item.PaymentMode)
                    {
                        case "CRD": if (eD.PayMode == PayMode.Card) eD.IsMatchedWithVOy = true;
                            else eD.IsMatchedWithVOy = false;
                            break;
                        case "CAS":
                            if (eD.PayMode == PayMode.Cash) eD.IsMatchedWithVOy = true;
                            else eD.IsMatchedWithVOy = false;
                            break;
                        case "MIX":
                            if (eD.PayMode == PayMode.MixPayments) eD.IsMatchedWithVOy = true;
                            else eD.IsMatchedWithVOy = false;
                            break;
                        default:
                            if (eD.PayMode == PayMode.Others) eD.IsMatchedWithVOy = true;
                            else eD.IsMatchedWithVOy = false;
                            break;
                    }

                    if(eD.IsMatchedWithVOy)
                    eD.Remarks += "\t#AutoVerified";
                    else eD.Remarks += "\t#Auto-BugInEntry";
                    db.DailySales.Update(eD);
                }
                else
                {
                    DailySale sale = new DailySale {IsMatchedWithVOy=true, InvNo=item.InvoiceNo, SaleDate=item.InvoiceDate,Amount=item.BillAmt,
                    IsDue=false, IsManualBill=false, IsReadOnly=true,IsSaleReturn=false, IsTailoringBill=false, StoreId=StoreId,
                    UserId="AutoAdded", SalesmanId=3, Remarks="AutoAddedFromVoy", EntryStatus=EntryStatus.Approved, CashAmount=item.BillAmt,
                    TaxAmount=item.TaxAmt 
                    };

                    switch (item.PaymentMode)
                    {
                        case "CRD": sale.PayMode = PayMode.Card;
                            sale.CashAmount = 0;
                            break;
                        case "CAS": sale.PayMode = PayMode.Cash; break;
                        case "MIX": sale.PayMode = PayMode.MixPayments;
                            break;
                        default:
                            sale.PayMode = PayMode.Others;
                            sale.Remarks += "\t#PayMode:" + item.PaymentMode;
                            break;
                    }
                    if (item.TailoringFlag == "Y") sale.IsTailoringBill = true;
                    var smid = idata.Where(c => c.InvoiceNo == sale.InvNo).FirstOrDefault().SalesManName;
                    sale.SalesmanId = sms.Where(c=>c.SalesmanName.Contains(smid)).Select(c=>c.SalesmanId).FirstOrDefault();

                    db.DailySales.Add(sale);
                }
            }


            return db.SaveChanges();
        }
   
    
        public static int ProcessInwardSummary(eStoreDbContext db, int StoreId, int year)
        {
            var data = db.InwardSummaries.Where (c => c.InvoiceDate.Year == year).ToList ();
            var sData = db.Suppliers.ToList ();

            foreach ( var item in data )
            {

                ProductPurchase purchase = new ProductPurchase {
                EntryStatus=EntryStatus.Added, IsPaid=true, IsReadOnly=true, StoreId=StoreId, ShippingCost=0, 
                InvoiceNo=item.InvoiceNo, InWardDate=item.InwardDate, InWardNo=item.InwardNo, PurchaseDate=item.InvoiceDate, 
                Remarks="AutoAdded", TotalAmount=0, TotalBasicAmount=0, TotalCost=0, TotalMRPValue=item.TotalMRPValue, TotalQty=(double)item.TotalQty, 
                TotalTax=0, UserId="AutoAdded", 
                SupplierID= sData.Where(c=>c.SuppilerName.Contains(item.PartyName)).Select(c=>c.SupplierID).FirstOrDefault(),
                };
                db.ProductPurchases.Add (purchase); 
            }
            return db.SaveChanges ();
        }


    
    }
}
