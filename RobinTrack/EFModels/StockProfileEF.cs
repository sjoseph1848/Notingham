using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinTrack.EFModels
{
    public class StockProfileEF
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }

        public decimal? Beta { get; set; }

        [JsonProperty(PropertyName ="volAvg")]
        public int VolumeAvg { get; set; }

        [JsonProperty(PropertyName ="mktCap")]
        public long MarketCap { get; set; }

        [JsonProperty(PropertyName = "lastDiv")]
        public decimal? LastDividend { get; set; }

        [JsonProperty(PropertyName = "range")]
        public string PriceRange { get; set; }
        public string CompanyName { get; set; }

        public string Exchange { get; set; }
        public string ExchangeShortName { get; set; }

        public string Industry { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string CEO { get; set; }
        public string Sector { get; set; }
        public string Country { get; set; }
        public string FullTimeEmployees { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string CompanyImage { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

    }
}
