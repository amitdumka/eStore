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
    public class ExpensesController : Controller
    {
        private readonly eStoreDbContext _context;

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
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Accountings/Expenses/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Accountings/Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseId,Particulars,PartyName,EmployeeId,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserName")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId", expense.BankAccountId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", expense.EmployeeId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId", expense.PartyId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", expense.StoreId);
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId", expense.BankAccountId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", expense.EmployeeId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId", expense.PartyId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", expense.StoreId);
            return View(expense);
        }

        // POST: Accountings/Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseId,Particulars,PartyName,EmployeeId,OnDate,PayMode,BankAccountId,PaymentDetails,Amount,Remarks,PartyId,LedgerEnteryId,IsCash,StoreId,UserName")] Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccounts, "BankAccountId", "BankAccountId", expense.BankAccountId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", expense.EmployeeId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId", expense.PartyId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", expense.StoreId);
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

            return View(expense);
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
