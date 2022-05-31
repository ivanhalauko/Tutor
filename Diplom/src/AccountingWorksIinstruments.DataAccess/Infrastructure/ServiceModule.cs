using AccountingWorkInstruments.DataAccess.EfRepository;
using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorkInstruments.DataAccess.Services;
using AccountingWorksIinstruments.Database;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Infrastructure
{
    public class ServiceModule : Module
    {
        private readonly string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PositionSevice>().As<IPositionService>();

            builder.RegisterType<LocationService>().As<ILocationServices>();
            builder.RegisterType<ToolService>().As<IToolService>();

            builder.RegisterType<WiDbContext>().As<WiDbContext>().WithParameter("connectionString", _connectionString);

            builder.RegisterType<EfGenRepository<Position>>().As<IEfGenRepository<Position>>();

            builder.RegisterType<EfGenRepository<Location>>().As<IEfGenRepository<Location>>();
            builder.RegisterType<EfGenRepository<Tool>>().As<IEfGenRepository<Tool>>();
        }
    }
}
