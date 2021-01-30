using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.DL.Data;
using eStore.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Areas.Admin.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly eStoreDbContext db;

        readonly RoleManager<IdentityRole> roleManager;
        readonly UserManager<AppUser> UserManager;

        public UserManagementController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> um, eStoreDbContext dbContext)
        {
            this.roleManager = roleManager;
            UserManager = um;
            db = dbContext;
        }

        public IActionResult Index()
        {

            var listOfUsers = UserManager.Users.ToList();

            return View(listOfUsers);
        }
    }
}