using AccountingWorksIinstruments.Database;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorkInstruments.DataAccess.Interfaces
{
    public interface IEfGenRepository<T> 
        where T : class
    {
        WiDbContext WiDbContext { get; set; }
        public Task<IQueryable<T>> ReadAllAsync();
    }
}