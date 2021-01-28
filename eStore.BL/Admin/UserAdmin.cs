using System;
using System.Threading.Tasks;
using eStore.DL.Data;
using eStore.Shared.Models.Identity;
using eStore.Shared.Models.Payroll;
using Microsoft.AspNetCore.Identity;

namespace eStore.BL.Admin
{
    public static class UserAdmin
    {
        public static string RemoveWhiteSpace(string data)
        {
            return data.Replace(" ", "").Trim();
        }

        public static async Task<int> AddEmployeeUserAsync(eStoreDbContext db, string UserName, int EmployeeId)
        {
            //  UserName = RemoveWhiteSpace(UserName);

            EmployeeUser user = new EmployeeUser { EmployeeId = EmployeeId, IsWorking = true/*, UserName = UserName*/ };
            await db.EmployeeUsers.AddAsync(user);
            return await db.SaveChangesAsync();


        }
        public static async Task<bool> AddUserAsync(UserManager<AppUser> userManager, Employee emp)
        {
            string UserName = RemoveWhiteSpace(emp.StaffName);
            var user = new AppUser { UserName = UserName, IsWorking = emp.IsWorking, IsEmployee = true, EmployeeId = emp.EmployeeId, FirstName = emp.FirstName, LastName = emp.LastName, PhoneNumber = emp.MobileNo };

            if (String.IsNullOrEmpty(emp.EMail))
            {
                user.Email = UserName + "@aprajitaretails.in";
            }
            else
            {
                user.Email = emp.EMail;
            }

            var result = await userManager.CreateAsync(user, UserName + "@1234").ConfigureAwait(true);
            if (result.Succeeded)
            {

                if (emp.Category == EmpType.StoreManager)
                    await userManager.AddToRoleAsync(user, "StoreManager").ConfigureAwait(true);
                else if (emp.Category == EmpType.Salesman)
                    await userManager.AddToRoleAsync(user, "Salesman").ConfigureAwait(true);
                else if (emp.Category == EmpType.HouseKeeping)
                    await userManager.AddToRoleAsync(user, "Member").ConfigureAwait(true);
                else if (emp.Category == EmpType.Accounts)
                    await userManager.AddToRoleAsync(user, "Accountant").ConfigureAwait(true);
                //TODO: Need to Update Confirmed Email.

                _ = await userManager.GetUserIdAsync(user).ConfigureAwait(true);
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(true);

                _ = await userManager.ConfirmEmailAsync(user, code).ConfigureAwait(true);
                return true;
            }

            return false;
        }

        // public static async Task<bool> AddUserAsync(UserManager<AppUser> userManager, string UserName, bool isPowerUser, int EmployeeId)
        //{
        //    UserName = RemoveWhiteSpace(UserName);
        //    var fullname = UserName.Split(" ");

        //    var user = new AppUser { UserName = UserName, Email = UserName + "@aprajitaretails.in", IsWorking = true, FirstName = fullname[0], IsEmployee = true, EmployeeId = EmployeeId };
        //    if (fullname.Length > 1)
        //        user.LastName = fullname[1];
        //    else user.LastName = fullname[0];

        //    var result = await userManager.CreateAsync(user, UserName + "@1234").ConfigureAwait(true);
        //    if (result.Succeeded)
        //    {
        //        //here we tie the new user to the "Admin" role
        //        if (isPowerUser)
        //            await userManager.AddToRoleAsync(user, "StoreManager").ConfigureAwait(true);
        //        else
        //            await userManager.AddToRoleAsync(user, "Salesman").ConfigureAwait(true);

        //        //TODO: Need to Update Confirmed Email.

        //        _ = await userManager.GetUserIdAsync(user).ConfigureAwait(true);
        //        var code = await userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(true);

        //        _ = await userManager.ConfirmEmailAsync(user, code).ConfigureAwait(true);
        //        return true;
        //    }

        //    return false;
        //}
        // public static async Task<bool> AddUserAsync(UserManager<AppUser> userManager, string UserName, bool isPowerUser, string EmailId, int EmployeeId)
        //{
        //    UserName = RemoveWhiteSpace(UserName);
        //    var user = new AppUser { UserName = UserName, Email = EmailId };
        //    var result = await userManager.CreateAsync(user, UserName + "@1234").ConfigureAwait(true);
        //    if (result.Succeeded)
        //    {
        //        //here we tie the new user to the "Admin" role
        //        if (isPowerUser)
        //            await userManager.AddToRoleAsync(user, "StoreManager").ConfigureAwait(true);
        //        else
        //            await userManager.AddToRoleAsync(user, "Salesman").ConfigureAwait(true);

        //        //TODO: Need to Update Confirmed Email.

        //        _ = await userManager.GetUserIdAsync(user).ConfigureAwait(true);
        //        var code = await userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(true);

        //        _ = await userManager.ConfirmEmailAsync(user, code).ConfigureAwait(true);
        //        return true;
        //    }

        //    return false;
        //}

        // public static async Task<bool> AddUserAsync(UserManager<AppUser> userManager, string UserName, string Passwrd, bool isPowerUser, string EmailId, int EmployeeId)
        //{
        //    UserName = RemoveWhiteSpace(UserName);
        //    var user = new AppUser { UserName = UserName, Email = EmailId };
        //    var result = await userManager.CreateAsync(user, Passwrd).ConfigureAwait(true);
        //    if (result.Succeeded)
        //    {
        //        //here we tie the new user to the "Admin" role
        //        if (isPowerUser)
        //            await userManager.AddToRoleAsync(user, "StoreManager").ConfigureAwait(true);
        //        else
        //            await userManager.AddToRoleAsync(user, "Salesman").ConfigureAwait(true);

        //        //TODO: Need to Update Confirmed Email.

        //        _ = await userManager.GetUserIdAsync(user).ConfigureAwait(true);
        //        var code = await userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(true);

        //        _ = await userManager.ConfirmEmailAsync(user, code).ConfigureAwait(true);
        //        return true;
        //    }

        //    return false;
        //}


    }
}
