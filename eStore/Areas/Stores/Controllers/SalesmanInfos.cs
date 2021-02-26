using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.ViewModels.Payroll;

namespace eStore.Areas.Stores.Controllers
{
    [Area("Stores")]
    public class SalesmanInfos : Controller
    {
        private readonly eStoreDbContext _context;

        public SalesmanInfos(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Stores/SalesmanInfos
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesmanInfo.ToListAsync());
        }

        // GET: Stores/SalesmanInfos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesmanInfo = await _context.SalesmanInfo
                .FirstOrDefaultAsync(m => m.SalesmanInfoId == id);
            if (salesmanInfo == null)
            {
                return NotFound();
            }

            return View(salesmanInfo);
        }

        // GET: Stores/SalesmanInfos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/SalesmanInfos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesmanInfoId,SalesmanName,TotalSale,CurrentYear,CurrentMonth,LastMonth,LastYear,TotalBillCount,Average")] SalesmanInfo salesmanInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesmanInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesmanInfo);
        }

        // GET: Stores/SalesmanInfos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesmanInfo = await _context.SalesmanInfo.FindAsync(id);
            if (salesmanInfo == null)
            {
                return NotFound();
            }
            return View(salesmanInfo);
        }

        // POST: Stores/SalesmanInfos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesmanInfoId,SalesmanName,TotalSale,CurrentYear,CurrentMonth,LastMonth,LastYear,TotalBillCount,Average")] SalesmanInfo salesmanInfo)
        {
            if (id != salesmanInfo.SalesmanInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesmanInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesmanInfoExists(salesmanInfo.SalesmanInfoId))
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
            return View(salesmanInfo);
        }

        // GET: Stores/SalesmanInfos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesmanInfo = await _context.SalesmanInfo
                .FirstOrDefaultAsync(m => m.SalesmanInfoId == id);
            if (salesmanInfo == null)
            {
                return NotFound();
            }

            return View(salesmanInfo);
        }

        // POST: Stores/SalesmanInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesmanInfo = await _context.SalesmanInfo.FindAsync(id);
            _context.SalesmanInfo.Remove(salesmanInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesmanInfoExists(int id)
        {
            return _context.SalesmanInfo.Any(e => e.SalesmanInfoId == id);
        }
    }
}
