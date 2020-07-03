using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RobinTrack.DTO;
using RobinTrack.EFModels;

namespace RobinTrack
{
    public class TimedStockVolume
    {

        private readonly PopularityContext _popularityContext;
        private readonly HttpClient _httpClient;
        public TimedStockVolume(PopularityContext popularityContext, HttpClient httpClient)
        {
            _popularityContext = popularityContext;
            _httpClient = httpClient;
        }

        [FunctionName("StockVolume")]
        public async Task Run([TimerTrigger("0 30 22 * * 1-5")] TimerInfo myTimer, ILogger log)
        //public async Task Run([TimerTrigger("0 0 13-21 * * 1-5")] TimerInfo myTimer, ILogger log)
        {
            await AddVolume();

        }

        public async Task AddVolume()
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
                        
                    }
                    if (json.Length != 0)
                    {
                        IEnumerable<StockVolumeDto> stocks = JsonConvert.DeserializeObject<StockVolumeDto[]>(json).Take(10);
                        foreach (var stock in stocks)
                        {

                            if(stock.Open < 15.0f)
                            {
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
}
