﻿using AccountingWorkInstruments.DataAccess.Models;
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
            CreateMap<Location, LocationViewModel>();
            CreateMap<Tool, ToolViewModel>();
            CreateMap<Worker, WorkerViewModel>();

            //WEB to DAL
            CreateMap<PositionViewModel, Position>();
            CreateMap<LocationViewModel, Location>();
            CreateMap<ToolViewModel, Tool>();
            CreateMap<WorkerViewModel, Worker>();
        }
    }
}
