using System;
using System.ComponentModel.DataAnnotations;

namespace WebScraper.API.Data.Entities
{
   public class Product
   {
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      public int OldPrice { get; set; }
      public int NewPrice { get; set; }

      public DateTime Date { get; set; }
   }
}
