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

         for(int i = 1; i <= 10; i++) {

            string url = $"https://www.emag.ro/desktop-pc/p{i}/c";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);
            List<HtmlNode> divsCardSection = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("card-section-wrapper")).ToList();
            //List<HtmlNode> divsCardSectionBtm = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("card-section-btm")).ToList();

            try {
               for(int index = 1; index <= 60; index++) {
                  var titleNodes = htmlDocument.DocumentNode.SelectNodes($"//*[@id=\"card_grid\"]/div[{index}]/div/div/div[2]/h2/a");
                  var oldPriceNodes = htmlDocument.DocumentNode.SelectNodes($"//*[@id=\"card_grid\"]/div[{index}]/div/div/div[3]/div[2]/div/p[1]/s");
                  var newPriceNodes = htmlDocument.DocumentNode.SelectNodes($"//*[@id=\"card_grid\"]/div[{index}]/div/div/div[3]/div[2]/div/p[2]/text()");

                  string oldPrice = "", newPrice = "", name = "";

                  if (titleNodes != null) {
                     name = titleNodes.FirstOrDefault().Attributes["title"].Value;
                  }
                  if (oldPriceNodes != null) {
                     oldPrice = oldPriceNodes.FirstOrDefault().GetDirectInnerText().Replace("&#46;", ".");
                  }
                  if(newPriceNodes != null) {
                     newPrice = newPriceNodes.FirstOrDefault().GetDirectInnerText().Replace("&#46;", ".");
                  }
               }
            } catch(Exception e) {
               //throw e;
            }
         }

      }
   }
}
