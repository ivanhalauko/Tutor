using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingWorksIinstruments.Database
{
    public class WiDbContext
    {
        private readonly string _connectionString;

        public WiDbContext()
        {
        }

        public WiDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
