using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HtmlAgilityPack;
using ScrapySharp.Network;
using System.Text.RegularExpressions;

namespace RobinTrack
{
   
    public class IncomeStatementFootNoteParser
    {
        static ScrapingBrowser _scrapingBrowser = new ScrapingBrowser();

        [FunctionName("IncomeStatementFootNoteParser")]
        public void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string pattern = @"[^A-Za-z0-9]+";
            
            var url = "https://www.sec.gov/Archives/edgar/data/1318605/000156459020004475/tsla-10k_20191231.htm";
            //var url = "https://www.sec.gov/Archives/edgar/data/320193/000032019319000119/a10-k20199282019.htm";
            var htmlNode = GetHtml(url);
            var tableBlobs = htmlNode.OwnerDocument.DocumentNode.SelectNodes("//html/body/div/table");

            if(tableBlobs == null)
            {
                var spanBlobs = htmlNode.OwnerDocument.DocumentNode.SelectNodes("//html/body/div/span");
                foreach (var blob in spanBlobs)
                {
                    var clean = Regex.Replace(blob.InnerText, pattern, " ");
                    Console.WriteLine(clean);
                }
            } else
            {
                foreach(var blob in tableBlobs)
                {
                    var clean = Regex.Replace(blob.InnerText, pattern, " ");
                    Console.WriteLine(clean); 
                }

            }

        }

        static HtmlNode GetHtml(string url)
        {
            WebPage webpage = _scrapingBrowser.NavigateToPage(new Uri(url));
            return webpage.Html;
        }
    }
}
