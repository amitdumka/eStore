using eStore.DL.Data;
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
    public class PaymentsController : Controller
    {
        private readonly eStoreDbContext _context;
        private readonly string _returnUrl = "/Identity/Account/Login?ReturnUrl=/Accounts/Payments";

        public PaymentsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accountings/Payments
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.Payments.Include(p => p.FromAccount).Include(p => p.Party).Include(p => p.Store);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Accountings/Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.FromAccount)
                .Include(p => p.Party)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return PartialView(payment);
        }

        // GET: Accountings/Payments/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account");
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName");
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);
            return PartialView();
        }

        // POST: Accountings/Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,PartyName,PaymentSlipNo,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                if (payment.PayMode == PaymentMode.Cash)
                {
                    payment.BankAccountId = null;
                }
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", payment.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", payment.PartyId);
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return  View(payment);
        }

        // GET: Accountings/Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", payment.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", payment.PartyId);
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);
            return PartialView(payment);
        }

        // POST: Accountings/Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,PartyName,PaymentSlipNo,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserId")] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (payment.PayMode == PaymentMode.Cash)
                    {
                        payment.BankAccountId = null;
                    }
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", payment.BankAccountId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", payment.PartyId);
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return  View(payment);
        }

        // GET: Accountings/Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.FromAccount)
                .Include(p => p.Party)
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return PartialView(payment);
        }

        // POST: Accountings/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentId == id);
        }
    }
}
