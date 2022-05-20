using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface IToolService
    {
        public int Add(Tool tool);

        public IEnumerable<Tool> ReadAll();
        public int Update(Tool tool);
        public void DeleteAll(Tool tool);

    }
}
