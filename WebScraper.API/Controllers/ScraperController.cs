using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebScraper.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ScraperController : ControllerBase
   {
      WebScraper scraper = new WebScraper();

      // GET: api/Scraper
      [HttpGet]
      public async Task<IEnumerable<string>> Get()
      {
         //await scraper.Crawl();
         var a = Assembly.GetExecutingAssembly().GetName().Name;
         return new string[] { "value1", "value2" };
      }

      // GET: api/Scraper/5
      [HttpGet("{id}", Name = "Get")]
      public string Get(int id)
      {
         return "value";
      }

      // POST: api/Scraper
      [HttpPost]
      public void Post([FromBody] string value)
      {
         
      }

      // PUT: api/Scraper/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
      }

      // DELETE: api/ApiWithActions/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   }
}
