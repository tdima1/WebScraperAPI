using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.API.Data.Entities;

namespace WebScraper.Data.Data
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
