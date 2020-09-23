using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.API.Data.Entities;

namespace WebScraper.Data.Data.Contexts
{
   public class ProductContext : DbContext
   {
      public DbSet<Product> Products { get; set; }

      public ProductContext(DbContextOptions options) : base(options)
      {

      }
   }
}
