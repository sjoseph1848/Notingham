using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

namespace RobinTrack
{
    public class PopularityTracker
    {
        private const string Route = "popularity";
        private readonly PopularityContext _popularityContext;

        public PopularityTracker(PopularityContext popularityContext)
        {
            _popularityContext = popularityContext;
        }

        [FunctionName("AddPopularity")]
        public async Task<IActionResult> AddPopularity(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = Route)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting the popularity info");

            using (var client = new HttpClient())
            {
                var url = new Uri("https://robintrack.net/api/largest_popularity_changes?hours_ago=72&limit=1&percentage=false&min_popularity=50&start_index=0");
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                IEnumerable<PopularityDto> stocks = JsonConvert.DeserializeObject<PopularityDto[]>(json);
                foreach (var stock in stocks)
                {
                    var popularStock = new PopularityEf();
                   popularStock.StartPopularity = stock.Start_Popularity;
                    popularStock.EndPopularity = stock.End_Popularity;
                    popularStock.PopularityDifference = stock.Popularity_Difference;
                    popularStock.Name = stock.Name;
                    popularStock.Symbol = stock.Symbol;
                    popularStock.CreatedTime = DateTime.Now;

                    GetStockInfo(popularStock.Symbol);
                    _popularityContext.Popularity.Add(popularStock);
                    await _popularityContext.SaveChangesAsync();
                }
               
                return new OkObjectResult(stocks);
            }
           
        }


        public static void GetStockInfo(string symbol)
        {

        }
    }
}
