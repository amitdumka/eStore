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
    public class PettyCashBooksController : Controller
    {
        private readonly eStoreDbContext _context;

        public PettyCashBooksController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Stores/PettyCashBooks
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.PettyCashBooks.Include(p => p.Store);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: Stores/PettyCashBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pettyCashBook = await _context.PettyCashBooks
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.PettyCashBookId == id);
            if (pettyCashBook == null)
            {
                return NotFound();
            }

            return View(pettyCashBook);
        }

        // GET: Stores/PettyCashBooks/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return View();
        }

        // POST: Stores/PettyCashBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PettyCashBookId,OnDate,OpeningCash,ClosingCash,SystemSale,TailoringSale,ManualSale,CashReciepts,OhterReceipts,RecieptRemarks,CardSwipe,BankDeposit,TotalExpenses,TotalPayments,PaymentRemarks,CustomerDuesNames,TotalDues,StoreId,UserId,IsReadOnly")] PettyCashBook pettyCashBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pettyCashBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", pettyCashBook.StoreId);
            return View(pettyCashBook);
        }

        // GET: Stores/PettyCashBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pettyCashBook = await _context.PettyCashBooks.FindAsync(id);
            if (pettyCashBook == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", pettyCashBook.StoreId);
            return View(pettyCashBook);
        }

        // POST: Stores/PettyCashBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PettyCashBookId,OnDate,OpeningCash,ClosingCash,SystemSale,TailoringSale,ManualSale,CashReciepts,OhterReceipts,RecieptRemarks,CardSwipe,BankDeposit,TotalExpenses,TotalPayments,PaymentRemarks,CustomerDuesNames,TotalDues,StoreId,UserId,IsReadOnly")] PettyCashBook pettyCashBook)
        {
            if (id != pettyCashBook.PettyCashBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pettyCashBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PettyCashBookExists(pettyCashBook.PettyCashBookId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", pettyCashBook.StoreId);
            return View(pettyCashBook);
        }

        // GET: Stores/PettyCashBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pettyCashBook = await _context.PettyCashBooks
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.PettyCashBookId == id);
            if (pettyCashBook == null)
            {
                return NotFound();
            }

            return View(pettyCashBook);
        }

        // POST: Stores/PettyCashBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pettyCashBook = await _context.PettyCashBooks.FindAsync(id);
            _context.PettyCashBooks.Remove(pettyCashBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PettyCashBookExists(int id)
        {
            return _context.PettyCashBooks.Any(e => e.PettyCashBookId == id);
        }
    }
}
