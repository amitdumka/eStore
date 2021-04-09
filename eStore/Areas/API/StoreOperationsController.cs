using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.Shared.Models.Stores;
using eStore.DL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStore.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class StoreOperationsController : ControllerBase
    {
        private readonly eStoreDbContext db;
        public StoreOperationsController(eStoreDbContext con)
        {
            db = con;
        }
        // GET: api/<StoreOperationsController>
        [HttpGet]
        public async Task<IEnumerable<StoreDailyOperation>> GetAsync()
        {
            var open = await db.StoreOpens.Where(c => c.OpenningTime.Date.Year == DateTime.Today.Date.Year).OrderByDescending(c => c.OpenningTime).ToListAsync();
            var close = await db.StoreCloses.Where(c => c.ClosingDate.Date.Year == DateTime.Today.Date.Year).OrderByDescending(c => c.ClosingDate).ToListAsync();

            List<StoreDailyOperation> toList = new List<StoreDailyOperation>();
            foreach (var item in open)
            {
                StoreDailyOperation a = new StoreDailyOperation
                {
                    StoreDailyOperationId = item.StoreOpenId,
                    ClosingTime = item.OpenningTime.Date,
                    StoreCloseId = -1,
                    IsReadOnly = item.IsReadOnly,
                    OnDate = item.OpenningTime.Date,
                    OpenningTime = item.OpenningTime,
                    StoreId = item.StoreId,
                    Remarks = "OR: " + item.Remarks,
                    StoreOpenId = item.StoreOpenId,
                    UserId = item.UserId,
                };

                StoreClose c = close.Where(c => c.ClosingDate.Date == item.OpenningTime.Date).FirstOrDefault();
                if (c != null)
                {
                    a.ClosingTime = c.ClosingDate; a.Remarks = a.Remarks + "   \t:CR: " + c.Remarks;
                    a.StoreCloseId = c.StoreCloseId;
                }
               
                toList.Add(a);
            }


            return toList;
        }

        // GET api/<StoreOperationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDailyOperation>> GetAsync(int id)
        {
            var open = await db.StoreOpens.FindAsync(id);
            if (open != null)
            {
                StoreDailyOperation sdo = new StoreDailyOperation
                {
                    IsReadOnly = open.IsReadOnly,
                    OnDate = open.OpenningTime.Date,
                    OpenningTime = open.OpenningTime,
                    StoreId = open.StoreId,
                    Remarks = "OR: " + open.Remarks,
                    StoreOpenId = open.StoreOpenId,
                    UserId = open.UserId,
                };
                var close = await db.StoreCloses.Where(c => c.ClosingDate.Date == open.OpenningTime.Date).FirstOrDefaultAsync();

                if (close != null)
                {
                    sdo.ClosingTime = close.ClosingDate; sdo.Remarks = sdo.Remarks + "   \t:CR: " + close.Remarks;
                    sdo.StoreCloseId = close.StoreCloseId;
                }
                else
                {
                    sdo.ClosingTime = open.OpenningTime.Date;
                    sdo.StoreCloseId = -1;
                }
                return sdo;

            }
            else
            {
                return NotFound();
            }


        }

        // POST api/<StoreOperationsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StoreOperationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreOperationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
