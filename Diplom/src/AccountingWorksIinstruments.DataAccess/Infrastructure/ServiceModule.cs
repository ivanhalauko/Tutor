using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Infrastructure
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PositionSevice>().As<IPositionService>();
        }
    }
}
