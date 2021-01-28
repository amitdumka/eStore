using System;
using eStore.DL.Data;
using eStore.Shared.Models.Stores;

namespace eStore.BL.Commons
{
    public class StoreManager
    {
        public static async System.Threading.Tasks.Task<int> AddStoreCloseAsync(eStoreDbContext db, int StoreId)
        {
            StoreClose sc = new StoreClose {
                 IsReadOnly=true, StoreId=StoreId, UserId="Admin", Remarks="", ClosingDate= DateTime.Now
            };
            //TODO: there should be store opening and Closing Date;
            //TODO: need to check system and brower type to verify for malpractice.
            await db.StoreCloses.AddAsync(sc);
           return await db.SaveChangesAsync();

        }
        public static async System.Threading.Tasks.Task<int> AddStoreOpenningAsync(eStoreDbContext db, int StoreId)
        {
            StoreOpen so= new StoreOpen{IsReadOnly=true, OpenningTime=DateTime.Now, Remarks="", StoreId=StoreId, UserId="Admin" };
            await db.StoreOpens.AddAsync(so);
            return await db.SaveChangesAsync();
        }
    }
}
