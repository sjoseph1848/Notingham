using Microsoft.EntityFrameworkCore;
using Notingham.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.DbContexts
{
    public class NotinghamContext : DbContext
    {
        public NotinghamContext(DbContextOptions<NotinghamContext> options)
            : base(options)
        {

        }

        public DbSet<InvestmentManager> InvestmentManagers { get; set; }

        public DbSet<InvestmentManagerStock> InvestmentManagerStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvestmentManager>().ToTable("InvestmentManagers");
            modelBuilder.Entity<InvestmentManagerStock>().ToTable("InvestmentManagerStocks");
        }
    }
}
