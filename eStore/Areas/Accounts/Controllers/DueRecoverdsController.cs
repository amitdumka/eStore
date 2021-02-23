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
    public class DueRecoverdsController : Controller
    {
        private readonly eStoreDbContext _context;

        public DueRecoverdsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/DueRecoverds
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.DueRecoverds.Include(d => d.DuesList).Include(c=>c.DuesList.DailySale).Include(d => d.Store).OrderByDescending(c => c.PaidDate);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: Accounts/DueRecoverds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueRecoverd = await _context.DueRecoverds
                .Include(d => d.DuesList)
                .Include(d => d.Store)
                .FirstOrDefaultAsync(m => m.DueRecoverdId == id);
            if (dueRecoverd == null)
            {
                return NotFound();
            }

            return PartialView(dueRecoverd);
        }

        // GET: Accounts/DueRecoverds/Create
        public IActionResult Create()
        {
            ViewData["DuesListId"] = new SelectList(_context.DuesLists.Include(c=>c.DailySale), "DuesListId", "InvNp");
           // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return PartialView();
        }

        // POST: Accounts/DueRecoverds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DueRecoverdId,PaidDate,DuesListId,AmountPaid,IsPartialPayment,Modes,Remarks,StoreId,UserId")] DueRecoverd dueRecoverd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueRecoverd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DuesListId"] = new SelectList(_context.DuesLists.Include(c => c.DailySale), "DuesListId", "InvNo", dueRecoverd.DuesListId);
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", dueRecoverd.StoreId);
            return  View(dueRecoverd);
        }

        // GET: Accounts/DueRecoverds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueRecoverd = await _context.DueRecoverds.FindAsync(id);
            if (dueRecoverd == null)
            {
                return NotFound();
            }
            ViewData["DuesListId"] = new SelectList(_context.DuesLists.Include(c => c.DailySale), "DuesListId", "InvNo", dueRecoverd.DuesListId);
           // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", dueRecoverd.StoreId);
            return PartialView(dueRecoverd);
        }

        // POST: Accounts/DueRecoverds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DueRecoverdId,PaidDate,DuesListId,AmountPaid,IsPartialPayment,Modes,Remarks,StoreId,UserId")] DueRecoverd dueRecoverd)
        {
            if (id != dueRecoverd.DueRecoverdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueRecoverd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DueRecoverdExists(dueRecoverd.DueRecoverdId))
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
            ViewData["DuesListId"] = new SelectList(_context.DuesLists.Include(c => c.DailySale), "DuesListId", "InvNo", dueRecoverd.DuesListId);
           // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", dueRecoverd.StoreId);
            return  View(dueRecoverd);
        }

        // GET: Accounts/DueRecoverds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueRecoverd = await _context.DueRecoverds
                .Include(d => d.DuesList)
                .Include(d => d.Store)
                .FirstOrDefaultAsync(m => m.DueRecoverdId == id);
            if (dueRecoverd == null)
            {
                return NotFound();
            }

            return PartialView(dueRecoverd);
        }

        // POST: Accounts/DueRecoverds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueRecoverd = await _context.DueRecoverds.FindAsync(id);
            _context.DueRecoverds.Remove(dueRecoverd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DueRecoverdExists(int id)
        {
            return _context.DueRecoverds.Any(e => e.DueRecoverdId == id);
        }
    }
}
