using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Common;

namespace eStore.Areas.Stores.Controllers
{
    [Area("Stores")]
    public class CashDetailsController : Controller
    {
        private readonly eStoreDbContext _context;

        public CashDetailsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Stores/CashDetails
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.CashDetail.Include(c => c.Store);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: Stores/CashDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDetail = await _context.CashDetail
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashDetailId == id);
            if (cashDetail == null)
            {
                return NotFound();
            }

            return View(cashDetail);
        }

        // GET: Stores/CashDetails/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Stores/CashDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CashDetailId,OnDate,TotalAmount,C2000,C1000,C500,C100,C50,C20,C10,C5,Coin10,Coin5,Coin2,Coin1,StoreId,UserId,EntryStatus,IsReadOnly")] CashDetail cashDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashDetail.StoreId);
            return View(cashDetail);
        }

        // GET: Stores/CashDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDetail = await _context.CashDetail.FindAsync(id);
            if (cashDetail == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashDetail.StoreId);
            return View(cashDetail);
        }

        // POST: Stores/CashDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CashDetailId,OnDate,TotalAmount,C2000,C1000,C500,C100,C50,C20,C10,C5,Coin10,Coin5,Coin2,Coin1,StoreId,UserId,EntryStatus,IsReadOnly")] CashDetail cashDetail)
        {
            if (id != cashDetail.CashDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashDetailExists(cashDetail.CashDetailId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashDetail.StoreId);
            return View(cashDetail);
        }

        // GET: Stores/CashDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDetail = await _context.CashDetail
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashDetailId == id);
            if (cashDetail == null)
            {
                return NotFound();
            }

            return View(cashDetail);
        }

        // POST: Stores/CashDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashDetail = await _context.CashDetail.FindAsync(id);
            _context.CashDetail.Remove(cashDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashDetailExists(int id)
        {
            return _context.CashDetail.Any(e => e.CashDetailId == id);
        }
    }
}
