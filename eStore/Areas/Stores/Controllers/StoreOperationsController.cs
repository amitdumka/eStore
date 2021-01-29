using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.BL.Commons;
using eStore.DL.Data;
using eStore.Ops;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eStore.Areas.Stores.Controllers
{
    [Area("Stores")]
    public class StoreOperationsController : Controller
    {
        private readonly eStoreDbContext _context;

        public StoreOperationsController(eStoreDbContext context)
        {
            _context = context;
        }
        // GET: StoreOperations
        public async Task<IActionResult> Index()
        {

            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            int CurrentStore = storeInfo.StoreId;
            ViewData["UserName"] = storeInfo.UserName;
            var store = await _context.Stores.FindAsync(CurrentStore);
            ViewBag.StoreName = store.StoreName;
            ViewBag.StoreCity = store.City;
            ViewBag.StoreId = CurrentStore;

            // Check for Today Close and Openning Entry
            DateTime date = DateTime.Today.Date;
            //TODO: Update to IST Time zone
            var openToday = await _context.StoreOpens.Where(c => c.OpenningTime.Date == date.Date && c.StoreId == CurrentStore).FirstOrDefaultAsync();
            var closeToday = await _context.StoreCloses.Where(c => c.ClosingDate.Date == date.Date && c.StoreId == CurrentStore).FirstOrDefaultAsync();
            ViewBag.Open = "true";
            ViewBag.Close = "true";
            if (openToday != null) ViewBag.Open = "false";
            if (closeToday != null) ViewBag.Close = "false";

            return View();
        }

        public async Task<JsonResult> StoreOpenningAsync(int StoreId) {

           int result= await StoreManager.AddStoreOpenningAsync(_context, StoreId);
            if(result>0)
            return new JsonResult("ok");
            else
                return new JsonResult("error");
        }
        public async Task<JsonResult> StoreClosingAsync(int StoreId)
        {
            int result = await StoreManager.AddStoreCloseAsync(_context, StoreId);
            if (result > 0)
                return new JsonResult("ok");
            else
                return new JsonResult("error");
        }
        
    }
}