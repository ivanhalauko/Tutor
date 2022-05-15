using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Interfaces
{
    public interface IMapperConfig
    {
        IMapper Mapper { get; }
    }
}
