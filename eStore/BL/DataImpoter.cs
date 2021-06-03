using eStore.DL.Data;
using eStore.Shared.Models.Banking;
using eStore.Shared.Models.Purchases;
using eStore.Shared.Uploader;
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


    public class SaveData<T>
    {
        public static async System.Threading.Tasks.Task<int> SaveAsync(List<T> dataList, eStoreDbContext db)
        {
            await db.AddRangeAsync (dataList);
            return await db.SaveChangesAsync ();
        }
    }


    public class ImportVoyData
    {
        public static async System.Threading.Tasks.Task<string> ImportJsonAsync(eStoreDbContext db, string Command, dynamic jsonData, string email, string callbackUrl)
        {
            string returndata = JsonSerializer.Serialize (jsonData);
            int recordCount = 0;
            try
            {
               
                switch ( Command )
                {
                    case "VoyBrandName":
                        recordCount = await SaveData<VoyBrandName>.SaveAsync( JsonSerializer.Deserialize<List<VoyBrandName>> (returndata),db);
                      
                        break;
                    case "ProductMaster":
                        recordCount = await SaveData< ProductMaster>.SaveAsync (JsonSerializer.Deserialize<List<ProductMaster>> (returndata), db);
                        break;
                    case "ProductList":
                        recordCount = await SaveData<ProductList>.SaveAsync (JsonSerializer.Deserialize<List<ProductList>> (returndata), db);
                        break;
                    case "TaxRegister":
                        recordCount = await SaveData<TaxRegister>.SaveAsync (JsonSerializer.Deserialize<List<TaxRegister>> (returndata), db);
                        break;
                    case "VoySaleInvoice":
                        recordCount = await SaveData<VoySaleInvoice>.SaveAsync (JsonSerializer.Deserialize<List<VoySaleInvoice>> (returndata), db);
                        break;
                    case "VoySaleInvoiceSum":
                        recordCount = await SaveData<VoySaleInvoiceSum>.SaveAsync (JsonSerializer.Deserialize<List<VoySaleInvoiceSum>> (returndata), db);
                        break;
                    case "VoyPurchaseInward":
                        recordCount = await SaveData<VoyPurchaseInward>.SaveAsync (JsonSerializer.Deserialize<List<VoyPurchaseInward>> (returndata), db);
                        break;
                    case "InwardSummary":
                        recordCount = await SaveData<InwardSummary>.SaveAsync (JsonSerializer.Deserialize<List<InwardSummary>> (returndata), db);
                        break;
                    case "SaleWithCustomer":
                        recordCount = await SaveData<SaleWithCustomer>.SaveAsync (JsonSerializer.Deserialize<List<SaleWithCustomer>> (returndata), db);
                        break; 

                    default:
                        recordCount = -1;
                        break;
                }

            }
            catch ( Exception e )
            {
                returndata = "Error: " + e.Message;
            }

            if ( recordCount > 0 )
            {
                returndata = $"DataLength:{recordCount}";
            }
            else if ( recordCount < 0 )
                returndata = "Error: Option not Supported!";
            else
                returndata = "Error: Unkown Error!";


            return returndata;
        }
    }



}