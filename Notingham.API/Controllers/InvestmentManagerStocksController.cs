using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notingham.API.Services;

namespace Notingham.API.Controllers
{
    [Route("api/investmentmanagers/{investmentmanagerId}/stocks")]
    [ApiController]
    public class InvestmentManagerStocksController : ControllerBase
    {
        private IInvestmentManagerRepository _investmentManagerRepository;
        private IHttpClientFactory _clientFactory;
        private IConfiguration _config;
        private readonly IMapper _mapper;
        public InvestmentManagerStocksController(IHttpClientFactory clientFactory, IConfiguration config, IMapper mapper, IInvestmentManagerRepository investmentManagerRepository)
        {
            _clientFactory = clientFactory;
            _config = config;
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _investmentManagerRepository = investmentManagerRepository ??
                throw new ArgumentNullException(nameof(investmentManagerRepository));
        }




    }
}
