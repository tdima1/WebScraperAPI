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
         List<HtmlNode> divsCardSectionMid = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("card-section-mid")).ToList();
         List<HtmlNode> divsCardSectionBtm = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("card-section-btm")).ToList();
         
         try {
            foreach(var div in divsCardSectionMid) {
               var name = div.Descendants("a").FirstOrDefault().ChildAttributes("title").FirstOrDefault().Value;
               var link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
            }

            foreach(var div in divsCardSectionBtm) {
               var oldPrice = div.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("pricing-old")).FirstOrDefault();//.FirstChild.GetDirectInnerText();
               string newPrice = div.Descendants("p").Where(node => node.GetAttributeValue("class", "").Contains("new-price")).FirstOrDefault().FirstChild.GetDirectInnerText();
               var atr = div.Attributes;
            }
         } catch(Exception e) {

            throw e;
         }


      }
   }
}
