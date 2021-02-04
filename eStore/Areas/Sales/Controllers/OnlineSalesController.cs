using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using eStore.DL.Data;
using eStore.Shared.Models.Sales;

namespace eStore.Areas.Sales.Controllers
{
    [Area("Sales")]
    [Authorize]
    public class OnlineSalesController : Controller
    {
        private readonly eStoreDbContext _context;

        public OnlineSalesController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Sales/OnlineSales
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.OnlineSales.Include(o => o.Vendor);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Sales/OnlineSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var OnlineSales = await _context.OnlineSales
                .Include(o => o.Vendor)
                .FirstOrDefaultAsync(m => m.OnlineSaleId == id);
            if (OnlineSales == null)
            {
                return NotFound();
            }

            return PartialView(OnlineSales);
        }

        // GET: Sales/OnlineSales/Create
        public IActionResult Create()
        {
            ViewData["OnlineVendorId"] = new SelectList(_context.Set<OnlineVendor>(), "OnlineVendorId", "OnlineVendorId");
            return PartialView();
        }

        // POST: Sales/OnlineSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnlineSaleId,SaleDate,InvNo,Amount,VoyagerInvoiceNo,VoygerDate,VoyagerAmount,ShippingMode,VendorFee,ProfitValue,Remarks,OnlineVendorId")] OnlineSale OnlineSales)
        {
            if (ModelState.IsValid)
            {
                OnlineSales.UserId = User.Identity.Name;
                _context.Add(OnlineSales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OnlineVendorId"] = new SelectList(_context.Set<OnlineVendor>(), "OnlineVendorId", "OnlineVendorId", OnlineSales.OnlineVendorId);
            return PartialView(OnlineSales);
        }

        // GET: Sales/OnlineSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var OnlineSales = await _context.OnlineSales.FindAsync(id);
            // if (OnlineSales == null)
            // {
            //     return NotFound();
            // }
            //// ViewData["OnlineVendorId"] = new SelectList(_context.Set<OnlineVendor>(), "OnlineVendorId", "OnlineVendorId", OnlineSales.OnlineVendorId);
            // return PartialView(OnlineSales);
            return View();
        }

        // POST: Sales/OnlineSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnlineSaleId,SaleDate,InvNo,Amount,VoyagerInvoiceNo,VoygerDate,VoyagerAmount,ShippingMode,VendorFee,ProfitValue,Remarks,OnlineVendorId")] OnlineSale OnlineSales)
        {
            if (id != OnlineSales.OnlineSaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // OnlineSales.UserName = User.Identity.Name;
                    _context.Update(OnlineSales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlineSaleExists(OnlineSales.OnlineSaleId))
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
            ViewData["OnlineVendorId"] = new SelectList(_context.Set<OnlineVendor>(), "OnlineVendorId", "OnlineVendorId", OnlineSales.OnlineVendorId);
            return PartialView(OnlineSales);
        }

        // GET: Sales/OnlineSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var OnlineSales = await _context.OnlineSales
                .Include(o => o.Vendor)
                .FirstOrDefaultAsync(m => m.OnlineSaleId == id);
            if (OnlineSales == null)
            {
                return NotFound();
            }

            return PartialView(OnlineSales);
        }

        // POST: Sales/OnlineSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var OnlineSales = await _context.OnlineSales.FindAsync(id);
            _context.OnlineSales.Remove(OnlineSales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlineSaleExists(int id)
        {
            return _context.OnlineSales.Any(e => e.OnlineSaleId == id);
        }
    }
}
