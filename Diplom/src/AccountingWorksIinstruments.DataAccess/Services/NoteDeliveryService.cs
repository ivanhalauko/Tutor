using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class NoteDeliveryService : INoteDeliveryService
    {
        private readonly IEfGenRepository<NoteDelivery> _noteDeliveryRepository;
        public NoteDeliveryService(IEfGenRepository<NoteDelivery> noteDeliveryRepository)
        {
            _noteDeliveryRepository = noteDeliveryRepository;
        }
        public int Add(NoteDelivery noteDelivery)
        {
            var idNewNoteDelivery = _noteDeliveryRepository.AddAsync(noteDelivery).Result;
            return idNewNoteDelivery;
        }

        public IEnumerable<NoteDelivery> ReadAll()
        {
            var noteDelivery = _noteDeliveryRepository.ReadAllAsync().Result;
            return noteDelivery;
        }

        public NoteDelivery Update(NoteDelivery noteDelivery)
        {
            var updateNoteDelivery = _noteDeliveryRepository.UpdateAsync(noteDelivery).Result;

            return updateNoteDelivery;
        }

        public IQueryable<NoteDelivery> DeleteAll(NoteDelivery noteDelivery)
        {
            _noteDeliveryRepository.DeleteAsync(noteDelivery).Wait();
            var deleteNoteDelivery = _noteDeliveryRepository.ReadAllAsync().Result;
            return deleteNoteDelivery;
        }
        public IEnumerable<NoteDelivery> GetById(int id)
        {
            var noteDelivery = _noteDeliveryRepository.GetByIdAsync(id).Result;
            return noteDelivery;
        }
    }
}
