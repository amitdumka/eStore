using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Sales;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class DuesListsController : Controller
    {
        private readonly eStoreDbContext _context;

        public DuesListsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/DuesLists
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.DuesLists.Include(d => d.DailySale).Include(d => d.Store).OrderByDescending(c=>c.DailySale.SaleDate);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: Accounts/DuesLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duesList = await _context.DuesLists
                .Include(d => d.DailySale)
                .Include(d => d.Store)
                .FirstOrDefaultAsync(m => m.DuesListId == id);
            if (duesList == null)
            {
                return NotFound();
            }

            return PartialView(duesList);
        }

        // GET: Accounts/DuesLists/Create
        public IActionResult Create()
        {
            ViewData["DailySaleId"] = new SelectList(_context.DailySales, "DailySaleId", "InvNo");
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return PartialView();
        }

        // POST: Accounts/DuesLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DuesListId,Amount,IsRecovered,RecoveryDate,DailySaleId,IsPartialRecovery,StoreId,UserId")] DuesList duesList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duesList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DailySaleId"] = new SelectList(_context.DailySales, "DailySaleId", "InvNo", duesList.DailySaleId);
           // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", duesList.StoreId);
            return PartialView(duesList);
        }

        // GET: Accounts/DuesLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duesList = await _context.DuesLists.FindAsync(id);
            if (duesList == null)
            {
                return NotFound();
            }
            ViewData["DailySaleId"] = new SelectList(_context.DailySales, "DailySaleId", "InvNo", duesList.DailySaleId);
           // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", duesList.StoreId);
            return  View(duesList);
        }

        // POST: Accounts/DuesLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DuesListId,Amount,IsRecovered,RecoveryDate,DailySaleId,IsPartialRecovery,StoreId,UserId")] DuesList duesList)
        {
            if (id != duesList.DuesListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duesList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuesListExists(duesList.DuesListId))
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
            ViewData["DailySaleId"] = new SelectList(_context.DailySales, "DailySaleId", "InvNo", duesList.DailySaleId);
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", duesList.StoreId);
            return PartialView(duesList);
        }

        // GET: Accounts/DuesLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duesList = await _context.DuesLists
                .Include(d => d.DailySale)
                .Include(d => d.Store)
                .FirstOrDefaultAsync(m => m.DuesListId == id);
            if (duesList == null)
            {
                return NotFound();
            }

            return  View(duesList);
        }

        // POST: Accounts/DuesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duesList = await _context.DuesLists.FindAsync(id);
            _context.DuesLists.Remove(duesList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuesListExists(int id)
        {
            return _context.DuesLists.Any(e => e.DuesListId == id);
        }
    }
}
