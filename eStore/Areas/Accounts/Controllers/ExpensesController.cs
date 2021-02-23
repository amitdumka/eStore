using eStore.DL.Data;
using eStore.Ops;
using eStore.Shared.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Authorize(Roles = "Admin,PowerUser,StoreManager")]
    public class ExpensesController : Controller
    {
        private readonly eStoreDbContext _context;
        private readonly string _returnUrl = "/Identity/Account/Login?ReturnUrl=/Accounts/Expenses";

        public ExpensesController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accountings/Expenses
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.Expenses.Include(e => e.FromAccount).Include(e => e.PaidBy).Include(e => e.Party).Include(e => e.Store);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Accountings/Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.FromAccount)
                .Include(e => e.PaidBy)
                .Include(e => e.Party)
                .Include(e => e.Store).OrderByDescending(c=>c.OnDate)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expense == null)
            {
                return NotFound();
            }

            return PartialView(expense);
        }

        // GET: Accountings/Expenses/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName");
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName");
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            return PartialView();
        }

        // POST: Accountings/Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseId,Particulars,PartyName,EmployeeId,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserId,EntryStatus")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                if (expense.PayMode == PaymentMode.Cash)
                {
                    expense.BankAccountId = null;
                }
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", expense.BankAccountId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName", expense.EmployeeId);
            ViewData["PartyId"] = new SelectList(_context.Parties.OrderBy(c=>c.PartyName), "PartyId", "PartyName", expense.PartyId);
            ViewData["StoreId"] = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, _returnUrl);

            Console.WriteLine($"StoreId+{expense.StoreId}\tEnt {expense.EntryStatus},\t us {expense.UserId}, \taa=" + ModelState.IsValid);
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(expense);
        }

        // GET: Accountings/Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", expense.BankAccountId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName", expense.EmployeeId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", expense.PartyId);
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", expense.StoreId);
            return PartialView(expense);
        }

        // POST: Accountings/Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseId,Particulars,PartyName,EmployeeId,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserId")] Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (expense.PayMode == PaymentMode.Cash)
                    {
                        expense.BankAccountId = null;
                    }
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ExpenseId))
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "Account", expense.BankAccountId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName", expense.EmployeeId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", expense.PartyId);
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", expense.StoreId);
            return View(expense);
        }

        // GET: Accountings/Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.FromAccount)
                .Include(e => e.PaidBy)
                .Include(e => e.Party)
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expense == null)
            {
                return NotFound();
            }

            return PartialView(expense);
        }

        // POST: Accountings/Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpenseId == id);
        }
    }
}
