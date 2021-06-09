using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Uploader;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class TaxRegistersController : Controller
    {
        private readonly eStoreDbContext _context;

        public TaxRegistersController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/TaxRegisters
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxRegisters.ToListAsync());
        }

        // GET: Accounts/TaxRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRegister = await _context.TaxRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRegister == null)
            {
                return NotFound();
            }

            return View(taxRegister);
        }

        // GET: Accounts/TaxRegisters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/TaxRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceNo,InvoiceDate,InvoiceType,BrandName,ProductName,ItemDesc,BARCODE,StyleCode,Quantity,SaleValue,DiscountAmt,BasicAmt,TaxAmt,TaxRate,TaxDesc,BillAmt")] TaxRegister taxRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxRegister);
        }

        // GET: Accounts/TaxRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRegister = await _context.TaxRegisters.FindAsync(id);
            if (taxRegister == null)
            {
                return NotFound();
            }
            return View(taxRegister);
        }

        // POST: Accounts/TaxRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceNo,InvoiceDate,InvoiceType,BrandName,ProductName,ItemDesc,BARCODE,StyleCode,Quantity,SaleValue,DiscountAmt,BasicAmt,TaxAmt,TaxRate,TaxDesc,BillAmt")] TaxRegister taxRegister)
        {
            if (id != taxRegister.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxRegisterExists(taxRegister.Id))
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
            return View(taxRegister);
        }

        // GET: Accounts/TaxRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRegister = await _context.TaxRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRegister == null)
            {
                return NotFound();
            }

            return View(taxRegister);
        }

        // POST: Accounts/TaxRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxRegister = await _context.TaxRegisters.FindAsync(id);
            _context.TaxRegisters.Remove(taxRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxRegisterExists(int id)
        {
            return _context.TaxRegisters.Any(e => e.Id == id);
        }
    }
}
