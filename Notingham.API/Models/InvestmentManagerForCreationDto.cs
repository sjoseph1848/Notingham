using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Models
{
    public class InvestmentManagerForCreationDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Cik { get; set; }

        public string Name { get; set; }

    }
}
