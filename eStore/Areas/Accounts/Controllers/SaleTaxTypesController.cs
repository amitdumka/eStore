using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Common;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class SaleTaxTypesController : Controller
    {
        private readonly eStoreDbContext _context;

        public SaleTaxTypesController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/SaleTaxTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleTaxTypes.ToListAsync());
        }

        // GET: Accounts/SaleTaxTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleTaxType = await _context.SaleTaxTypes
                .FirstOrDefaultAsync(m => m.SaleTaxTypeId == id);
            if (saleTaxType == null)
            {
                return NotFound();
            }

            return PartialView(saleTaxType);
        }

        // GET: Accounts/SaleTaxTypes/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Accounts/SaleTaxTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleTaxTypeId,TaxName,TaxType,CompositeRate")] SaleTaxType saleTaxType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleTaxType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleTaxType);
        }

        // GET: Accounts/SaleTaxTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleTaxType = await _context.SaleTaxTypes.FindAsync(id);
            if (saleTaxType == null)
            {
                return NotFound();
            }
            return PartialView(saleTaxType);
        }

        // POST: Accounts/SaleTaxTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleTaxTypeId,TaxName,TaxType,CompositeRate")] SaleTaxType saleTaxType)
        {
            if (id != saleTaxType.SaleTaxTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleTaxType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleTaxTypeExists(saleTaxType.SaleTaxTypeId))
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
            return PartialView(saleTaxType);
        }

        // GET: Accounts/SaleTaxTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleTaxType = await _context.SaleTaxTypes
                .FirstOrDefaultAsync(m => m.SaleTaxTypeId == id);
            if (saleTaxType == null)
            {
                return NotFound();
            }

            return PartialView(saleTaxType);
        }

        // POST: Accounts/SaleTaxTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleTaxType = await _context.SaleTaxTypes.FindAsync(id);
            _context.SaleTaxTypes.Remove(saleTaxType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleTaxTypeExists(int id)
        {
            return _context.SaleTaxTypes.Any(e => e.SaleTaxTypeId == id);
        }
    }
}
