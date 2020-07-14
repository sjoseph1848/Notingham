using Notingham.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Services
{
    public interface IInvestmentManagerStockRepository
    {
        void AddInvestmentManager(InvestmentManager investmentManager);
    }
}
