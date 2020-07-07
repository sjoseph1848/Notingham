using Microsoft.EntityFrameworkCore;
using RobinTrack.EFModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinTrack
{
    public class PopularityContext : DbContext
    {
        public PopularityContext(DbContextOptions<PopularityContext> options) : base(options)
        {

        }

        public PopularityContext()
        {

        }

        public DbSet<PopularityEf> Popularity { get; set; }
        public DbSet<PopularityStockVolumeEf> PopularStock { get; set; }
        public DbSet<StockProfileEF> StockProfile { get; set; }
    }
}
