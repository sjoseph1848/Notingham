using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Entities
{
    public class InvestmentManager
    {
        [Key]
        public Guid Id { get; set; }

        public string Cik { get; set; }

        public string name { get; set; }

        public ICollection<InvestmentManagerStock> investmentManagerStocks { get; set; } = new List<InvestmentManagerStock>();
    }
}
