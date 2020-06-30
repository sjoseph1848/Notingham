using System;
using System.Collections.Generic;
using System.Text;

namespace RobinTrack.DTO
{
    public class StockVolumeDto
    {
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float Low { get; set; }
        public float High { get; set; }
        public float Close { get; set; }
        public int Volume { get; set; }
    }
}
