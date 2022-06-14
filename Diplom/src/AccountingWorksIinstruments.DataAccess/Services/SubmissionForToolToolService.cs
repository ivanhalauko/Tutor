using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class SubmissionForToolToolService : ISubmissionForToolToolService
    {
        private readonly IEfGenRepository<SubmissionForToolTool> _submissionForToolToolRepository;

        public SubmissionForToolToolService(IEfGenRepository<SubmissionForToolTool> submissionForToolToolRepository)
        {
            _submissionForToolToolRepository = submissionForToolToolRepository;
        }
        public int Add(SubmissionForToolTool submissionForToolTool)
        {
            var idNewSubmissionForToolTool = _submissionForToolToolRepository.AddAsync(submissionForToolTool).Result;
            return idNewSubmissionForToolTool;
        }

        public IEnumerable<SubmissionForToolTool> ReadAll()
        {
            var submissionForToolTool = _submissionForToolToolRepository.ReadAllAsync().Result;
            return submissionForToolTool;
        }

        public SubmissionForToolTool Update(SubmissionForToolTool submissionForToolTool)
        {
            var updateSubmissionForToolTool = _submissionForToolToolRepository.UpdateAsync(submissionForToolTool).Result;

            return updateSubmissionForToolTool;
        }

        public IQueryable<SubmissionForToolTool> DeleteAll(SubmissionForToolTool submissionForToolTool)
        {
            _submissionForToolToolRepository.DeleteAsync(submissionForToolTool).Wait();
            var deleteSubmissionForToolTool = _submissionForToolToolRepository.ReadAllAsync().Result;
            return deleteSubmissionForToolTool;
        }
        public IEnumerable<SubmissionForToolTool> GetById(int id)
        {
            var submissionForToolTool = _submissionForToolToolRepository.GetByIdAsync(id).Result;
            return submissionForToolTool;
        }
    }
}
