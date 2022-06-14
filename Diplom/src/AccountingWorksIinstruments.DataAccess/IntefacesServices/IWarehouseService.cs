using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface IWarehouseService
    {
        public int Add(Warehouse warehouse);
        public IEnumerable<Warehouse> ReadAll();
        public Warehouse Update(Warehouse warehouse);
        public IQueryable<Warehouse> DeleteAll(Warehouse warehouse);
        public IEnumerable<Warehouse> GetById(int id);
    }
}
