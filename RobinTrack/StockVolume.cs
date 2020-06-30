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
using System.Linq;
using RobinTrack.DTO;
using RobinTrack.EFModels;
using System.Collections.Generic;

namespace RobinTrack
{
    public class StockVolume
    {
        private const string Route = "GetStockVolume";
        private readonly PopularityContext _popularityContext;
        private readonly HttpClient _httpClient;
        public StockVolume(PopularityContext popularityContext, HttpClient httpClient)
        {
            _popularityContext = popularityContext;
            _httpClient = httpClient;
        }

        [FunctionName("GetStockVolume")]
        public async Task GetStockVolume(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = Route)] HttpRequest req,
            ILogger log)
        {
            var lstsymbols = _popularityContext.Popularity.Select(s => s.Symbol).Distinct().ToList();
            var test = Environment.GetEnvironmentVariable("FinancialModellingApiKey");
            var num = 0;
            foreach (var symbol in lstsymbols)
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"https://financialmodelingprep.com/api/v3/historical-chart/1hour/{symbol}?apikey={test}");
                    var response = await client.GetAsync(url);
                    string json;
                    using (var content = response.Content)
                    {
                        json = await content.ReadAsStringAsync();
                        log.LogInformation($"Here is the json: {json}");
                    }
                    if (json.Length != 0)
                    {
                        IEnumerable<StockVolumeDto> stocks = JsonConvert.DeserializeObject<StockVolumeDto[]>(json).Take(10);
                        foreach (var stock in stocks)
                        {
                            
                            log.LogInformation($"Here is the stocks: {stock}");
                            var popularStockVolume = new PopularityStockVolumeEf();
                           
                            popularStockVolume.Date = stock.Date;
                            popularStockVolume.Open = stock.Open;
                            popularStockVolume.Close = stock.Close;
                            popularStockVolume.High = stock.High;
                            popularStockVolume.Low = stock.Low;
                            popularStockVolume.Symbol = symbol;
                            popularStockVolume.Volume = stock.Volume;
                            _popularityContext.PopularStock.Add(popularStockVolume);
                            await _popularityContext.SaveChangesAsync();

                        }
                    }
                }
            }

        }
    }
}
