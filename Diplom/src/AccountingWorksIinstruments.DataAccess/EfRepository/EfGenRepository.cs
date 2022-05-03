using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorksIinstruments.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWorkInstruments.DataAccess.EfRepository
{
    public class EfGenRepository<T> : IEfGenRepository<T>
        where T : class
    {
        public EfGenRepository(WiDbContext wiDbContext)
        {
            WiDbContext = wiDbContext;
        }

        public WiDbContext WiDbContext { get; set; }

        public async Task<IQueryable<T>> ReadAllAsync()
        {
           IQueryable<T> entities = WiDbContext.Set<T>().AsNoTracking();
            await WiDbContext.SaveChangesAsync();
            return entities;
        }
    }
}
