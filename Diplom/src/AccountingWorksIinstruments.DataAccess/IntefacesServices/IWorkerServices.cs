using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface IWorkerServices
    {
        public int Add(Worker worker);
        public IEnumerable<Worker> ReadAll();
        public Worker Update(Worker worker);
        public IQueryable<Worker> DeleteAll(Worker worker);
        public IEnumerable<Worker> GetById(int id);
    }
}
