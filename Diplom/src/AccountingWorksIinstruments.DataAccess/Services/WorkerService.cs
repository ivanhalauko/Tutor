using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class WorkerService : IWorkerServices
    {
        private readonly IEfGenRepository<Worker> _workerRepository;

        public WorkerService(IEfGenRepository<Worker> workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public int Add(Worker worker)
        {
            var idNewWorker = _workerRepository.AddAsync(worker).Result;
            return idNewWorker;
        }

        public IEnumerable<Worker> ReadAll()
        {
            var worker = _workerRepository.ReadAllAsync().Result;
            return worker;
        }

        public Worker Update(Worker worker)
        {
            var updateWorker = _workerRepository.UpdateAsync(worker).Result;

            return updateWorker;
        }

        public IQueryable<Worker> DeleteAll(Worker worker)
        {
            _workerRepository.DeleteAsync(worker).Wait();
            var deleteWorker = _workerRepository.ReadAllAsync().Result;
            return deleteWorker;
        }
        public IEnumerable<Worker> GetById(int id)
        {
            var worker = _workerRepository.GetByIdAsync(id).Result;
            return worker;
        }
    }
}
