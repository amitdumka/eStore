using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts.Expenses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eStore.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class ElectricityConnectionsController : Controller
    {
        private readonly eStoreDbContext _context;

        public ElectricityConnectionsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: Accounts/ElectricityConnections
        public async Task<IActionResult> Index()
        {
            var aprajitaRetailsContext = _context.ElectricityConnections.Include(e => e.Store);
            return View(await aprajitaRetailsContext.ToListAsync());
        }

        // GET: Accounts/ElectricityConnections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityConnection = await _context.ElectricityConnections
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.ElectricityConnectionId == id);
            if (electricityConnection == null)
            {
                return NotFound();
            }

            return View(electricityConnection);
        }

        // GET: Accounts/ElectricityConnections/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return View();
        }

        // POST: Accounts/ElectricityConnections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ElectricityConnectionId,LocationName,ConnectioName,City,State,PinCode,ConsumerNumber,ConusumerId,Connection,ConnectinDate,DisconnectionDate,KVLoad,OwnedMetter,TotalConnectionCharges,SecurityDeposit,Remarks,StoreId,UserId,IsReadOnly")] ElectricityConnection electricityConnection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electricityConnection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", electricityConnection.StoreId);
            return View(electricityConnection);
        }

        // GET: Accounts/ElectricityConnections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityConnection = await _context.ElectricityConnections.FindAsync(id);
            if (electricityConnection == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", electricityConnection.StoreId);
            return View(electricityConnection);
        }

        // POST: Accounts/ElectricityConnections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ElectricityConnectionId,LocationName,ConnectioName,City,State,PinCode,ConsumerNumber,ConusumerId,Connection,ConnectinDate,DisconnectionDate,KVLoad,OwnedMetter,TotalConnectionCharges,SecurityDeposit,Remarks,StoreId,UserId,IsReadOnly")] ElectricityConnection electricityConnection)
        {
            if (id != electricityConnection.ElectricityConnectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electricityConnection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectricityConnectionExists(electricityConnection.ElectricityConnectionId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", electricityConnection.StoreId);
            return View(electricityConnection);
        }

        // GET: Accounts/ElectricityConnections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electricityConnection = await _context.ElectricityConnections
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.ElectricityConnectionId == id);
            if (electricityConnection == null)
            {
                return NotFound();
            }

            return View(electricityConnection);
        }

        // POST: Accounts/ElectricityConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electricityConnection = await _context.ElectricityConnections.FindAsync(id);
            _context.ElectricityConnections.Remove(electricityConnection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectricityConnectionExists(int id)
        {
            return _context.ElectricityConnections.Any(e => e.ElectricityConnectionId == id);
        }
    }
}
