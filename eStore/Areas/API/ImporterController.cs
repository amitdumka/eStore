using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace eStore.Areas.API
{
   public class ImportDto
    {
        public string CommandMode { get; set; }
        public JObject JData { get; set; }
        public JArray JDataArray { get; set; }
  
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ImporterController : ControllerBase
    {
        // GET: api/Importer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Importer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Importer
        [HttpPost]
        public ActionResult<JsonResult> Post(JObject jsonData)
        {

            return  new JsonResult(jsonData); 
        }

        // PUT: api/Importer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Importer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
