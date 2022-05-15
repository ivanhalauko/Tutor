using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingWorksIinstruments.Web.Interfaces;
using Autofac;

namespace AccountingWorksIinstruments.Web.Infrastructure
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperConfig>().As<IMapperConfig>().WithParameter("profile", new MapperProfile());
        }
    }
}
