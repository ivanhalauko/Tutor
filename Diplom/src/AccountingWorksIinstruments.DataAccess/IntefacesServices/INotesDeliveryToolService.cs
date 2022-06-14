using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface INotesDeliveryToolService
    {
        public int Add(NotesDeliveryTool notesDeliveryTool);
        public IEnumerable<NotesDeliveryTool> ReadAll();
        public NotesDeliveryTool Update(NotesDeliveryTool notesDeliveryTool);
        public IQueryable<NotesDeliveryTool> DeleteAll(NotesDeliveryTool notesDeliveryTool);
        public IEnumerable<NotesDeliveryTool> GetById(int id);
    }
}
