using System;
using System.Linq;
using System.Threading.Tasks;
using eStore.BL.Admin;
using eStore.DL.Data;
using eStore.Shared.Models.Identity;
using eStore.Shared.Models.Payroll;
using eStore.Shared.Models.Stores;
using eStore.Validator;
using Microsoft.AspNetCore.Identity;

namespace eStore.Payroll
{
    public class EmployeeManager
    {
        public static async Task PostEmployeeAdditionAsync(eStoreDbContext db, Employee employee, UserManager<AppUser> userManager)
        {
            await EmployeeManager.AddEmployeeLoginAsync(db, employee, userManager);
            if(employee.Category==EmpType.Salesman) await AddSaleman(db, employee);
        }

        public static async Task AddSaleman(eStoreDbContext db, Employee employee)
        {
            if (DBDataChecker.IsSalesmanExists(db, employee.FirstName + " " + employee.LastName, employee.StoreId))
            {
                var sm =  db.Salesmen.Where(c => c.SalesmanName == employee.FirstName + " " + employee.LastName && c.StoreId == employee.StoreId).First();
                sm.EmployeeId = employee.EmployeeId;sm.EntryStatus = EntryStatus.Updated;
                db.Update(sm);
            }
            else
            {
                Salesman sm = new Salesman
                {
                    EmployeeId = employee.EmployeeId,
                    IsReadOnly = true,
                    SalesmanName = employee.FirstName + " " + employee.LastName,
                    StoreId = employee.StoreId,
                    UserId = employee.UserId,
                    EntryStatus = EntryStatus.Added
                };
                db.Salesmen.Add(sm);
            }
            await db.SaveChangesAsync();

        }
        public static async Task AddEmployeeLoginAsync(eStoreDbContext db, Employee employee, UserManager<AppUser> userManager)
        {
            if (employee != null && employee.IsWorking)
            {
                await UserAdmin.AddUserAsync(userManager, employee);

                //if (employee.IsWorking)
                //{
                     

                //    //TODO:    await UserAdmin.AddEmployeeUserAsync(db, employee.StaffName, employee.EmployeeId);

                //}
            }
            else
            {
                throw new Exception();
            }



        }
    }
}
