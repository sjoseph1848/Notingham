using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notingham.API.Models;

namespace Notingham.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentManagersController : ControllerBase
    {

        [HttpPost]
        public ActionResult<InvestmentManagerDto> CreateInvestmentManager(InvestmentManagerForCreationDto investmentManager)
        {
            var investment = 
        }
    }
}
