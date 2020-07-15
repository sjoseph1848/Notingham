using Notingham.API.DbContexts;
using Notingham.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Services
{
    public class InvestmentManagerRepository : IInvestmentManagerRepository
    {
        private readonly NotinghamContext _context;

        public InvestmentManagerRepository(NotinghamContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddInvestmentManager(InvestmentManager investmentManager)
        {
           if (investmentManager == null)
            {
                throw new ArgumentNullException(nameof(investmentManager));
            }
            // the repository fills the id (instead of using identity columns)
            investmentManager.Id = Guid.NewGuid();

            foreach (var stock in investmentManager.investmentManagerStocks)
            {
                stock.Id = Guid.NewGuid();
            }

            _context.InvestmentManagers.Add(investmentManager);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
