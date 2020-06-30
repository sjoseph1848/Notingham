﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RobinTrack.EFModels
{
    public class PopularityStockVolumeEf
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float Close { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public string Symbol { get; set; }

        public int Volume { get; set; }

    }
}
