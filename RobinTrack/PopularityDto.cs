using System;
using System.Collections.Generic;
using System.Text;

namespace RobinTrack
{
    public class PopularityDto
    {
        public int Start_Popularity { get; set; }
        public int End_Popularity { get; set; }
        public int  Popularity_Difference { get; set; }

        public string Symbol { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
