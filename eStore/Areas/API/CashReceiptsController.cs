using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts;

namespace eStore.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashReceiptsController : ControllerBase
    {
        private readonly eStoreDbContext _context;

        public CashReceiptsController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/CashReceipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashReceipt>>> GetCashReceipts()
        {
            return await _context.CashReceipts.ToListAsync();
        }

        // GET: api/CashReceipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashReceipt>> GetCashReceipt(int id)
        {
            var cashReceipt = await _context.CashReceipts.FindAsync(id);

            if (cashReceipt == null)
            {
                return NotFound();
            }

            return cashReceipt;
        }

        // PUT: api/CashReceipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashReceipt(int id, CashReceipt cashReceipt)
        {
            if (id != cashReceipt.CashReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(cashReceipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashReceiptExists(id))
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

        // POST: api/CashReceipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CashReceipt>> PostCashReceipt(CashReceipt cashReceipt)
        {
            _context.CashReceipts.Add(cashReceipt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashReceipt", new { id = cashReceipt.CashReceiptId }, cashReceipt);
        }

        // DELETE: api/CashReceipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashReceipt(int id)
        {
            var cashReceipt = await _context.CashReceipts.FindAsync(id);
            if (cashReceipt == null)
            {
                return NotFound();
            }

            _context.CashReceipts.Remove(cashReceipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CashReceiptExists(int id)
        {
            return _context.CashReceipts.Any(e => e.CashReceiptId == id);
        }
    }
}
