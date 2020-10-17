using System;

namespace WebScraper.API.Data.Entities
{
   public class Price
   {
      public int ProductId { get; set; }
      public int OldPrice { get; set; }
      public int NewPrice { get; set; }

      public DateTime Date { get; set; }
   }
}