using System;
using System.Collections.Generic;
using System.Linq;
using eStore.DL.Data;
using eStore.Shared.Models.Purchases;
using eStore.Shared.Models.Sales;
using eStore.Shared.Models.Stores;
using eStore.Shared.Uploader;

namespace eStore.BL.Importer
{
    public class VoyProcesser
    {
        public VoyProcesser()
        {
        }

        public static int ProcessBrand(eStoreDbContext db)
        {
            var data = db.VoyBrandNames.ToList ();
            foreach ( var item in data )
            {
                Brand b = new Brand { BCode = item.BRANDCODE, BrandName = item.BRANDNAME };
                db.Brands.Add (b);

            }
            return db.SaveChanges ();
        }

        public static int ProcessCusomterSale(eStoreDbContext db, int StoreId, int year)
        {
            // TODO: here reduce data size as much as possible
            var data = db.SaleWithCustomers.Where(c => c.InvoiceDate.Year == year).ToList();
            var custs = data.Select(c => new Customer { FirstName = c.CustomerName, City = c.Address, MobileNo = c.Phone }).Distinct().ToList();
            foreach (var item in custs)
            {
                if (!string.IsNullOrEmpty(item.FirstName))
                {
                    var names = item.FirstName.Split(" ");
                    if (names[0] == "Mrs" || names[0] == "Ms")
                        item.Gender = Gender.Female;
                    else
                        item.Gender = Gender.Male;
                    item.FirstName = names[1];
                    for (int i = 2; i < names.Length; i++) item.LastName += names[i];
                    item.Age = 30; ; item.CreatedDate = DateTime.Today;

                    item.TotalAmount = data.Where(c => c.Phone == item.MobileNo).Select(c => new { billAmt = (decimal)c.BillAmt }).Sum(c => c.billAmt);
                    item.NoOfBills = data.Where(c => c.Phone == item.MobileNo).Count();
                }
                else
                {
                    custs.Remove(item);
                }

               
            }
            db.Customers.AddRange(custs);
            return db.SaveChanges();


        }

        public static int ProcessSaleSummary(eStoreDbContext db, int StoreId, int year)
        {
            var data = db.VoySaleInvoiceSums.Where (c => c.InvoiceDate.Year == year).ToList ();
            var sData = db.DailySales.Where (c => c.SaleDate.Year == year && c.StoreId == StoreId && !c.IsManualBill).ToList ();
            var idata = db.VoySaleInvoices.Where (c => c.InvoiceDate.EndsWith ("" + year)).Select (c => new { c.InvoiceNo, c.SalesManName }).ToList ();
            var sms = db.Salesmen.ToList ();
            foreach ( var item in data )
            {
                var eD = sData.Where (c => c.InvNo == item.InvoiceNo).FirstOrDefault ();

                if ( eD != null )
                {
                    if ( eD.SaleDate.Date == item.InvoiceDate.Date )
                        eD.IsMatchedWithVOy = true;
                    else
                        eD.IsMatchedWithVOy = false;
                    if ( eD.Amount == item.BillAmt )
                        eD.IsMatchedWithVOy = true;
                    else
                        eD.IsMatchedWithVOy = false;

                    if ( eD.TaxAmount == item.TaxAmt )
                        eD.IsMatchedWithVOy = true;
                    else
                    { eD.TaxAmount = item.TaxAmt; eD.IsMatchedWithVOy = true; }

                    switch ( item.PaymentMode )
                    {
                        case "CRD":
                            if ( eD.PayMode == PayMode.Card )
                                eD.IsMatchedWithVOy = true;
                            else
                                eD.IsMatchedWithVOy = false;
                            break;
                        case "CAS":
                            if ( eD.PayMode == PayMode.Cash )
                                eD.IsMatchedWithVOy = true;
                            else
                                eD.IsMatchedWithVOy = false;
                            break;
                        case "MIX":
                            if ( eD.PayMode == PayMode.MixPayments )
                                eD.IsMatchedWithVOy = true;
                            else
                                eD.IsMatchedWithVOy = false;
                            break;
                        default:
                            if ( eD.PayMode == PayMode.Others )
                                eD.IsMatchedWithVOy = true;
                            else
                                eD.IsMatchedWithVOy = false;
                            break;
                    }

                    if ( eD.IsMatchedWithVOy )
                        eD.Remarks += "\t#AutoVerified";
                    else
                        eD.Remarks += "\t#Auto-BugInEntry";
                    db.DailySales.Update (eD);
                }
                else
                {
                    DailySale sale = new DailySale
                    {
                        IsMatchedWithVOy = true,
                        InvNo = item.InvoiceNo,
                        SaleDate = item.InvoiceDate,
                        Amount = item.BillAmt,
                        IsDue = false,
                        IsManualBill = false,
                        IsReadOnly = true,
                        IsSaleReturn = false,
                        IsTailoringBill = false,
                        StoreId = StoreId,
                        UserId = "AutoAdded",
                        SalesmanId = 3,
                        Remarks = "AutoAddedFromVoy",
                        EntryStatus = EntryStatus.Approved,
                        CashAmount = item.BillAmt,
                        TaxAmount = item.TaxAmt
                    };

                    switch ( item.PaymentMode )
                    {
                        case "CRD":
                            sale.PayMode = PayMode.Card;
                            sale.CashAmount = 0;
                            break;
                        case "CAS":
                            sale.PayMode = PayMode.Cash;
                            break;
                        case "MIX":
                            sale.PayMode = PayMode.MixPayments;
                            break;
                        default:
                            sale.PayMode = PayMode.Others;
                            sale.Remarks += "\t#PayMode:" + item.PaymentMode;
                            break;
                    }
                    if ( item.TailoringFlag == "Y" )
                        sale.IsTailoringBill = true;
                    var smid = idata.Where (c => c.InvoiceNo == sale.InvNo).FirstOrDefault ().SalesManName;
                    sale.SalesmanId = sms.Where (c => c.SalesmanName.Contains (smid)).Select (c => c.SalesmanId).FirstOrDefault ();

                    db.DailySales.Add (sale);
                }
            }


            return db.SaveChanges ();
        }

        public static int ProcessInwardSummary(eStoreDbContext db, int StoreId, int year)
        {
            var data = db.InwardSummaries.Where (c => c.InvoiceDate.Year == year).ToList ();
            var sData = db.Suppliers.ToList ();

            foreach ( var item in data )
            {

                ProductPurchase purchase = new ProductPurchase
                {
                    EntryStatus = EntryStatus.Added,
                    IsPaid = true,
                    IsReadOnly = true,
                    StoreId = StoreId,
                    ShippingCost = 0,
                    InvoiceNo = item.InvoiceNo,
                    InWardDate = item.InwardDate,
                    InWardNo = item.InwardNo,
                    PurchaseDate = item.InvoiceDate,
                    Remarks = "AutoAdded",
                    TotalAmount = 0,
                    TotalBasicAmount = 0,
                    TotalCost = 0,
                    TotalMRPValue = item.TotalMRPValue,
                    TotalQty = (double) item.TotalQty,
                    TotalTax = 0,
                    UserId = "AutoAdded",
                    SupplierID = sData.Where (c => c.SuppilerName.Contains (item.PartyName)).Select (c => c.SupplierID).FirstOrDefault (),
                };
                db.ProductPurchases.Add (purchase);
            }
            return db.SaveChanges ();
        }

        public static int ProcessPurchase(eStoreDbContext db, int StoreId, int year)
        {
            var data = db.VoyPurchaseInwards.Where (c => c.GRNDate.Year == year).OrderBy (c => c.InvoiceNo).ToList ();
            if ( data != null && data.Count > 0 )
            {
                var pData = db.ProductPurchases.Where (c => c.StoreId == StoreId && c.InWardDate.Year == year).OrderBy (c => c.InvoiceNo).ToList ();
                ProductPurchase pur = null;
               
                foreach ( var item in data )
                {
                    if (pur == null)
                    {
                        pur = pData.Where(c => c.InvoiceNo == item.InvoiceNo).FirstOrDefault();
                        pur.PurchaseItems = new List<PurchaseItem>();
                        // create purchase item 

                    }
                    else if (pur.InvoiceNo != item.InvoiceNo) {

                        pur = pData.Where(c => c.InvoiceNo == item.InvoiceNo).FirstOrDefault();
                        pur.PurchaseItems = new List<PurchaseItem>();
                    }

                    //TODO: Need to Add or Create ProductItem and get ProductId
                    PurchaseItem pItem = new PurchaseItem {
                       Barcode=item.Barcode, Cost=item.Cost, CostValue=item.CostValue, Qty=(double)item.Quantity,
                       TaxAmout=item.TaxAmt
                    };
                    pur.TotalBasicAmount += item.Cost; pur.TotalTax += item.TaxAmt;
                    pur.PurchaseItems.Add(pItem);
                    UpdateProductItem(db, item.Barcode, item.MRP, item.Cost, "", null, false);
                    
                }
                db.ProductPurchases.UpdateRange(pData);
                return db.SaveChanges();
            }
            else
            {
                return -999;
            }


        }

        public static int ProcessProductItem(eStoreDbContext db, string brandName)
        {
            var data = db.TaxRegisters.Where (c => c.BrandName == brandName && c.InvoiceType == "Sales").Select (c => new { c.BARCODE, c.StyleCode, c.ProductName, c.ItemDesc, c.TaxRate, c.TaxDesc }).Distinct ().ToList ();
            var cData = db.Categories.ToList ();
            int brandId = db.Brands.Where (c => c.BrandName == brandName).Select (c => c.BrandId).FirstOrDefault ();
            foreach ( var purchase in data )
            {
                var cats = purchase.ProductName.Split ("/");
                ProductItem pItem = new ProductItem
                {
                    Barcode = purchase.BARCODE,
                    Cost = 0,
                    MRP = 0,
                    StyleCode = purchase.StyleCode,
                    ProductName = purchase.ProductName,
                    ItemDesc = purchase.ItemDesc,
                    HSNCode = "",
                    TaxRate = purchase.TaxRate,
                    BrandId = brandId,
                    MainCategory = cData.Where (c => c.CategoryName.Contains (cats [0])).FirstOrDefault (),
                    ProductCategory = cData.Where (c => c.CategoryName.Contains (cats [1])).FirstOrDefault (),
                    ProductType = cData.Where (c => c.CategoryName.Contains (cats [2])).FirstOrDefault (),
                 };

                switch ( cats [0] )
                {
                    case "Shirting":
                    case "Suiting":
                        pItem.Categorys = ProductCategory.Fabric;
                        pItem.Units = Unit.Meters;
                        break;
                    case "Apparel":
                        pItem.Categorys = ProductCategory.ReadyMade;
                        pItem.Units = Unit.Pcs;
                        break;
                    // case ProductCategory.Accessiories:
                    //    break;
                    case "Tailoring":
                        pItem.Categorys = ProductCategory.Tailoring;
                        pItem.Units = Unit.Nos;
                        break;
                    //case ProductCategory.Trims:
                    //    break;
                    case "Promo":
                        pItem.Categorys = ProductCategory.PromoItems;
                        pItem.Units = Unit.Nos;
                        break;
                    //case ProductCategory.Coupons:
                    //    break;
                    //case ProductCategory.GiftVouchers:
                    //    break;
                    //case ProductCategory.Others:
                    //    break;
                    default:
                        pItem.Categorys = ProductCategory.Others;
                        pItem.Units = Unit.Nos;
                        break;
                }

                db.ProductItems.Add (pItem);

            }
            return db.SaveChanges ();
        }



        private static int GetSalesPersonId(eStoreDbContext db, string salesman)
        {
            try
            {
                var id = db.Salesmen.Where (c => c.SalesmanName == salesman).FirstOrDefault ().SalesmanId;
                if ( id > 0 )
                {
                    return id;
                }
                else
                {
                    Salesman sm = new Salesman { SalesmanName = salesman };
                    db.Salesmen.Add (sm);
                    db.SaveChanges ();
                    return sm.SalesmanId;
                }
            }
            catch ( Exception )
            {
                Salesman sm = new Salesman { SalesmanName = salesman };
                db.Salesmen.Add (sm);
                db.SaveChanges ();
                return sm.SalesmanId;
            }
        }

        private static int AddOrUpdateStock(eStoreDbContext db, int StoreId, string barCode, double inQty, double outQty, Unit unit)
        {
            Stock stcks = db.Stocks.Where (c => c.BarCode == barCode).FirstOrDefault ();
            if ( stcks != null )
            {
                stcks.PurchaseQty += inQty;
                stcks.SaleQty += outQty;
                db.Stocks.Update (stcks);
            }
            else
            {
                stcks = new Stock
                {
                    PurchaseQty = inQty,
                    SaleQty = outQty,
                    Units = unit,
                    StoreId = StoreId,
                    BarCode = barCode,
                    HoldQty = 0,
                    IsReadOnly = false,
                    UserId = "AutoAdd",

                };
                db.Stocks.Add (stcks);
            }
            return db.SaveChanges ();

        }

        private static int UpdateProductItem(eStoreDbContext db, string barcode, decimal Mrp, decimal cost, string hsn, Size? size, bool saveIt=false)
        {

            var pItem = db.ProductItems.Where (c => c.Barcode == barcode).FirstOrDefault ();
            if ( pItem != null )
            {
                pItem.MRP = Mrp;
                pItem.Cost = cost;
                pItem.HSNCode = hsn;
                if ( size != null )
                    pItem.Size = (Size) size;
                db.ProductItems.Update (pItem);
            }
            if (saveIt)
                return db.SaveChanges();
            else return -111;

        }



    }


}
