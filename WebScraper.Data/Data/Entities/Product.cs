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
         Prices = new List<Price>();
      }

      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      public List<Price> Prices { get; set; }
   }
}
