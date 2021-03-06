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
using System.Collections;
using RobinTrack.EFModels;
using System.Collections.Generic;

namespace RobinTrack
{
    public class TimedProfile
    {
        private readonly PopularityContext _popularityContext;
        private readonly HttpClient _httpClient;

        public TimedProfile(PopularityContext popularityContext, HttpClient httpClient)
        {
            _popularityContext = popularityContext;
            _httpClient = httpClient;
        }

        [FunctionName("TimedProfile")]
        public async Task Run([TimerTrigger("0 30 23 * * 1-5")] TimerInfo myTimer, ILogger log)
        {
            await AddProfile();

        }

        
        public async Task AddProfile()
        {
            var lstsymbols = _popularityContext.PopularStock.Select(s => s.Symbol).Distinct().ToList();
            var lstprofile = _popularityContext.StockProfile.ToList();
            var test = Environment.GetEnvironmentVariable("FinancialModellingApiKey");
            var num = 0;
            
            foreach (var symbol in lstsymbols)
            {

                using (var client = new HttpClient())
                {
                    var url = new Uri($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={test}");
                    var response = await client.GetAsync(url);
                    string json;
                    using (var content = response.Content)
                    {
                        json = await content.ReadAsStringAsync();

                    }
                    if (json.Length != 0)
                    {

                        IEnumerable<StockProfileEF> stocks = JsonConvert.DeserializeObject<StockProfileEF[]>(json);

                        foreach (var stock in stocks)
                        {
                            if(lstprofile.Where(s => s.Symbol == stock.Symbol).Count() == 0)
                            {
                                var stockProfile = new StockProfileEF();
                                stockProfile.Symbol = stock.Symbol;
                                stockProfile.Price = Math.Round(stock.Price, 2);
                                stockProfile.Beta = stock.Beta;
                                stockProfile.VolumeAvg = stock.VolumeAvg;
                                stockProfile.MarketCap = stock.MarketCap;
                                stockProfile.LastDividend = stock.LastDividend;
                                stockProfile.PriceRange = stock.PriceRange;
                                stockProfile.CompanyName = stock.CompanyName;
                                stockProfile.Exchange = stock.Exchange;
                                stockProfile.ExchangeShortName = stock.ExchangeShortName;
                                stockProfile.Industry = stock.Industry;
                                stockProfile.Website = stock.Website;
                                stockProfile.Description = stock.Description;
                                stockProfile.CEO = stock.CEO;
                                stockProfile.Sector = stock.Sector;
                                stockProfile.Country = stock.Country;
                                stockProfile.FullTimeEmployees = stock.FullTimeEmployees;
                                stockProfile.CompanyImage = stock.CompanyImage;

                                _popularityContext.StockProfile.Add(stockProfile);
                                await _popularityContext.SaveChangesAsync();
                            }              
                        }
                    }
                    }
                }

            }
    }
}
