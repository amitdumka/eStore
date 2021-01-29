using eStore.DL.Data;
using eStore.Shared.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Areas.Accountings.Controllers
{
    [Area("Accountings")]
    [Authorize(Roles = "Admin,PowerUser,StoreManager")]
    public class ReceiptsController : Controller
    {
        private readonly eStoreDbContext _context;

        public ReceiptsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accountings/Receipts
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.Receipts.Include(r => r.FromAccount).Include(r => r.Party).Include(r => r.Store);
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

            return View(receipt);
        }

        // GET: Accountings/Receipts/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId");
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
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
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId", receipt.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId", receipt.PartyId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", receipt.StoreId);
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId", receipt.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId", receipt.PartyId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", receipt.StoreId);
            return View(receipt);
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId", receipt.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId", receipt.PartyId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", receipt.StoreId);
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

            return View(receipt);
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
