using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Payroll;
using eStore.Ops;
using eStore.Validator;

using eStore.Payroll;
using System;
using eStore.BL.DataHelpers;
using System.Globalization;

namespace eStore.Areas.Payrolls.Controllers
{
    [Area("Payroll")]
    public class AttendancesController : Controller
    {
        private readonly eStoreDbContext _context;

        public AttendancesController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Payrolls/Attendances
        public async Task<IActionResult> Index(int? id, string currentFilter, string searchString, int? pageNumber, string MonthName, DateTime? OnDate)
        {
            int StoreId = 1;
            // TODO: implement StoreID on this
            //string mName = "Jan";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var eStoreContext = _context.Attendances.Include(a => a.Employee).Include(a => a.Store).Where(c => c.AttDate == DateTime.Today && c.StoreId == StoreId);

            var YearList = _context.Attendances.GroupBy(c => c.AttDate.Year).Select(c => c.Key).ToList();
            YearList.Sort();
            ViewBag.YearList = YearList;
            var MonthList = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList();

            ViewBag.MonthList = MonthList;

            if (OnDate != null)
            {
                eStoreContext = _context.Attendances.Include(a => a.Employee).Where(c => c.StoreId == StoreId && c.AttDate.Date == OnDate.Value.Date).OrderByDescending(c => c.AttDate).ThenBy(c => c.EmployeeId);
            }
            else if (id == 101)
            {
                eStoreContext = _context.Attendances.Include(a => a.Employee).Where(c => c.StoreId == StoreId).OrderByDescending(c => c.AttDate).ThenBy(c => c.EmployeeId);
                //return View(await aprajitaRetailsContext_all.ToListAsync());
            }
            else if (id == 100)
            {
                eStoreContext = _context.Attendances.Include(a => a.Employee).Where(c => c.AttDate.Month == DateTime.Today.Month && c.AttDate.Year == DateTime.Today.Year && c.StoreId == StoreId).OrderByDescending(c => c.AttDate).ThenBy(c => c.EmployeeId);
                //return View(await aprajitaRetailsContext_all.ToListAsync());
            }
            else if (id == 102)
            {
                eStoreContext = _context.Attendances.Include(a => a.Employee).Where(c => c.AttDate.Month == DateTime.Today.Month - 1 && c.AttDate.Year == DateTime.Today.Year && c.StoreId == StoreId).OrderByDescending(c => c.AttDate).ThenBy(c => c.EmployeeId);
            }
            else
            {
                if (id != null && YearList.Contains((int)id))
                {
                    ViewBag.YearName = id;
                    if (!string.IsNullOrEmpty(MonthName))
                    {
                        //  mName = MonthName;
                        int mn = MonthList.IndexOf(MonthName) + 1;
                        eStoreContext = _context.Attendances.Include(a => a.Employee).Where(c => c.AttDate.Year == id && c.AttDate.Month == mn && c.StoreId == StoreId).OrderByDescending(c => c.AttDate).ThenBy(c => c.EmployeeId);

                    }
                    else
                        eStoreContext = _context.Attendances.Include(a => a.Employee).Where(c => c.AttDate.Year == id && c.StoreId == StoreId).OrderByDescending(c => c.AttDate).ThenBy(c => c.EmployeeId);
                }
                else
                {

                }

            }




            return View(await eStoreContext.ToListAsync());
        }

        // GET: Payrolls/Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Employee)
                .Include(a => a.Store)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return PartialView(attendance);
        }

        // GET: Payrolls/Attendances/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName");
            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = storeInfo.StoreId;
            ViewData["UserName"] = storeInfo.UserName;
            return PartialView();
        }

        // POST: Payrolls/Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,EmployeeId,AttDate,EntryTime,Status,Remarks,IsTailoring,StoreId,UserId,EntryStatus,IsReadOnly")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                if (DBValidation.AttendanceDuplicateCheck(_context, attendance))
                {
                    ViewBag.ErrorMessage = "Attendance already added!. Possible duplicate entry.";
                    ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName", attendance.EmployeeId);
                    StoreInfo storeInfo1 = PostLogin.ReadStoreInfo(HttpContext.Session);
                    ViewData["StoreId"] = storeInfo1.StoreId;
                    ViewData["UserName"] = storeInfo1.UserName;
                    return  View(attendance);
                }
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                new PayrollManager().ONInsertOrUpdate(_context, attendance, false, false);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName", attendance.EmployeeId);
            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = storeInfo.StoreId;
            ViewData["UserName"] = storeInfo.UserName;
            return  View(attendance);
        }

        // GET: Payrolls/Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName", attendance.EmployeeId);
            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = attendance.StoreId;
            ViewData["UserName"] = storeInfo.UserName;
            return PartialView(attendance);
        }

        // POST: Payrolls/Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,EmployeeId,AttDate,EntryTime,Status,Remarks,IsTailoring,StoreId,UserId,EntryStatus,IsReadOnly")] Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                    new PayrollManager().ONInsertOrUpdate(_context, attendance, false, true);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "StaffName", attendance.EmployeeId);
            StoreInfo storeInfo = PostLogin.ReadStoreInfo(HttpContext.Session);
            ViewData["StoreId"] = attendance.StoreId;
            ViewData["UserName"] = storeInfo.UserName;
            return View(attendance);
        }

        // GET: Payrolls/Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Employee)
                .Include(a => a.Store)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return PartialView(attendance);
        }

        // POST: Payrolls/Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
            new PayrollManager().ONInsertOrUpdate(_context, attendance, true, false);
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendances.Any(e => e.AttendanceId == id);
        }

        public async Task<IActionResult> EmpDetails(int? id, string? ondate)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ToString("dd-MM-yyyy")
            var empid = _context.Attendances.Find(id).EmployeeId;

            DateTime ValidDate = DateTime.Today;
            //if (onDate != null) ValidDate = (DateTime)onDate;
            if (!string.IsNullOrEmpty(ondate))
            {
                if (!DateTime.TryParse(ondate, out ValidDate))
                {
                    ValidDate = DateTime.Today;
                }
            }
            var attList = _context.Attendances.Include(c => c.Employee)
                .Where(c => c.EmployeeId == empid && c.AttDate.Month == ValidDate.Month && c.AttDate.Year == ValidDate.Year)
                .OrderBy(c => c.AttDate);
            var p = attList.Where(c => c.Status == AttUnit.Present).Count();
            var a = attList.Where(c => c.Status == AttUnit.Absent).Count();
            int noofdays = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            int noofsunday = DateHelper.CountDays(DayOfWeek.Sunday, DateTime.Today);
            int sunPresent = attList.Where(c => c.Status == AttUnit.Sunday).Count();
            int halfDays = attList.Where(c => c.Status == AttUnit.HalfDay).Count();
            int totalAtt = p + sunPresent + (halfDays / 2);

            ViewBag.Present = p;
            ViewBag.Absent = a;
            ViewBag.WorkingDays = noofdays;
            ViewBag.Sundays = noofsunday;
            ViewBag.SundayPresent = sunPresent;
            ViewBag.HalfDays = halfDays;
            ViewBag.Total = totalAtt;
            if (attList == null)
            {
                return NotFound();
            }
            if (attList.Any())
                ViewBag.EmpName = attList.First().Employee.StaffName;
            return PartialView(await attList.ToListAsync());
        }
    }
}
