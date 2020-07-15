﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Notingham.API.Models;
using Notingham.API.Services;

namespace Notingham.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentManagersController : ControllerBase
    {
        private IInvestmentManagerRepository _investmentManagerRepository;
        private IHttpClientFactory _clientFactory;
        private IConfiguration _config;
        private readonly IMapper _mapper;
        public InvestmentManagersController(IHttpClientFactory clientFactory, IConfiguration config, IMapper mapper, IInvestmentManagerRepository investmentManagerRepository)
        {
            _clientFactory = clientFactory;
            _config = config;
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _investmentManagerRepository = investmentManagerRepository ??
                throw new ArgumentNullException(nameof(investmentManagerRepository));
        }

        [HttpGet("", Name ="GetInvestmentManager")]

        [HttpPost]
        public async Task<ActionResult<InvestmentManagerDto>> CreateInvestmentManagerAsync(string investmentManager)
        {
            
            var investment = new InvestmentManagerCalls(_clientFactory, _config);

           var investmentManagerJson = await investment.GetInvestmentManager(investmentManager);

            var investmentManagerEntity = _mapper.Map<Entities.InvestmentManager>(investmentManagerJson);
            _investmentManagerRepository.AddInvestmentManager(investmentManagerEntity);
            _investmentManagerRepository.Save();

            var investmentManagerToReturn = _mapper.Map<InvestmentManagerDto>(investmentManagerEntity);
            return CreatedAtRoute("GetInvestmentManager",
                new { investmentManagerId = investmentManagerToReturn.Id },
                        investmentManagerToReturn);
            

        }
    }
}