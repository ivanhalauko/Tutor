using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //DAL to WEB
            CreateMap<Position, PositionViewModel>();

            //WEB to DAL
            CreateMap<PositionViewModel, Position>();
        }
    }
}
