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
    public class PurchaseTaxTypesController : Controller
    {
        private readonly eStoreDbContext _context;

        public PurchaseTaxTypesController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/PurchaseTaxTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseTaxTypes.ToListAsync());
        }

        // GET: Accounts/PurchaseTaxTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseTaxType = await _context.PurchaseTaxTypes
                .FirstOrDefaultAsync(m => m.PurchaseTaxTypeId == id);
            if (purchaseTaxType == null)
            {
                return NotFound();
            }

            return View(purchaseTaxType);
        }

        // GET: Accounts/PurchaseTaxTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/PurchaseTaxTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseTaxTypeId,TaxName,TaxType,CompositeRate")] PurchaseTaxType purchaseTaxType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseTaxType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseTaxType);
        }

        // GET: Accounts/PurchaseTaxTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseTaxType = await _context.PurchaseTaxTypes.FindAsync(id);
            if (purchaseTaxType == null)
            {
                return NotFound();
            }
            return View(purchaseTaxType);
        }

        // POST: Accounts/PurchaseTaxTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseTaxTypeId,TaxName,TaxType,CompositeRate")] PurchaseTaxType purchaseTaxType)
        {
            if (id != purchaseTaxType.PurchaseTaxTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseTaxType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseTaxTypeExists(purchaseTaxType.PurchaseTaxTypeId))
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
            return View(purchaseTaxType);
        }

        // GET: Accounts/PurchaseTaxTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseTaxType = await _context.PurchaseTaxTypes
                .FirstOrDefaultAsync(m => m.PurchaseTaxTypeId == id);
            if (purchaseTaxType == null)
            {
                return NotFound();
            }

            return View(purchaseTaxType);
        }

        // POST: Accounts/PurchaseTaxTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseTaxType = await _context.PurchaseTaxTypes.FindAsync(id);
            _context.PurchaseTaxTypes.Remove(purchaseTaxType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseTaxTypeExists(int id)
        {
            return _context.PurchaseTaxTypes.Any(e => e.PurchaseTaxTypeId == id);
        }
    }
}
