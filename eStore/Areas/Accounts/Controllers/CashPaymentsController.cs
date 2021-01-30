using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class CashPaymentsController : Controller
    {
        private readonly eStoreDbContext _context;

        public CashPaymentsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/CashPayments
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.CashPayments.Include(c => c.Mode).Include(c => c.Store);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: Accounts/CashPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashPayment = await _context.CashPayments
                .Include(c => c.Mode)
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashPaymentId == id);
            if (cashPayment == null)
            {
                return NotFound();
            }

            return View(cashPayment);
        }

        // GET: Accounts/CashPayments/Create
        public IActionResult Create()
        {
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "TranscationModeId");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Accounts/CashPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CashPaymentId,PaymentDate,TranscationModeId,PaidTo,Amount,SlipNo,Remarks,StoreId,UserId,EntryStatus,IsReadOnly")] CashPayment cashPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "TranscationModeId", cashPayment.TranscationModeId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashPayment.StoreId);
            return View(cashPayment);
        }

        // GET: Accounts/CashPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashPayment = await _context.CashPayments.FindAsync(id);
            if (cashPayment == null)
            {
                return NotFound();
            }
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "TranscationModeId", cashPayment.TranscationModeId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashPayment.StoreId);
            return View(cashPayment);
        }

        // POST: Accounts/CashPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CashPaymentId,PaymentDate,TranscationModeId,PaidTo,Amount,SlipNo,Remarks,StoreId,UserId,EntryStatus,IsReadOnly")] CashPayment cashPayment)
        {
            if (id != cashPayment.CashPaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashPaymentExists(cashPayment.CashPaymentId))
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
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "TranscationModeId", cashPayment.TranscationModeId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashPayment.StoreId);
            return View(cashPayment);
        }

        // GET: Accounts/CashPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashPayment = await _context.CashPayments
                .Include(c => c.Mode)
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashPaymentId == id);
            if (cashPayment == null)
            {
                return NotFound();
            }

            return View(cashPayment);
        }

        // POST: Accounts/CashPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashPayment = await _context.CashPayments.FindAsync(id);
            _context.CashPayments.Remove(cashPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashPaymentExists(int id)
        {
            return _context.CashPayments.Any(e => e.CashPaymentId == id);
        }
    }
}
