using AccountingWorksIinstruments.Database;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorkInstruments.DataAccess.Interfaces
{
    public interface IEfGenRepository<T> 
        where T : class, IEntity
    {
        WiDbContext WiDbContext { get; set; }
        public Task<IQueryable<T>> ReadAllAsync();

        Task<int> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IQueryable<T>> GetByIdAsync(int id);

        Task<T> UpdateAsync(T entity);
    }
}