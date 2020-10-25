using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Data.Data.Contexts;
using WebScraper.Data.Data.Entities;

namespace WebScraper.Data
{
   public class ProductRepository : IProductRepository
   {
      private readonly ProductContext _context;

      public ProductRepository(ProductContext context)
      {
         _context = context;
      }

      public void Add(Product product)
      {
         _context.Add(product);
         _context.SaveChanges();
      }

      public void Add(IEnumerable<Product> products)
      {
         foreach(Product p in products) {
            if(p.Name != null) {

               Product existingProduct = _context.Products.ToList().Where(prod => prod.Name == p.Name).FirstOrDefault();

               if(existingProduct == null) {
                  _context.Add(p);
                  _context.SaveChanges();
               } else {
                  p.Price.ProductId = existingProduct.Id;

                  if(!_context.Prices.ToList().Contains(p.Price)) {
                     _context.Prices.Add(p.Price);
                     _context.SaveChanges();
                  }
               }
            }
         }
         _context.SaveChanges();
      }

      public void Delete(int Id)
      {
         Product product = _context.Products.Find(Id);
         _context.Remove(product);
         _context.SaveChanges();
      }

      public void Edit(Product product)
      {
         _context.Entry(product).State = EntityState.Modified;
         _context.SaveChanges();
      }

      public Product FindById(int Id)
      {
         return _context.Products.Find(Id);
      }

      public IEnumerable<Product> GetProducts()
      {
         return from prod in _context.Products
                from price in _context.Prices
                where prod.Id == price.ProductId
                select new Product { Id = prod.Id, Name = prod.Name, Price = price };
      }

      public IEnumerable<Price> GetPriceHistoryForProductId(int productId)
      {
         return from price in _context.Prices
                where price.ProductId == productId
                select price;
      }
   }
}
