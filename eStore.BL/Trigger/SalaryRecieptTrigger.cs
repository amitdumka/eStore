﻿

using eStore.DL.Data;

namespace eStore.BL.Triggers
{
    public class StaffAdvanceReceiptTrigger : ITrigger
    {

        public void OnChange<StaffAdvanceReceipt>(eStoreDbContext db, StaffAdvanceReceipt salary)
        {
            
            throw new System.NotImplementedException();
        }

        public void OnDelete<StaffAdvanceReceipt>(eStoreDbContext db, StaffAdvanceReceipt salary)
        {
            throw new System.NotImplementedException();
        }

        public void OnInsert<StaffAdvanceReceipt>(eStoreDbContext db, StaffAdvanceReceipt salary)
        {
            throw new System.NotImplementedException();
        }

        public void OnInsertOrUpdate<StaffAdvanceReceipt>(eStoreDbContext db, StaffAdvanceReceipt salary, bool isUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void OnUpdate<StaffAdvanceReceipt>(eStoreDbContext db, StaffAdvanceReceipt salary)
        {
            throw new System.NotImplementedException();
        }

       
    }
}