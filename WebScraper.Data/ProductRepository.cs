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
               _context.Add(p);
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
         return from p in _context.Products
                orderby p.Name
                select p;
      }
   }
}
