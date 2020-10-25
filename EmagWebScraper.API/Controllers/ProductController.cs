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
      private readonly IProductRepository _productRepository;

      public ProductController(IProductRepository productRepository)
      {
         _productRepository = productRepository;
      }

      // GET: api/Product
      [HttpGet]
      public IActionResult Get()
      {
         var products = _productRepository.GetProducts();

         return Ok(products);
      }

      // GET: api/Product/5
      [HttpGet("{id}", Name = "Get")]
      public IActionResult Get(int id)
      {
         var prices = _productRepository.GetPriceHistoryForProductId(id);

         return Ok(prices);
      }

      // POST: api/Product
      /// <summary>
      /// Should crawl for new entries in the database
      /// unless the crawler has been executed today.
      /// </summary>
      /// <param name="date"></param>
      [HttpPost]
      public void Post([FromBody] string date)
      {
         IEnumerable<Product> products = _scraper.Crawl().Result;
         _productRepository.Add(products);
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
