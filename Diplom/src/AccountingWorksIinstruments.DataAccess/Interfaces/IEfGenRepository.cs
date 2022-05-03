using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorkInstruments.DataAccess.Interfaces
{
    public interface IEfGenRepository<T> where T : class
    {
        public Task<IQueryable<T>> ReadAllAsync();
    }
}