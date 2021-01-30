using eStore.Areas.Sales.Ops;
using eStore.BL.SalePurchase;
using eStore.DL.Data;
using eStore.Ops;
using eStore.Shared.Data.Paging;
using eStore.Shared.Models.Sales;
using eStore.Shared.ViewModels.SalePuchase;

//using eStore.Ops.Triggers;
//using eStore.Ops.Utility;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


/*
 * UI is working. 
 * Porting with API Pending. 
 * and Trigger and Utility like cash in hand/bank, saleman, payment details for non cash , UI Element, Session Controll. 
 */

namespace eStore.Areas.Sales.Controllers
{
    [Area("Sales")]
    [Authorize]
    public class DailySalesController : Controller
    {
        //Version 4.0

        private readonly eStoreDbContext db;
        private readonly CultureInfo c = CultureInfo.GetCultureInfo("In");
        private readonly ILogger<DailySalesController> logger;

        public DailySalesController(eStoreDbContext context, ILogger<DailySalesController> logger)
        {
            this.logger = logger;
            db = context;
        }

        // GET: DailySales
        public async Task<IActionResult> Index(int? id, string salesmanId, string currentFilter, string searchString, DateTime? SaleDate, string sortOrder, int? pageNumber)
        {
            //TODO: Dailysale: have to reduce data fecthing
            // Setting Store Info Here
            StoreInfo storeInfo = null;

            if (PostLogin.IsSessionSet(HttpContext.Session))
            {
                storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
                if (storeInfo != null)
                {
                    logger.Log(LogLevel.Information, "Store Info is not null!");
                }
                else
                {
                    //TODO: Redirect to login Page
                }
            }
            else
            {
                //TODO: Redirect to login Page
            }
           
            ViewData["InvoiceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "inv_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["ManualSortParm"] = sortOrder == "Manual" ? "notManual_desc" : "Manual";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            //For Current Day
            var dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.SaleDate == DateTime.Today && c.StoreId == storeInfo.StoreId);

            if (id != null && id == 101)
            {
                //All
                dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.StoreId == storeInfo.StoreId).OrderByDescending(c => c.SaleDate).ThenByDescending(c => c.DailySaleId);
            }
            else if (id != null && id == 104)
            {
                dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.SaleDate == DateTime.Today.AddDays(-1) && c.StoreId == storeInfo.StoreId);
            }
            else if (id != null && id == 102)
            {
                //Current Month
                dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.SaleDate.Month == DateTime.Today.Month && c.SaleDate.Year == DateTime.Today.Year && c.StoreId == storeInfo.StoreId).OrderByDescending(c => c.SaleDate).ThenByDescending(c => c.DailySaleId);
            }
            else if (id != null && id == 103)
            {
                //Last Month
                dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.SaleDate.Month == DateTime.Today.Month - 1 && c.SaleDate.Year == DateTime.Today.Year && c.StoreId == storeInfo.StoreId).OrderByDescending(c => c.SaleDate).ThenByDescending(c => c.DailySaleId);
            }
            else
            {
                dailySales = dailySales.OrderByDescending(c => c.SaleDate).ThenByDescending(c => c.DailySaleId);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.InvNo == searchString && c.StoreId == storeInfo.StoreId);
                //return View(await dls.ToListAsync());
            }
            else if (!String.IsNullOrEmpty(salesmanId) || SaleDate != null)
            {
                //IEnumerable<DailySale> DailySales;

                if (SaleDate != null)
                {
                    dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.SaleDate == SaleDate && c.StoreId == storeInfo.StoreId).OrderByDescending(c => c.DailySaleId);
                }
                else
                {
                    dailySales = db.DailySales.Include(d => d.Salesman).Where(c => c.SaleDate.Month == DateTime.Today.Month && c.SaleDate.Year == DateTime.Today.Year && c.StoreId == storeInfo.StoreId).OrderByDescending(c => c.SaleDate).ThenByDescending(c => c.DailySaleId);
                }

                if (!String.IsNullOrEmpty(salesmanId))
                {
                    dailySales = dailySales.Where(c => c.Salesman.SalesmanName == salesmanId);
                }
            }

            // For All Invoice
            //TODO: Make a Static class and function to fetch details

            #region FixedUI

            //Fixed Query
            //var totalSale =(decimal)( db.DailySales.Where(c => c.IsManualBill == false && c.SaleDate.Date == DateTime.Today.Date && c.StoreId == storeInfo.StoreId).Sum(c => (double?)c.Amount) ?? 0);
            //var totalManualSale = (decimal)(db.DailySales.Where(c => c.IsManualBill == true && c.SaleDate.Date == DateTime.Today.Date && c.StoreId == storeInfo.StoreId).Sum(c => (double?)c.Amount) ?? 0);
            //var totalMonthlySale = (decimal)(db.DailySales.Where(c => c.SaleDate.Year == DateTime.Today.Year && c.SaleDate.Month == DateTime.Today.Month && c.StoreId == storeInfo.StoreId).Sum(c => (double?)c.Amount) ?? 0);
            //var totalLastMonthlySale = (decimal)(db.DailySales.Where(c => c.SaleDate.Year == DateTime.Today.Year && c.SaleDate.Month == DateTime.Today.Month - 1 && c.StoreId == storeInfo.StoreId).Sum(c => (double?)c.Amount) ?? 0);
            //var duesamt = (decimal)(db.DuesLists.Where(c => c.IsRecovered == false && c.StoreId == storeInfo.StoreId).Sum(c => (double?)c.Amount) ?? 0);
            //var cashinhand = (decimal)0.00;
            //try
            //{
            //    var chin = db.CashInHands.Where(c => c.CIHDate.Date == DateTime.Today.Date && c.StoreId == storeInfo.StoreId).FirstOrDefault();
            //    if(chin!=null)
            //        cashinhand = chin.InHand;
            //    else
            //    {
            //        // Utility.ProcessOpenningClosingBalance(db, DateTime.Today, false, true);
            //     //TODO:   new CashWork().ProcessOpenningBalance(db, DateTime.Today, StoreCodeId, true);

            //        cashinhand = (decimal)0.00;
            //    }
            //}
            //catch (Exception)
            //{
            //    // Utility.ProcessOpenningClosingBalance(db, DateTime.Today, false, true);
            // //TODO:   new CashWork().ProcessOpenningBalance(db, DateTime.Today, StoreCodeId, true);
            //    cashinhand = (decimal)0.00;
            //    //Log.Error("Cash In Hand is null");
            //}

            SaleInfoUIVM uIVM = new SaleInfoUIVM();
            uIVM = uIVM.GetSaleInfo(db, storeInfo.StoreId);

            // Fixed UI
            ViewBag.TodaySale = uIVM.TodaySale;
            ViewBag.ManualSale = uIVM.ManualSale;
            ViewBag.MonthlySale = uIVM.MonthlySale;
            ViewBag.DuesAmount = uIVM.DuesAmount;
            ViewBag.CashInHand = uIVM.CashInHand;
            ViewBag.LastMonthSale = uIVM.LastMonthSale;

            #endregion FixedUI

            #region bySalesman

            // By Salesman
            var salesmanList = new List<string>();
            var smQry = from d in db.Salesmen
                        orderby d.SalesmanName
                        select d.SalesmanName;
            salesmanList.AddRange(smQry.Distinct());
            ViewBag.salesmanId = new SelectList(salesmanList);

            #endregion bySalesman

            #region ByDate

            //var dateList = new List<DateTime>();
            //var opdQry = from d in db.DailySales
            //             orderby d.SaleDate
            //             select d.SaleDate;
            //dateList.AddRange(opdQry.Distinct());
            //ViewBag.dateID = new SelectList(dateList);

            #endregion ByDate

            //By Invoice No Search

            switch (sortOrder)
            {
                case "Manual":
                    dailySales = dailySales.OrderBy(c => c.IsManualBill);
                    break;

                case "notManual_desc":
                    dailySales = dailySales.OrderByDescending(c => c.IsManualBill);
                    break;

                case "inv_desc":
                    dailySales = dailySales.OrderByDescending(s => s.InvNo);
                    break;

                case "Date":
                    dailySales = dailySales.OrderBy(s => s.SaleDate);
                    break;

                case "date_desc":
                    dailySales = dailySales.OrderByDescending(s => s.SaleDate);
                    break;

                default:
                    dailySales = dailySales.OrderBy(s => s.InvNo);
                    break;
            }
             
            int pageSize = 10;
            return View(await PaginatedList<DailySale>.CreateAsync(dailySales.AsNoTracking(), pageNumber ?? 1, pageSize));

            
        }

        // GET: DailySales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dailySale = await db.DailySales
                .Include(d => d.Salesman)
                .FirstOrDefaultAsync(m => m.DailySaleId == id);
            if (dailySale == null)
            {
                return NotFound();
            }
            return PartialView(dailySale);
        }

        // GET: DailySales/Create
        public IActionResult Create()
        {
            // Setting Store Info Here
            StoreInfo storeInfo = null;

            if (PostLogin.IsSessionSet(HttpContext.Session))
            {
                storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
                if (storeInfo != null)
                {
                    ViewBag.StoreID = storeInfo.StoreId;
                }
                else
                {
                    //TODO: Redirect to login Page
                }
            }
            else
            {
                //TODO: Redirect to login Page
            }
            ViewData["SalesmanId"] = new SelectList(db.Salesmen, "SalesmanId", "SalesmanName");
            return PartialView();
        }

        public async Task<IActionResult> AddEditPaymentDetails(string InvNo)
        {
            // Setting Store Info Here
            StoreInfo storeInfo = null;
            if (PostLogin.IsSessionSet(HttpContext.Session))
            {
                storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
                if (storeInfo != null)
                {
                    ViewBag.StoreID = storeInfo.StoreId;
                }
                else
                {
                   //TODO: Redirect to login Page
                }
            }
            else
            {
                //TODO: Redirect to login Page
            }

            ViewData["EDCId"] = new SelectList(db.CardMachine, "EDCId", "EDCName");
         
            if (String.IsNullOrEmpty(InvNo))
            {
                return NotFound();
            }
            else
            {
                var paydetails = await db.CardTranscations.Where(c => c.InvoiceNumber == InvNo).FirstOrDefaultAsync();

                if (paydetails == null)
                {
                    return View(new EDCTranscation { OnDate = DateTime.Today.Date, InvoiceNumber = InvNo, StoreId = storeInfo.StoreId });
                }
                return View(paydetails);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditPaymentDetails(int id, [Bind("Amount, InvoiceNumber, CardEndingNumber,  CardType, EDCId, EDCTranscationId, OnDate, StoreId")] EDCTranscation eDC)
        {
            if (ModelState.IsValid)
            { 
                //Insert
                if (eDC.EDCTranscationId == 0)
                {
                    db.Add(eDC);
                    await db.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        db.Update(eDC);
                        await db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CardTranscationExists(eDC.EDCTranscationId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", db.CardTranscations.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddEditPaymentDetails", eDC) });
            //TODO: here we need to refresh index page update/add opertation if required other wise no need call this function just pass is valid or not. 
        }
        // POST: DailySales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailySaleId,SaleDate,InvNo,Amount,PayMode,CashAmount,SalesmanId,IsDue,IsManualBill,IsTailoringBill,IsSaleReturn,Remarks,StoreId")] DailySale dailySale)
        {
            if (ModelState.IsValid)
            {
                
                db.Add(dailySale);

                new SalesManager().OnInsert(db, dailySale);
                
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SalesmanId"] = new SelectList(db.Salesmen, "SalesmanId", "SalesmanName", dailySale.SalesmanId);
            return View(dailySale);
        }

        // GET: DailySales/Edit/5
        [Authorize(Roles = "Admin,PowerUser,StoreManager")]
        public async Task<IActionResult> Edit(int? id)
        {
            // Setting Store Info Here
            //StoreInfo storeInfo = null;

            //if (PostLogin.IsSessionSet(HttpContext.Session))
            //{
            //    storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            //    if (storeInfo != null)
            //    {
            //        ViewBag.StoreID = storeInfo.StoreId;
            //        ViewBag.UserNAME = storeInfo.UserName;
            //    }
            //    else
            //    {
            //        //TODO: Redirect to login Page
            //    }
            //}
            //else
            //{
            //    //TODO: Redirect to login Page
            //}

            if (id == null)
            {
                 return NotFound();
            }

            var dailySale = await db.DailySales.FindAsync(id);
            if (dailySale == null)
            {
                 return NotFound();
            }
            ViewData["SalesmanId"] = new SelectList(db.Salesmen, "SalesmanId", "SalesmanName", dailySale.SalesmanId);
            return PartialView(dailySale);
        }

        // POST: DailySales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,PowerUser,StoreManager")]
        public async Task<IActionResult> Edit(int id, [Bind("DailySaleId,SaleDate,InvNo,Amount,PayMode,CashAmount,SalesmanId,IsDue,IsManualBill,IsTailoringBill,IsSaleReturn,Remarks,StoreId")] DailySale dailySale)
        {
            if (id != dailySale.DailySaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(dailySale);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailySaleExists(dailySale.DailySaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesmanId"] = new SelectList(db.Salesmen, "SalesmanId", "SalesmanName", dailySale.SalesmanId);
            return PartialView(dailySale);
        }

        // GET: DailySales/Delete/5
        [Authorize(Roles = "Admin,PowerUser")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailySale = await db.DailySales
                .Include(d => d.Salesman)
                .FirstOrDefaultAsync(m => m.DailySaleId == id);
            if (dailySale == null)
            {
                return NotFound();
            }

            return PartialView(dailySale);
        }

        // POST: DailySales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,PowerUser")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailySale = await db.DailySales.FindAsync(id);
            new SalesManager().OnDelete(db, dailySale);
            db.DailySales.Remove(dailySale);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("DeletePayment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePaymentConfirmed(int id)
        {
            //TODO: here we need to refresh index page delete opertation if required
            var transactionModel = await db.CardTranscations.FindAsync(id);
            db.CardTranscations.Remove(transactionModel);
            await db.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "Index", db.CardTranscations.ToList()) });
        }

        private bool DailySaleExists(int id)
        {
            return db.DailySales.Any(e => e.DailySaleId == id);
        }
        private bool CardTranscationExists(int id)
        {
            return db.CardTranscations.Any(e => e.EDCTranscationId == id);
        }
    }
}

//https://www.codaffection.com/asp-net-core-article/how-to-use-jquery-ajax-in-asp-net-core-mvc-for-crud-operations-with-modal-popup/#Let%E2%80%99s_Start_Designing_the_App

//https://morioh.com/p/cac7badbf881