using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Build.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RobinTrack.DTO;
using RobinTrack.EFModels;

namespace RobinTrack
{
   
    
    public class TimeTest
    {

        [FunctionName("TimeTest")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var client = new RestClient("http://localhost:7071/api/popularity");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }
    }
}
