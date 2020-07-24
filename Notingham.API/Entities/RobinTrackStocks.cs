using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Entities
{
    public class RobinTrackStocks
    {
        [Key]
        public Guid Id { get; set; }

        public int StartPopularityVolume { get; set; }
        public int EndPopularityVolume { get; set; }
        public int PopularityChange { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
