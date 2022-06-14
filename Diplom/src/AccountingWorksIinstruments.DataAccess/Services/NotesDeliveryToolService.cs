using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class NotesDeliveryToolService : INotesDeliveryToolService
    {
        private readonly IEfGenRepository<NotesDeliveryTool> _notesDeliveryToolRepository;
        public NotesDeliveryToolService(IEfGenRepository<NotesDeliveryTool> notesDeliveryToolRepository)
        {
            _notesDeliveryToolRepository = notesDeliveryToolRepository;
        }
        public int Add(NotesDeliveryTool notesDeliveryTool)
        {
            var idNewNotesDeliveryTool = _notesDeliveryToolRepository.AddAsync(notesDeliveryTool).Result;
            return idNewNotesDeliveryTool;
        }

        public IEnumerable<NotesDeliveryTool> ReadAll()
        {
            var notesDeliveryTool = _notesDeliveryToolRepository.ReadAllAsync().Result;
            return notesDeliveryTool;
        }

        public NotesDeliveryTool Update(NotesDeliveryTool notesDeliveryTool)
        {
            var updateNotesDeliveryTool = _notesDeliveryToolRepository.UpdateAsync(notesDeliveryTool).Result;

            return updateNotesDeliveryTool;
        }

        public IQueryable<NotesDeliveryTool> DeleteAll(NotesDeliveryTool notesDeliveryTool)
        {
            _notesDeliveryToolRepository.DeleteAsync(notesDeliveryTool).Wait();
            var deleteNotesDeliveryTool = _notesDeliveryToolRepository.ReadAllAsync().Result;
            return deleteNotesDeliveryTool;
        }
        public IEnumerable<NotesDeliveryTool> GetById(int id)
        {
            var notesDeliveryTool = _notesDeliveryToolRepository.GetByIdAsync(id).Result;
            return notesDeliveryTool;
        }
    }
}
