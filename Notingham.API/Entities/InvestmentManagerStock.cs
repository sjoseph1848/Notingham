using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Entities
{
    public class InvestmentManagerStock
    {
        [Key]
        public Guid Id { get; set; }

        public string Cik { get; set; }

        public DateTime PeriodDate { get; set; }
        public string TickerCusip { get; set; }
        public string NameOfIssuer { get; set; }

        public int Shares { get; set; }

        public string TitleOfClass { get; set; }
        public int ValueOfShares { get; set; }

        public string LinkToMain { get; set; }
        public string LinkToFinal { get; set; }

        [ForeignKey("InvestmentManagerId")]

        public InvestmentManager InvestmentManager { get; set; }

        public Guid InvestmentManagerId { get; set; }
    }
}
