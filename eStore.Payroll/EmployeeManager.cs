using System;
using eStore.BL.Admin;
using eStore.DL.Data;
using eStore.Shared.Models.Identity;
using eStore.Shared.Models.Payroll;
using Microsoft.AspNetCore.Identity;

namespace eStore.Payroll
{
    public class EmployeeManager
    {
        public static async System.Threading.Tasks.Task AddEmployeeLoginAsync(eStoreDbContext db, Employee employee, UserManager<AppUser> userManager)
        {
            if (employee != null && employee.IsWorking)
            {
                await UserAdmin.AddUserAsync(userManager, employee);

                //if (employee.IsWorking)
                //{

                //    await UserAdmin.AddEmployeeUserAsync(db, employee.StaffName, employee.EmployeeId);
                //}
            }
            else
            {
                throw new Exception();
            }



        }
    }
}
