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
    public class SaleWithCustomersController : Controller
    {
        private readonly eStoreDbContext _context;

        public SaleWithCustomersController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/SaleWithCustomers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleWithCustomers.ToListAsync());
        }

        // GET: Accounts/SaleWithCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleWithCustomer = await _context.SaleWithCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleWithCustomer == null)
            {
                return NotFound();
            }

            return View(saleWithCustomer);
        }

        // GET: Accounts/SaleWithCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/SaleWithCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceNo,InvoiceDate,InvoiceType,Quantity,BillAmt,PaymentType,CustomerName,Address,Phone,Email,DateofBirth")] SaleWithCustomer saleWithCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleWithCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleWithCustomer);
        }

        // GET: Accounts/SaleWithCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleWithCustomer = await _context.SaleWithCustomers.FindAsync(id);
            if (saleWithCustomer == null)
            {
                return NotFound();
            }
            return View(saleWithCustomer);
        }

        // POST: Accounts/SaleWithCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceNo,InvoiceDate,InvoiceType,Quantity,BillAmt,PaymentType,CustomerName,Address,Phone,Email,DateofBirth")] SaleWithCustomer saleWithCustomer)
        {
            if (id != saleWithCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleWithCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleWithCustomerExists(saleWithCustomer.Id))
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
            return View(saleWithCustomer);
        }

        // GET: Accounts/SaleWithCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleWithCustomer = await _context.SaleWithCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleWithCustomer == null)
            {
                return NotFound();
            }

            return View(saleWithCustomer);
        }

        // POST: Accounts/SaleWithCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleWithCustomer = await _context.SaleWithCustomers.FindAsync(id);
            _context.SaleWithCustomers.Remove(saleWithCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleWithCustomerExists(int id)
        {
            return _context.SaleWithCustomers.Any(e => e.Id == id);
        }
    }
}
