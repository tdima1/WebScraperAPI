using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
   public class WebScraper
   {
      public async Task Crawl()
      {
         var url = "https://www.emag.ro/televizoare/brand/wellington/c?ref=bc";
         var httpClient = new HttpClient();
         var html = await httpClient.GetStringAsync(url);
         var htmlDocument = new HtmlDocument();

         htmlDocument.LoadHtml(html);
         var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("card-section-wrapper")).ToList();

      }
   }
}
