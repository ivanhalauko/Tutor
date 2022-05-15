using AccountingWorksIinstruments.Web.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Infrastructure
{
    public class MapperConfig : IMapperConfig
    {
        public MapperConfig(Profile profile)
        {
            Mapper = new MapperConfiguration(m => m.AddProfile(profile)).CreateMapper();
        }
        public IMapper Mapper
        {
            get;
            private set;
        }
    }
}
