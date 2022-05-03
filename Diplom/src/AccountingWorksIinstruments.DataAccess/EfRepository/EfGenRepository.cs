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
        where T : class, IEntity
    {
        public EfGenRepository(WiDbContext wiDbContext)
        {
            WiDbContext = wiDbContext;
        }

        public WiDbContext WiDbContext { get; set; }

        public async Task<IQueryable<T>> ReadAllAsync()
        {
          var entities = WiDbContext.Set<T>().AsNoTracking();
            await WiDbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<IQueryable<T>> GetByIdAsync(int id)
        {
            var entities = WiDbContext.Set<T>().Where(x => x.Id == id).AsNoTracking();
            await WiDbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<int> AddAsync(T entity)
        {
            var entit = WiDbContext.Set<T>().AddAsync(entity).Result;
            await WiDbContext.SaveChangesAsync();
            return entit.Entity.Id;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            WiDbContext.Set<T>().Update(entity);
            await WiDbContext.SaveChangesAsync();
            var result = await WiDbContext.FindAsync<T>(entity.Id);
            return result;
        }

        public async Task DeleteAsync(T entity)
        {
            WiDbContext.Set<T>().Remove(entity);
            await WiDbContext.SaveChangesAsync();
        }
    }
}
