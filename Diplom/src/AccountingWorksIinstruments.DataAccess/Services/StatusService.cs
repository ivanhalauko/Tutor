using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class StatusService : IStatusService
    {
        private readonly IEfGenRepository<Status> _statusRepository;
        public StatusService(IEfGenRepository<Status> statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public int Add(Status status)
        {
            var idNewStatus = _statusRepository.AddAsync(status).Result;
            return idNewStatus;
        }

        public IEnumerable<Status> ReadAll()
        {
            var status = _statusRepository.ReadAllAsync().Result;
            return status;
        }

        public Status Update(Status status)
        {
            var updateStatus = _statusRepository.UpdateAsync(status).Result;

            return updateStatus;
        }

        public IQueryable<Status> DeleteAll(Status status)
        {
            _statusRepository.DeleteAsync(status).Wait();
            var deleteStatus = _statusRepository.ReadAllAsync().Result;
            return deleteStatus;
        }
        public IEnumerable<Status> GetById(int id)
        {
            var status = _statusRepository.GetByIdAsync(id).Result;
            return status;
        }
    }
}
