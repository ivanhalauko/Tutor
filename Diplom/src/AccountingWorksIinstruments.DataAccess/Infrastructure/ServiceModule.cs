using AccountingWorkInstruments.DataAccess.IntefacesServices;
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

            builder.RegisterType<WiDbContext>().As<WiDbContext>().WithParameter("connectionString", _connectionString);
        }
    }
}
