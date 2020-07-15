using Notingham.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Services
{
    public interface IInvestmentManagerRepository
    {
        void AddInvestmentManager(InvestmentManager investmentManager);
        bool Save();
    }
}
