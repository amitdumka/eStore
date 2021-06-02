using eStore.DL.Data;
using eStore.Shared.Models.Banking;
using eStore.Shared.Models.Purchases;
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
        public async System.Threading.Tasks.Task<int> SaveAsync(List<T> dataList, eStoreDbContext db)
        {
            await db.AddRangeAsync (dataList);
            return await db.SaveChangesAsync ();
        }
    }



}