using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface IPositionService
    {
        public int Add(Position position);

        public IEnumerable<Position> ReadAll();
        public Position Update(Position position);
        public IQueryable<Position> DeleteAll(Position position);

        public IEnumerable<Position> GetById(int id);
    }
}
