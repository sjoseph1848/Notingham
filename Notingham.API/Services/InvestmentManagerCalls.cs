using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Notingham.API.JsonModels;
using Notingham.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Notingham.API.Services
{
    public class InvestmentManagerCalls
    {
        private IHttpClientFactory _clientFactory;
        private IConfiguration _config;

        public InvestmentManagerCalls(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public async Task<InvestmentManagerJsonDto> GetInvestmentManager(string cik)
        {
            string uri = $"cik/{cik}?apikey={_config["FinsKey"]}";
            var client = _clientFactory.CreateClient(
                name: "FinskeyService");
            var request = new HttpRequestMessage(
                method: HttpMethod.Get, requestUri: uri);

            HttpResponseMessage response = await client.SendAsync(request);

            string jsonString = await response.Content.ReadAsStringAsync();

            InvestmentManagerJsonDto investmentManagerJsonDto = JsonConvert.DeserializeObject<InvestmentManagerJsonDto>(jsonString);

            return investmentManagerJsonDto;
        }
    }
}
