using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Tailoring;
using eStore.Ops;

namespace eStore.Areas.Tailoring.Controllers
{
    [Area("Tailoring")]
    public class TalioringBookingsController : Controller
    {
        private readonly eStoreDbContext _context;

        public TalioringBookingsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Tailoring/TalioringBookings
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.TalioringBookings.Include(t => t.Store);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Tailoring/TalioringBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talioringBooking = await _context.TalioringBookings
                .Include(t => t.Store)
                .FirstOrDefaultAsync(m => m.TalioringBookingId == id);
            if (talioringBooking == null)
            {
                return NotFound();
            }

            return PartialView(talioringBooking);
        }

        // GET: Tailoring/TalioringBookings/Create
        public IActionResult Create()
        {
            // Setting Store Info Here

            ViewBag.StoreID = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, "/Identity/Account/Login?ReturnUrl=/Tailoring/TalioringBookings");

            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return PartialView();
        }

        // POST: Tailoring/TalioringBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TalioringBookingId,BookingDate,CustName,DeliveryDate,TryDate,BookingSlipNo,TotalAmount,TotalQty,ShirtQty,ShirtPrice,PantQty,PantPrice,CoatQty,CoatPrice,KurtaQty,KurtaPrice,BundiQty,BundiPrice,Others,OthersPrice,IsDelivered,StoreId,UserId,EntryStatus,IsReadOnly")] TalioringBooking talioringBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talioringBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.StoreID = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, "/Identity/Account/Login?ReturnUrl=/Tailoring/TalioringBookings");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", talioringBooking.StoreId);
            return View(talioringBooking);
        }

        // GET: Tailoring/TalioringBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talioringBooking = await _context.TalioringBookings.FindAsync(id);
            if (talioringBooking == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", talioringBooking.StoreId);
            return PartialView(talioringBooking);
        }

        // POST: Tailoring/TalioringBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TalioringBookingId,BookingDate,CustName,DeliveryDate,TryDate,BookingSlipNo,TotalAmount,TotalQty,ShirtQty,ShirtPrice,PantQty,PantPrice,CoatQty,CoatPrice,KurtaQty,KurtaPrice,BundiQty,BundiPrice,Others,OthersPrice,IsDelivered,StoreId,UserId,EntryStatus,IsReadOnly")] TalioringBooking talioringBooking)
        {
            if (id != talioringBooking.TalioringBookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talioringBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalioringBookingExists(talioringBooking.TalioringBookingId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", talioringBooking.StoreId);
            return View(talioringBooking);
        }

        // GET: Tailoring/TalioringBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talioringBooking = await _context.TalioringBookings
                .Include(t => t.Store)
                .FirstOrDefaultAsync(m => m.TalioringBookingId == id);
            if (talioringBooking == null)
            {
                return NotFound();
            }

            return PartialView(talioringBooking);
        }

        // POST: Tailoring/TalioringBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talioringBooking = await _context.TalioringBookings.FindAsync(id);
            _context.TalioringBookings.Remove(talioringBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalioringBookingExists(int id)
        {
            return _context.TalioringBookings.Any(e => e.TalioringBookingId == id);
        }
        #region OldData

        public async Task<IActionResult> PendingBooking(int? id)
        {
            var vd = _context.TalioringBookings.Where(c => c.IsDelivered == false);

            if(id!=null)
            {
                if (vd != null)
                    return PartialView(await vd.ToListAsync());
                else
                    return NotFound();
            }

            if (vd != null)
                return View(await vd.ToListAsync());
            else
                return NotFound();
        }
        #endregion
    }
}
