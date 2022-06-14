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
        public DbSet<Position> Position { get; set; }
        public DbSet<Tool> Tool { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<SubmissionWriteTool> SubmissionWriteTool { get; set; }
        public DbSet<SubmissionWriteOff> SubmissionWriteOff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
