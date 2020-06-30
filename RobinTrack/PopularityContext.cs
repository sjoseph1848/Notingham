using Microsoft.EntityFrameworkCore;
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

        public DbSet<PopularityEf> Popularity { get; set; }
    }
}
