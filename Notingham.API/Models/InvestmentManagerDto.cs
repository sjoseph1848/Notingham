using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Models
{
    public class InvestmentManagerDto
    {
        public Guid Id { get; set; }
        
        public string Cik { get; set; }

        public string Name { get; set; }
    }
}
