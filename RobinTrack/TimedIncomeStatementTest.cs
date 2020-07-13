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

namespace RobinTrack
{
    public class TimedIncomeStatementTest
    {
        private readonly PopularityContext _popularityContext;
        private readonly HttpClient _httpClient;

        public TimedIncomeStatementTest(PopularityContext popularityContext, HttpClient httpClient)
        {
            _popularityContext = popularityContext;
            _httpClient = httpClient;
        }

        [FunctionName("TimedIncomeStatementTest")]
        public async Task Run([TimerTrigger("0 30 22 * * 1-5")] TimerInfo myTimer, ILogger log)
        {
            await AddIncomeStatementPassed();

        }
        
        public async Task AddIncomeStatementPassed()
        {

        }
    }
}
