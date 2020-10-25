using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Data.Data.Entities;

namespace WebScraper
{
   public class Scraper
   {
      public async Task<IEnumerable<Product>> Crawl()
      {
         List<Product> products = new List<Product>();

         for(int i = 1; i <= 10; i++) {

            //string url = $"https://www.emag.ro/desktop-pc/p{i}/c";
            string url = $"https://www.emag.ro/laptopuri/p{i}/c";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);
            //List<HtmlNode> divsCardSection = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("card-section-wrapper")).ToList();
            //List<HtmlNode> divsCardSectionBtm = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("card-section-btm")).ToList();

            try {
               for(int index = 1; index <= 60; index++) {
                  var titleNodes = htmlDocument.DocumentNode.SelectNodes($"//*[@id=\"card_grid\"]/div[{index}]/div/div/div[2]/h2/a");
                  var oldPriceNodes = htmlDocument.DocumentNode.SelectNodes($"//*[@id=\"card_grid\"]/div[{index}]/div/div/div[3]/div[2]/div/p[1]/s");
                  var newPriceNodes = htmlDocument.DocumentNode.SelectNodes($"//*[@id=\"card_grid\"]/div[{index}]/div/div/div[3]/div[2]/div/p[2]/text()");

                  Product prod = new Product();
                  Price price = new Price();
                  price.Date = DateTime.Now.Date;

                  if(titleNodes != null) {
                     prod.Name = titleNodes.FirstOrDefault().Attributes["title"].Value;
                  }
                  if(oldPriceNodes != null) {
                     price.OldPrice = Convert.ToInt32(oldPriceNodes.FirstOrDefault().GetDirectInnerText().Replace("&#46;", "").Trim());
                  }
                  if(newPriceNodes != null) {
                     price.NewPrice = Convert.ToInt32(newPriceNodes.FirstOrDefault().GetDirectInnerText().Replace("&#46;", "").Trim());
                  }

                  price.PriceDifferenceInValue = price.OldPrice - price.NewPrice;
                  price.PriceDifferenceInPercentage = (int)(((double)price.PriceDifferenceInValue / price.OldPrice) * 100);

                  prod.Price = price;
                  products.Add(prod);

               }
            } catch(Exception) {
               //throw e;
            }
         }

         return products;
      }
   }
}
