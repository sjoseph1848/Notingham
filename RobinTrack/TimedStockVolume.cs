using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace RobinTrack
{
    public static class TimedStockVolume
    {
        //[FunctionName("TimedStockVolume")]
        //public static void Run([TimerTrigger("0 0 14-22 * 1-5")]TimerInfo myTimer, ILogger log)
        //{
        //    var test = Environment.GetEnvironmentVariable("VolumeKey");
        //    var client = new RestClient($"https://robintrack20200630195915.azurewebsites.net/api/GetStockVolume?code={test}");
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = client.Execute(request);
           
        //}
    }
}
