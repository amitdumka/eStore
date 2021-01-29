using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using eStore.DL.Data;
using eStore.Shared.Models.Sales;

namespace eStore.Areas.Sales.Controllers
{
    [Area("Sales")]
    [Authorize]
    public class OnlineVendorsController : Controller
    {
        private readonly eStoreDbContext _context;

        public OnlineVendorsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Sales/OnlineVendors
        public async Task<IActionResult> Index()
        {
            return View(await _context.OnlineVendors.ToListAsync());
        }

        // GET: Sales/OnlineVendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineVendor = await _context.OnlineVendors
                .FirstOrDefaultAsync(m => m.OnlineVendorId == id);
            if (onlineVendor == null)
            {
                return NotFound();
            }

            return View(onlineVendor);
        }

        // GET: Sales/OnlineVendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sales/OnlineVendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnlineVendorId,VendorName,OnDate,IsActive,Remark,OffDate,Reason")] OnlineVendor onlineVendor)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(onlineVendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onlineVendor);
        }

        // GET: Sales/OnlineVendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineVendor = await _context.OnlineVendors.FindAsync(id);
            if (onlineVendor == null)
            {
                return NotFound();
            }
            return View(onlineVendor);
        }

        // POST: Sales/OnlineVendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnlineVendorId,VendorName,OnDate,IsActive,Remark,OffDate,Reason")] OnlineVendor onlineVendor)
        {
            if (id != onlineVendor.OnlineVendorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onlineVendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlineVendorExists(onlineVendor.OnlineVendorId))
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
            return View(onlineVendor);
        }

        // GET: Sales/OnlineVendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlineVendor = await _context.OnlineVendors
                .FirstOrDefaultAsync(m => m.OnlineVendorId == id);
            if (onlineVendor == null)
            {
                return NotFound();
            }

            return View(onlineVendor);
        }

        // POST: Sales/OnlineVendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onlineVendor = await _context.OnlineVendors.FindAsync(id);
            _context.OnlineVendors.Remove(onlineVendor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlineVendorExists(int id)
        {
            return _context.OnlineVendors.Any(e => e.OnlineVendorId == id);
        }
    }
}
