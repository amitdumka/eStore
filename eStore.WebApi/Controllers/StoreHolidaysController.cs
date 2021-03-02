﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eStore.DL.Data;
using eStore.Shared.Models.Stores;

namespace eStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreHolidaysController : ControllerBase
    {
        private readonly eStoreDbContext _context;

        public StoreHolidaysController(eStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/StoreHolidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreHoliday>>> GetStoreHolidays()
        {
            return await _context.StoreHolidays.ToListAsync();
        }

        // GET: api/StoreHolidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreHoliday>> GetStoreHoliday(int id)
        {
            var storeHoliday = await _context.StoreHolidays.FindAsync(id);

            if (storeHoliday == null)
            {
                return NotFound();
            }

            return storeHoliday;
        }

        // PUT: api/StoreHolidays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreHoliday(int id, StoreHoliday storeHoliday)
        {
            if (id != storeHoliday.StoreHolidayId)
            {
                return BadRequest();
            }

            _context.Entry(storeHoliday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreHolidayExists(id))
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

        // POST: api/StoreHolidays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreHoliday>> PostStoreHoliday(StoreHoliday storeHoliday)
        {
            _context.StoreHolidays.Add(storeHoliday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreHoliday", new { id = storeHoliday.StoreHolidayId }, storeHoliday);
        }

        // DELETE: api/StoreHolidays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreHoliday(int id)
        {
            var storeHoliday = await _context.StoreHolidays.FindAsync(id);
            if (storeHoliday == null)
            {
                return NotFound();
            }

            _context.StoreHolidays.Remove(storeHoliday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreHolidayExists(int id)
        {
            return _context.StoreHolidays.Any(e => e.StoreHolidayId == id);
        }
    }
}
