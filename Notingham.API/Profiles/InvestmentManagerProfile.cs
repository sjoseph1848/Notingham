using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notingham.API.Profiles
{
    public class InvestmentManagerProfile : Profile
    {
        public InvestmentManagerProfile()
        {
            CreateMap<Entities.InvestmentManager, Models.InvestmentManagerDto>();
            CreateMap<Models.InvestmentManagerForCreationDto, Entities.InvestmentManager>();

        }
    }
}
