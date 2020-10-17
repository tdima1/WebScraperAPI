using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebScraper.API.Data.Entities
{
   public class Product
   {
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      public Price Price { get; set; }
   }
}
