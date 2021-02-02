using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.BL.Tailor;
using eStore.DL.Data;
using eStore.Shared.Models.Tailoring;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eStore.Areas.Tailoring.Controllers
{
    [Area("Tailoring")]
    public class TalioringDeliveriesController : Controller
    {
        private readonly eStoreDbContext _context;

        public TalioringDeliveriesController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Tailoring/TalioringDeliveries
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.TailoringDeliveries.Include(t => t.Booking).Include(t => t.Store);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Tailoring/TalioringDeliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talioringDelivery = await _context.TailoringDeliveries
                .Include(t => t.Booking)
                .Include(t => t.Store)
                .FirstOrDefaultAsync(m => m.TalioringDeliveryId == id);
            if (talioringDelivery == null)
            {
                return NotFound();
            }

            return PartialView(talioringDelivery);
        }

        // GET: Tailoring/TalioringDeliveries/Create
        public IActionResult Create()
        {
            ViewData["TalioringBookingId"] = new SelectList(_context.TalioringBookings, "TalioringBookingId", "BookingSlipNo");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return PartialView();
        }

        // POST: Tailoring/TalioringDeliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TalioringDeliveryId,DeliveryDate,TalioringBookingId,InvNo,Amount,Remarks,StoreId,UserId,EntryStatus,IsReadOnly")] TalioringDelivery talioringDelivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talioringDelivery);
                new TailorManager().OnUpdateData(_context, talioringDelivery, false, false);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TalioringBookingId"] = new SelectList(_context.TalioringBookings.Where(c => !c.IsDelivered), "TalioringBookingId", "BookingSlipNo", talioringDelivery.TalioringBookingId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", talioringDelivery.StoreId);
            return View(talioringDelivery);
        }

        // GET: Tailoring/TalioringDeliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talioringDelivery = await _context.TailoringDeliveries.FindAsync(id);
            if (talioringDelivery == null)
            {
                return NotFound();
            }
            ViewData["TalioringBookingId"] = new SelectList(_context.TalioringBookings, "TalioringBookingId", "BookingSlipNo", talioringDelivery.TalioringBookingId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName", talioringDelivery.StoreId);
            return PartialView(talioringDelivery);
        }

        // POST: Tailoring/TalioringDeliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TalioringDeliveryId,DeliveryDate,TalioringBookingId,InvNo,Amount,Remarks,StoreId,UserId,EntryStatus,IsReadOnly")] TalioringDelivery talioringDelivery)
        {
            if (id != talioringDelivery.TalioringDeliveryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    new TailorManager().OnUpdateData(_context, talioringDelivery, true, false);
                    _context.Update(talioringDelivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalioringDeliveryExists(talioringDelivery.TalioringDeliveryId))
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
            ViewData["TalioringBookingId"] = new SelectList(_context.TalioringBookings, "TalioringBookingId", "BookingSlipNo", talioringDelivery.TalioringBookingId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", talioringDelivery.StoreId);
            return  View(talioringDelivery);
        }

        // GET: Tailoring/TalioringDeliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talioringDelivery = await _context.TailoringDeliveries
                .Include(t => t.Booking)
                .Include(t => t.Store)
                .FirstOrDefaultAsync(m => m.TalioringDeliveryId == id);
            if (talioringDelivery == null)
            {
                return NotFound();
            }

            return PartialView(talioringDelivery);
        }

        // POST: Tailoring/TalioringDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talioringDelivery = await _context.TailoringDeliveries.FindAsync(id);
            _context.TailoringDeliveries.Remove(talioringDelivery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalioringDeliveryExists(int id)
        {
            return _context.TailoringDeliveries.Any(e => e.TalioringDeliveryId == id);
        }
    }
}
