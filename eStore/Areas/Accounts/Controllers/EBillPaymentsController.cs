using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts.Expenses;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class EBillPaymentsController : Controller
    {
        private readonly eStoreDbContext _context;

        public EBillPaymentsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/EBillPayments
        public async Task<IActionResult> Index()
        {
            var eStoreContext = _context.BillPayments.Include(e => e.Bill).Include(e => e.Store);
            return View(await eStoreContext.ToListAsync());
        }

        // GET: Accounts/EBillPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBillPayment = await _context.BillPayments
                .Include(e => e.Bill)
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.EBillPaymentId == id);
            if (eBillPayment == null)
            {
                return NotFound();
            }

            return View(eBillPayment);
        }

        // GET: Accounts/EBillPayments/Create
        public IActionResult Create()
        {
            ViewData["EletricityBillId"] = new SelectList(_context.EletricityBills, "EletricityBillId", "EletricityBillId");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Accounts/EBillPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EBillPaymentId,EletricityBillId,PaymentDate,Amount,Mode,PaymentDetails,Remarks,IsPartialPayment,IsBillCleared,StoreId,UserId,EntryStatus,IsReadOnly")] EBillPayment eBillPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eBillPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EletricityBillId"] = new SelectList(_context.EletricityBills, "EletricityBillId", "EletricityBillId", eBillPayment.EletricityBillId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", eBillPayment.StoreId);
            return View(eBillPayment);
        }

        // GET: Accounts/EBillPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBillPayment = await _context.BillPayments.FindAsync(id);
            if (eBillPayment == null)
            {
                return NotFound();
            }
            ViewData["EletricityBillId"] = new SelectList(_context.EletricityBills, "EletricityBillId", "EletricityBillId", eBillPayment.EletricityBillId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", eBillPayment.StoreId);
            return View(eBillPayment);
        }

        // POST: Accounts/EBillPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EBillPaymentId,EletricityBillId,PaymentDate,Amount,Mode,PaymentDetails,Remarks,IsPartialPayment,IsBillCleared,StoreId,UserId,EntryStatus,IsReadOnly")] EBillPayment eBillPayment)
        {
            if (id != eBillPayment.EBillPaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eBillPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EBillPaymentExists(eBillPayment.EBillPaymentId))
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
            ViewData["EletricityBillId"] = new SelectList(_context.EletricityBills, "EletricityBillId", "EletricityBillId", eBillPayment.EletricityBillId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", eBillPayment.StoreId);
            return View(eBillPayment);
        }

        // GET: Accounts/EBillPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBillPayment = await _context.BillPayments
                .Include(e => e.Bill)
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.EBillPaymentId == id);
            if (eBillPayment == null)
            {
                return NotFound();
            }

            return View(eBillPayment);
        }

        // POST: Accounts/EBillPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eBillPayment = await _context.BillPayments.FindAsync(id);
            _context.BillPayments.Remove(eBillPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EBillPaymentExists(int id)
        {
            return _context.BillPayments.Any(e => e.EBillPaymentId == id);
        }
    }
}
