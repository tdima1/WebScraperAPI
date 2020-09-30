using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraper.API.Data.Entities;
using WebScraper.Data.Data;

namespace WebScraper.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ScraperController : ControllerBase
   {
      WebScraper scraper = new WebScraper();
      IProductRepository _repository;

      public ScraperController(IProductRepository productRepository)
      {
         this._repository = productRepository;
      }

      // GET: api/Scraper
      [HttpGet]
      public async Task<IEnumerable<string>> Get()
      {
         //should get data from db.
         IEnumerable<Product> products = await scraper.Crawl();
         _repository.Add(products);
         //var a = Assembly.GetExecutingAssembly().GetName().Name;
         return new string[] { "value1", "value2" };
      }

      // GET: api/Scraper/5
      [HttpGet("{id}", Name = "Get")]
      public string Get(int id)
      {
         //should get data from 1 single product
         return "value";
      }

      // POST: api/Scraper
      [HttpPost]
      public async Task Post([FromBody] string url)
      {
         //var x = await scraper.Crawl(url);
      }

      // PUT: api/Scraper/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
         //no plans yet
      }

      // DELETE: api/ApiWithActions/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
         //delete some stuff(admin)
      }
   }
}
