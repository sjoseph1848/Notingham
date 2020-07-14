using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RobinTrack.DTO;
using RobinTrack.EFModels;

namespace RobinTrack
{
    public class TimedPopularity
    {

        private readonly PopularityContext _popularityContext;
        private readonly HttpClient _httpClient;
        public TimedPopularity(PopularityContext popularityContext, HttpClient httpClient)
        {
            _popularityContext = popularityContext;
            _httpClient = httpClient;
        }

        [FunctionName("StockPopularity")]
        public async Task Run([TimerTrigger("0 0 14-21 * * 1-5")] TimerInfo myTimer, ILogger log)
        {
            await AddPopularity();

        }

        public async Task AddPopularity()
        {
            List<string> symbols = new List<string>();
            using (var client = new HttpClient())
            {
                var url = new Uri("https://robintrack.net/api/largest_popularity_changes?hours_ago=72&limit=50&percentage=false&min_popularity=50&start_index=0");
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

                    _popularityContext.Popularity.Add(popularStock);
                    await _popularityContext.SaveChangesAsync();
                    symbols.Add(popularStock.Symbol);

                }
            }
        }
    }
}
