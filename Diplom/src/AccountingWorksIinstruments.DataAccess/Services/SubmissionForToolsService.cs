using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class SubmissionForToolsService : ISubmissionForToolsService
    {
        private readonly IEfGenRepository<SubmissionForTools> _submissionForToolsRepository;
        public SubmissionForToolsService(IEfGenRepository<SubmissionForTools> submissionForToolsRepository)
        {
            _submissionForToolsRepository = submissionForToolsRepository;
        }
        public int Add(SubmissionForTools submissionForTools)
        {
            var idNewSubmissionForTools = _submissionForToolsRepository.AddAsync(submissionForTools).Result;
            return idNewSubmissionForTools;
        }

        public IEnumerable<SubmissionForTools> ReadAll()
        {
            var submissionForTools = _submissionForToolsRepository.ReadAllAsync().Result;
            return submissionForTools;
        }

        public SubmissionForTools Update(SubmissionForTools submissionForTools)
        {
            var updateSubmissionForTools = _submissionForToolsRepository.UpdateAsync(submissionForTools).Result;

            return updateSubmissionForTools;
        }

        public IQueryable<SubmissionForTools> DeleteAll(SubmissionForTools submissionForTools)
        {
            _submissionForToolsRepository.DeleteAsync(submissionForTools).Wait();
            var deleteSubmissionForTools = _submissionForToolsRepository.ReadAllAsync().Result;
            return deleteSubmissionForTools;
        }
        public IEnumerable<SubmissionForTools> GetById(int id)
        {
            var submissionForTools = _submissionForToolsRepository.GetByIdAsync(id).Result;
            return submissionForTools;
        }
    }
}
