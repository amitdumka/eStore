using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Sales;

namespace eStore.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySaleController : ControllerBase
    {
        private readonly eStoreDbContext _context;

        public DailySaleController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/DailySale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailySale>>> GetDailySales()
        {
            return await _context.DailySales.ToListAsync();
        }

        // GET: api/DailySale/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailySale>> GetDailySale(int id)
        {
            var dailySale = await _context.DailySales.FindAsync(id);

            if (dailySale == null)
            {
                return NotFound();
            }

            return dailySale;
        }

        // PUT: api/DailySale/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailySale(int id, DailySale dailySale)
        {
            if (id != dailySale.DailySaleId)
            {
                return BadRequest();
            }

            _context.Entry(dailySale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailySaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DailySale
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailySale>> PostDailySale(DailySale dailySale)
        {
            _context.DailySales.Add(dailySale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailySale", new { id = dailySale.DailySaleId }, dailySale);
        }

        // DELETE: api/DailySale/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailySale(int id)
        {
            var dailySale = await _context.DailySales.FindAsync(id);
            if (dailySale == null)
            {
                return NotFound();
            }

            _context.DailySales.Remove(dailySale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailySaleExists(int id)
        {
            return _context.DailySales.Any(e => e.DailySaleId == id);
        }
    }
}
