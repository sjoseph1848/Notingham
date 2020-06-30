using System;
using System.Collections.Generic;
using System.Text;

namespace RobinTrack
{
    public class PopularityEf
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public int StartPopularity { get; set; }
        public int EndPopularity { get; set; }

        public int PopularityDifference { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

    }
  
}
