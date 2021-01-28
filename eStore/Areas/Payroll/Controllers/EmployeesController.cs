using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Payroll;
using eStore.Ops;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using eStore.Shared.Models.Identity;
using eStore.Payroll;


namespace eStore.Areas.Payrolls.Controllers
{

    [Area("Payroll")]
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly eStoreDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EmployeesController(eStoreDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Payrolls/Employees
        public async Task<IActionResult> Index()
        {
            var eStoreContext = _context.Employees.Include(e => e.Store);
            return View(await eStoreContext.ToListAsync());
        }

        // GET: Payrolls/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return PartialView(employee);
        }

        // GET: Payrolls/Employees/Create
        public IActionResult Create()
        {
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = storeInfo.StoreId;
            ViewData["UserName"] = storeInfo.UserName;

            return PartialView();
        }

        // POST: Payrolls/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,MobileNo,JoiningDate,LeavingDate,IsWorking,Category,IsTailors,EMail,DateOfBirth,AdharNumber,PanNo,OtherIdDetails,Address,City,State,FatherName,HighestQualification,StoreId,UserId,EntryStatus,IsReadOnly")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                await EmployeeManager.AddEmployeeLoginAsync(_context, employee, _userManager);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", employee.StoreId);
            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = storeInfo.StoreId;
            ViewData["UserName"] = storeInfo.UserName;

            return PartialView(employee);
        }

        // GET: Payrolls/Employees/Edit/5
        [Authorize(Roles = "Admin,PowerUser,Accountant")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", employee.StoreId);
           // StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = employee.StoreId;
            ViewData["UserName"] = employee.UserId;

            return PartialView(employee);
        }

        // POST: Payrolls/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,PowerUser,Accountant")]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,MobileNo,JoiningDate,LeavingDate,IsWorking,Category,IsTailors,EMail,DateOfBirth,AdharNumber,PanNo,OtherIdDetails,Address,City,State,FatherName,HighestQualification,StoreId,UserId,EntryStatus,IsReadOnly")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            // ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", employee.StoreId);
            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = storeInfo.StoreId;
            ViewData["UserName"] = storeInfo.UserName;

            return PartialView(employee);
        }

        // GET: Payrolls/Employees/Delete/5
        [Authorize(Roles = "Admin,PowerUser,Accountant")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return PartialView(employee);
        }

        // POST: Payrolls/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,PowerUser,Accountant")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
