using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebScraper.Data.Data.Entities
{
   public class Product
   {
      public Product()
      {
         Price = new Price();
      }

      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      public Price Price { get; set; }
   }
}
