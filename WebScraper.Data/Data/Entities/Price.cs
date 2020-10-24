using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Data.Data.Entities
{
   public class Price
   {
      public int PriceId { get; set; }
      public int OldPrice { get; set; }
      public int NewPrice { get; set; }
      public int ProductId { get; set; }
      public DateTime Date { get; set; }
   }
}
