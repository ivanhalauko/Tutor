using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface IPositionService
    {
        public int Add(Position position);

        public IEnumerable<Position> ReadAll();
    }
}
