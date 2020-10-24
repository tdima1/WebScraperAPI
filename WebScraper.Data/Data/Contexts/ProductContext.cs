using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Data.Data.Entities;

namespace WebScraper.Data.Data.Contexts
{
   public class ProductContext : DbContext
   {
      private readonly IConfiguration _config;
      public DbSet<Product> Products { get; set; }

      public ProductContext(DbContextOptions options, IConfiguration config) : base(options)
      {
         _config = config;
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
      }

      protected override void OnModelCreating(ModelBuilder bldr)
      {
         bldr.Entity<Product>()
            .HasData(new {
               Id = 1,
               Name = "Default Entity",
               OldPrice = 0,
               NewPrice = 0,
               Date = DateTime.MinValue
            });
      }

   }
}
