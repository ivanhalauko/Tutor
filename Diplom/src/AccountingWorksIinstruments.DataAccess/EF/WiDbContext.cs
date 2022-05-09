using AccountingWorkInstruments.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingWorksIinstruments.Database
{
    public class WiDbContext : DbContext
    {
        private readonly string _connectionString;

        public WiDbContext()
        {
        }

        public WiDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        //public DbSet<Position> Position { get; set; }
        //protected override void OnConfigurings(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(_connectionString);
        //    }
        //}

        //public DbSet<Tool> Tool { get; set; }
        //protected override void OnConfigurings(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(_connectionString);
        //    }
        //}
    }
}
