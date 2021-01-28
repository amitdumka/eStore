using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> Index()
        {
            var eStoreContext = _context.Attendances.Include(a => a.Employee).Include(a => a.Store);
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
                    return PartialView(attendance);
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
            return PartialView(attendance);
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
            return PartialView(attendance);
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
    }
}
