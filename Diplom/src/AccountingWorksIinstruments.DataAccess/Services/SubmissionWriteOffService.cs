using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    class SubmissionWriteOffService : ISubmissionWriteOffService
    {
        private readonly IEfGenRepository<SubmissionWriteOff> _submissionWriteOffRepository;
        public SubmissionWriteOffService(IEfGenRepository<SubmissionWriteOff> submissionWriteOffRepository)
        {
            _submissionWriteOffRepository = submissionWriteOffRepository;
        }
        public int Add(SubmissionWriteOff submissionWriteOff)
        {
            var idNewSubmissionWriteOff = _submissionWriteOffRepository.AddAsync(submissionWriteOff).Result;
            return idNewSubmissionWriteOff;
        }

        public IEnumerable<SubmissionWriteOff> ReadAll()
        {
            var submissionWriteOff = _submissionWriteOffRepository.ReadAllAsync().Result;
            return submissionWriteOff;
        }

        public SubmissionWriteOff Update(SubmissionWriteOff submissionWriteOff)
        {
            var updateSubmissionWriteOff = _submissionWriteOffRepository.UpdateAsync(submissionWriteOff).Result;

            return updateSubmissionWriteOff;
        }

        public IQueryable<SubmissionWriteOff> DeleteAll(SubmissionWriteOff submissionWriteOff)
        {
            _submissionWriteOffRepository.DeleteAsync(submissionWriteOff).Wait();
            var deleteSubmissionWriteOff = _submissionWriteOffRepository.ReadAllAsync().Result;
            return deleteSubmissionWriteOff;
        }
        public IEnumerable<SubmissionWriteOff> GetById(int id)
        {
            var submissionWriteOff = _submissionWriteOffRepository.GetByIdAsync(id).Result;
            return submissionWriteOff;
        }
    }
}
