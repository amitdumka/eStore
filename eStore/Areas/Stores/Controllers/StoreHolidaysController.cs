using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Stores;

namespace eStore.Areas.Stores.Controllers
{
    [Area("Stores")]
    public class StoreHolidaysController : Controller
    {
        private readonly eStoreDbContext _context;

        public StoreHolidaysController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Store/StoreHolidays
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.StoreHolidays.Include(s => s.Store);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: Store/StoreHolidays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeHoliday = await _context.StoreHolidays
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StoreHolidayId == id);
            if (storeHoliday == null)
            {
                return NotFound();
            }

            return View(storeHoliday);
        }

        // GET: Store/StoreHolidays/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Store/StoreHolidays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreHolidayId,OnDate,Reason,Remarks,ApprovedBy,StoreId,UserId,EntryStatus,IsReadOnly")] StoreHoliday storeHoliday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeHoliday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", storeHoliday.StoreId);
            return View(storeHoliday);
        }

        // GET: Store/StoreHolidays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeHoliday = await _context.StoreHolidays.FindAsync(id);
            if (storeHoliday == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", storeHoliday.StoreId);
            return View(storeHoliday);
        }

        // POST: Store/StoreHolidays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreHolidayId,OnDate,Reason,Remarks,ApprovedBy,StoreId,UserId,EntryStatus,IsReadOnly")] StoreHoliday storeHoliday)
        {
            if (id != storeHoliday.StoreHolidayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeHoliday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreHolidayExists(storeHoliday.StoreHolidayId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", storeHoliday.StoreId);
            return View(storeHoliday);
        }

        // GET: Store/StoreHolidays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeHoliday = await _context.StoreHolidays
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.StoreHolidayId == id);
            if (storeHoliday == null)
            {
                return NotFound();
            }

            return View(storeHoliday);
        }

        // POST: Store/StoreHolidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeHoliday = await _context.StoreHolidays.FindAsync(id);
            _context.StoreHolidays.Remove(storeHoliday);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreHolidayExists(int id)
        {
            return _context.StoreHolidays.Any(e => e.StoreHolidayId == id);
        }
    }
}
