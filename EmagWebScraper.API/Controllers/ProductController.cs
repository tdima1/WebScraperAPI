using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraper;
using WebScraper.Data;
using WebScraper.Data.Data.Entities;

namespace EmagWebScraper.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ProductController : ControllerBase
   {
      Scraper _scraper = new Scraper();
      private readonly IProductRepository productRepository;

      public ProductController(IProductRepository _productRepository)
      {
         productRepository = _productRepository;
      }

      // GET: api/Product
      [HttpGet]
      public async Task<IActionResult> Get()
      {
         IEnumerable<Product> products = await _scraper.Crawl();
         return Ok("we did it bois");
      }

      // GET: api/Product/5
      [HttpGet("{id}", Name = "Get")]
      public string Get(int id)
      {
         return "value";
      }

      // POST: api/Product
      [HttpPost]
      public void Post([FromBody] string value)
      {
      }

      // PUT: api/Product/5
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
