using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts.Expenses;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class RentedLocationsController : Controller
    {
        private readonly eStoreDbContext _context;

        public RentedLocationsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/RentedLocations
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.RentedLocations.Include(r => r.Store);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Accounts/RentedLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedLocation = await _context.RentedLocations
                .Include(r => r.Store)
                .FirstOrDefaultAsync(m => m.RentedLocationId == id);
            if (rentedLocation == null)
            {
                return NotFound();
            }

            return PartialView(rentedLocation);
        }

        // GET: Accounts/RentedLocations/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return PartialView();
        }

        // POST: Accounts/RentedLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentedLocationId,PlaceName,Address,OnDate,VacatedDate,City,OwnerName,MobileNo,RentAmount,AdvanceAmount,IsRented,RentType,StoreId,UserId,IsReadOnly")] RentedLocation rentedLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentedLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", rentedLocation.StoreId);
            return PartialView(rentedLocation);
        }

        // GET: Accounts/RentedLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedLocation = await _context.RentedLocations.FindAsync(id);
            if (rentedLocation == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", rentedLocation.StoreId);
            return PartialView(rentedLocation);
        }

        // POST: Accounts/RentedLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentedLocationId,PlaceName,Address,OnDate,VacatedDate,City,OwnerName,MobileNo,RentAmount,AdvanceAmount,IsRented,RentType,StoreId,UserId,IsReadOnly")] RentedLocation rentedLocation)
        {
            if (id != rentedLocation.RentedLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentedLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentedLocationExists(rentedLocation.RentedLocationId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", rentedLocation.StoreId);
            return PartialView(rentedLocation);
        }

        // GET: Accounts/RentedLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentedLocation = await _context.RentedLocations
                .Include(r => r.Store)
                .FirstOrDefaultAsync(m => m.RentedLocationId == id);
            if (rentedLocation == null)
            {
                return NotFound();
            }

            return PartialView(rentedLocation);
        }

        // POST: Accounts/RentedLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentedLocation = await _context.RentedLocations.FindAsync(id);
            _context.RentedLocations.Remove(rentedLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentedLocationExists(int id)
        {
            return _context.RentedLocations.Any(e => e.RentedLocationId == id);
        }
    }
}
