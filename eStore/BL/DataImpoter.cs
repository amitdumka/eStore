using eStore.DL.Data;
using eStore.Shared.Models.Banking;
using eStore.Shared.Models.Purchases;
using eStore.Shared.Uploader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace eStore.BL
{
    public class DataImpoter
    {
        private eStoreDbContext _db;
        public string ImportJson(eStoreDbContext db, string mode, dynamic jsonData, string email, string callbackUrl)
        {
            _db = db;
            string returndata = JsonSerializer.Serialize (jsonData);
            try
            {
                switch ( mode )
                {
                    case "Sales":
                        break;

                    case "BankAccountInfo":
                        break;

                    case "BankDeposits":
                        break;

                    case "BankWithdrawal":
                        break;

                    case "AccountNumber":
                        break;

                    case "ChequeLogs":
                        break;

                    case "Bank":
                        var data = JsonSerializer.Deserialize<List<Bank>> (returndata);
                        returndata = $"DataLength:{data.Count}";
                        break;

                    default:
                        returndata = "Option not Supported";
                        break;
                }
            }
            catch ( Exception e )
            {
                returndata = "Error: " + e.Message;
            }

            return returndata;
        }

        private void NotifyByUrl(string callbackUrl, string message)
        {
        }

        private void NotifyByEmail(string email, string message)
        {
        }


        private SortedList<int, string> AddBanks(List<Bank> banks)
        {
            SortedList<int, string> duplicateList = new SortedList<int, string> ();
            foreach ( var bank in banks )
            {

                if ( _db.Set<Bank> ().Any (x => x.BankName == bank.BankName) )
                {
                    duplicateList.Add (bank.BankId, bank.BankName);
                    banks.Remove (bank);
                }
            }
            _db.Banks.AddRange (banks);
            return duplicateList;
        }

        private void AddBrand(List<Brand> brands)
        {

        }
        private void Category(List<Category> categories)
        {
        }
        private void ProductItem(List<ProductItem> productItems) { }
        private void Supplier() { }
        private void Stock() { }
        private void PurchaseItem() { }
        private void PurchaseTaxType() { }

    }


    //public class SaveData<T>
    //{
    //    public static async System.Threading.Tasks.Task<int> SaveAsync(IEnumerable<T> dataList, eStoreDbContext db)
    //    {
    //        IEnumerable<T> dl = (IEnumerable<T>) dataList;

    //        db.AddRange ((IEnumerable<T>) dl);
    //        return await db.SaveChangesAsync ();
    //    }
    //}


    public class ImportVoyData
    {
        public static async System.Threading.Tasks.Task<string> ImportJsonAsync(eStoreDbContext db, string Command, dynamic jsonData, string email, string callbackUrl)
        {
            string returndata = JsonSerializer.Serialize (jsonData);
            int recordCount = 0;
            string rData = "";
            try
            {

                switch ( Command )
                {
                    case "VoyBrandName":
                        var jd = JsonSerializer.Deserialize<IEnumerable<VoyBrandName>> (returndata);
                        await db.AddRangeAsync (jd);
                        break;
                    case "ProductMaster":
                        //recordCount = await SaveData<ProductMaster>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<ProductMaster>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<ProductMaster>> (returndata));
                        break;
                    case "ProductList":
                        // recordCount = await SaveData<ProductIEnumerable>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<ProductIEnumerable>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<ProductList>> (returndata));
                        break;
                    case "TaxRegister":
                        // recordCount = await SaveData<TaxRegister>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<TaxRegister>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<TaxRegister>> (returndata));
                        break;
                    case "VoySaleInvoice":
                        // recordCount = await SaveData<VoySaleInvoice>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<VoySaleInvoice>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<VoySaleInvoice>> (returndata));
                        break;
                    case "VoySaleInvoiceSum":
                        // recordCount = await SaveData<VoySaleInvoiceSum>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<VoySaleInvoiceSum>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<VoySaleInvoiceSum>> (returndata));
                        break;
                    case "VoyPurchaseInward":
                        // recordCount = await SaveData<VoyPurchaseInward>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<VoyPurchaseInward>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<VoyPurchaseInward>> (returndata));
                        break;
                    case "InwardSummary":
                        // recordCount = await SaveData<InwardSummary>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<InwardSummary>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<InwardSummary>> (returndata));
                        break;
                    case "SaleWithCustomer":
                        // recordCount = await SaveData<SaleWithCustomer>.SaveAsync (JsonSerializer.Deserialize<IEnumerable<SaleWithCustomer>> (returndata), db);
                        await db.AddRangeAsync (JsonSerializer.Deserialize<IEnumerable<SaleWithCustomer>> (returndata));
                        break;

                    default:
                        recordCount = -1;
                        rData = "Option Not Found!\t";
                        break;
                }
               
                recordCount = await db.SaveChangesAsync ();
               
                if ( recordCount > 0 )
                {
                    rData += $"DataLength:{recordCount}";
                }
                else if ( recordCount < 0 )
                    rData += "Error: Option not Supported!";
                else
                    rData += "Error: Unkown Error!";


                return rData;
            }
            catch ( Exception e )
            {
                return "Error: " + e.Message;


            }

        }
    }



}