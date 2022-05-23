using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface ILocationServices
    {

        public int Add(Location location);
        public IEnumerable<Location> ReadAll();
        public Location Update(Location location);
        public IQueryable<Location> DeleteAll(Location location);
        public IEnumerable<Location> GetById(int id);
    }
}
