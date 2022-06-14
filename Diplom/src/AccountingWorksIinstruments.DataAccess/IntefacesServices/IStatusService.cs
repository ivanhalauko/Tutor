using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface IStatusService
    {
        public int Add(Status status);
        public IEnumerable<Status> ReadAll();
        public Status Update(Status status);
        public IQueryable<Status> DeleteAll(Status status);
        public IEnumerable<Status> GetById(int id);
    }
}
