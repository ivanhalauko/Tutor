using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class SubmissionWriteToolService : ISubmissionWriteToolService
    {
        private readonly IEfGenRepository<SubmissionWriteTool> _submissionWriteToolRepository;

        public SubmissionWriteToolService(IEfGenRepository<SubmissionWriteTool> submissionWriteToolRepository)
        {
            _submissionWriteToolRepository = submissionWriteToolRepository;
        }
        public int Add(SubmissionWriteTool submissionWriteTool)
        {
            var idNewSubmissionWriteTool = _submissionWriteToolRepository.AddAsync(submissionWriteTool).Result;
            return idNewSubmissionWriteTool;
        }

        public IEnumerable<SubmissionWriteTool> ReadAll()
        {
            var submissionWriteTools = _submissionWriteToolRepository.ReadAllAsync().Result;
            return submissionWriteTools;
        }

        public SubmissionWriteTool Update(SubmissionWriteTool submissionWriteTool)
        {
            var updateSubmissionWriteTool = _submissionWriteToolRepository.UpdateAsync(submissionWriteTool).Result;

            return updateSubmissionWriteTool;
        }

        public IQueryable<SubmissionWriteTool> DeleteAll(SubmissionWriteTool submissionWriteTool)
        {
            _submissionWriteToolRepository.DeleteAsync(submissionWriteTool).Wait();
            var deleteSubmissionWriteTool = _submissionWriteToolRepository.ReadAllAsync().Result;
            return deleteSubmissionWriteTool;
        }
        public IEnumerable<SubmissionWriteTool> GetById(int id)
        {
            var submissionWriteTools = _submissionWriteToolRepository.GetByIdAsync(id).Result;
            return submissionWriteTools;
        }
    }
}
