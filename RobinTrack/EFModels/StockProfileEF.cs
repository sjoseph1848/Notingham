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

        public decimal Beta { get; set; }

        public long VolumeAvg { get; set; }

        public long MarketCap { get; set; }
        public decimal LastDividend { get; set; }
        public string Range { get; set; }
        public decimal Changes { get; set; }
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
        public string Phone { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }

        public decimal DcDiff { get; set; }
        public string Image { get; set; }

    }
}
