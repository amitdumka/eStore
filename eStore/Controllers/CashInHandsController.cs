using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Common;

namespace eStore.Controllers
{
    public class CashInHandsController : Controller
    {
        private readonly eStoreDbContext _context;

        public CashInHandsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: CashInHands
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.CashInHands.Include(c => c.Store);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: CashInHands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashInHand = await _context.CashInHands
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashInHandId == id);
            if (cashInHand == null)
            {
                return NotFound();
            }

            return View(cashInHand);
        }

        // GET: CashInHands/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: CashInHands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CashInHandId,CIHDate,OpenningBalance,ClosingBalance,CashIn,CashOut,StoreId")] CashInHand cashInHand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashInHand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashInHand.StoreId);
            return View(cashInHand);
        }

        // GET: CashInHands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashInHand = await _context.CashInHands.FindAsync(id);
            if (cashInHand == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashInHand.StoreId);
            return View(cashInHand);
        }

        // POST: CashInHands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CashInHandId,CIHDate,OpenningBalance,ClosingBalance,CashIn,CashOut,StoreId")] CashInHand cashInHand)
        {
            if (id != cashInHand.CashInHandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashInHand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashInHandExists(cashInHand.CashInHandId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashInHand.StoreId);
            return View(cashInHand);
        }

        // GET: CashInHands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashInHand = await _context.CashInHands
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashInHandId == id);
            if (cashInHand == null)
            {
                return NotFound();
            }

            return View(cashInHand);
        }

        // POST: CashInHands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashInHand = await _context.CashInHands.FindAsync(id);
            _context.CashInHands.Remove(cashInHand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashInHandExists(int id)
        {
            return _context.CashInHands.Any(e => e.CashInHandId == id);
        }
    }
}
