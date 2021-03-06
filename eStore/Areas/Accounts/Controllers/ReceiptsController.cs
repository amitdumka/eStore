﻿using eStore.DL.Data;
using eStore.Ops;
using eStore.Shared.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Authorize(Roles = "Admin,PowerUser,StoreManager")]
    public class ReceiptsController : Controller
    {
        private readonly eStoreDbContext _context;
        private readonly string _returnUrl = "/Identity/Account/Login?ReturnUrl=/Accounts/Payments";


        public ReceiptsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accountings/Receipts
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.Receipts.Include(r => r.FromAccount).Include(r => r.Party).Include(r => r.Store).OrderByDescending(c => c.OnDate);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Accountings/Receipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts
                .Include(r => r.FromAccount)
                .Include(r => r.Party)
                .Include(r => r.Store)
                .FirstOrDefaultAsync(m => m.ReceiptId == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return PartialView(receipt);
        }

        // GET: Accountings/Receipts/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account");
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName");
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return PartialView();
        }

        // POST: Accountings/Receipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceiptId,PartyName,RecieptSlipNo,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserName")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                if (receipt.PayMode == PaymentMode.Cash)
                {
                    receipt.BankAccountId = null;
                }
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", receipt.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", receipt.PartyId);
             ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return View(receipt);
        }

        // GET: Accountings/Receipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", receipt.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", receipt.PartyId);
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return PartialView(receipt);
        }

        // POST: Accountings/Receipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceiptId,PartyName,RecieptSlipNo,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserName")] Receipt receipt)
        {
            if (id != receipt.ReceiptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (receipt.PayMode == PaymentMode.Cash)
                    {
                        receipt.BankAccountId = null;
                    }
                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.ReceiptId))
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", receipt.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", receipt.PartyId);
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return View(receipt);
        }

        // GET: Accountings/Receipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts
                .Include(r => r.FromAccount)
                .Include(r => r.Party)
                .Include(r => r.Store)
                .FirstOrDefaultAsync(m => m.ReceiptId == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return PartialView(receipt);
        }

        // POST: Accountings/Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipts.Any(e => e.ReceiptId == id);
        }
    }
}
