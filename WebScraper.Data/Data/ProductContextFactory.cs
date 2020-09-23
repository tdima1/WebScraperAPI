using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WebScraper.Data.Data.Contexts;

namespace WebScraper.Data.Data
{
   public class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
   {
      public ProductContext CreateDbContext(string[] args)
      {
         var config = new ConfigurationBuilder()
        .SetBasePath("F:\\ASPNETProjs\\WebScraper.API\\WebScraper.API")
        .AddJsonFile("appsettings.json")
        .Build();

         return new ProductContext(new DbContextOptionsBuilder<ProductContext>().Options, config);
      }
   }
}
