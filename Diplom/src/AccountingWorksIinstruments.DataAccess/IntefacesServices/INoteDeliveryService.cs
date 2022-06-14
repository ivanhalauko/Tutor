using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface INoteDeliveryService
    {
        public int Add(NoteDelivery noteDelivery);
        public IEnumerable<NoteDelivery> ReadAll();
        public NoteDelivery Update(NoteDelivery noteDelivery);
        public IQueryable<NoteDelivery> DeleteAll(NoteDelivery noteDelivery);
        public IEnumerable<NoteDelivery> GetById(int id);
    }
}
