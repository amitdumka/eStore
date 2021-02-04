using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts;
using eStore.Ops;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class CashReceiptsController : Controller
    {
        private readonly eStoreDbContext _context;
        private readonly string _returnUrl = "/Identity/Account/Login?ReturnUrl=/Accounts/CashReceipts";


        public CashReceiptsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/CashReceipts
        public async Task<IActionResult> Index()
        {
            var eStoreDbContext = _context.CashReceipts.Include(c => c.Mode).Include(c => c.Store);
            return View(await eStoreDbContext.ToListAsync());
        }

        // GET: Accounts/CashReceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceipt = await _context.CashReceipts
                .Include(c => c.Mode)
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashReceiptId == id);
            if (cashReceipt == null)
            {
                return NotFound();
            }

            return PartialView(cashReceipt);
        }

        // GET: Accounts/CashReceipts/Create
        public IActionResult Create()
        {
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "Transcation");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Accounts/CashReceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CashReceiptId,InwardDate,TranscationModeId,ReceiptFrom,Amount,SlipNo,Remarks,StoreId,UserId,EntryStatus,IsReadOnly")] CashReceipt cashReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "Transcation", cashReceipt.TranscationModeId);
            // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashReceipt.StoreId);
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return PartialView(cashReceipt);
        }

        // GET: Accounts/CashReceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceipt = await _context.CashReceipts.FindAsync(id);
            if (cashReceipt == null)
            {
                return NotFound();
            }
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "Transcation", cashReceipt.TranscationModeId);
           // ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashReceipt.StoreId);
            return PartialView(cashReceipt);
        }

        // POST: Accounts/CashReceipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CashReceiptId,InwardDate,TranscationModeId,ReceiptFrom,Amount,SlipNo,Remarks,StoreId,UserId,EntryStatus,IsReadOnly")] CashReceipt cashReceipt)
        {
            if (id != cashReceipt.CashReceiptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashReceiptExists(cashReceipt.CashReceiptId))
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
            ViewData["TranscationModeId"] = new SelectList(_context.TranscationModes, "TranscationModeId", "Transcation", cashReceipt.TranscationModeId);
           // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", cashReceipt.StoreId);
            return PartialView(cashReceipt);
        }

        // GET: Accounts/CashReceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashReceipt = await _context.CashReceipts
                .Include(c => c.Mode)
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.CashReceiptId == id);
            if (cashReceipt == null)
            {
                return NotFound();
            }

            return PartialView(cashReceipt);
        }

        // POST: Accounts/CashReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashReceipt = await _context.CashReceipts.FindAsync(id);
            _context.CashReceipts.Remove(cashReceipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashReceiptExists(int id)
        {
            return _context.CashReceipts.Any(e => e.CashReceiptId == id);
        }
    }
}
