using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Data.Data.Entities;

namespace WebScraper.Data
{
   public interface IProductRepository
   {
      void Add(Product product);
      void Add(IEnumerable<Product> products);
      void Edit(Product product);
      void Delete(int Id);
      IEnumerable<Product> GetProducts();
      Product FindById(int Id);
   }
}
