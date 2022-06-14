using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface ISubmissionWriteToolService
    {
        public int Add(SubmissionWriteTool submissionWriteTool);
        public IEnumerable<SubmissionWriteTool> ReadAll();
        public SubmissionWriteTool Update(SubmissionWriteTool submissionWriteTool);
        public IQueryable<SubmissionWriteTool> DeleteAll(SubmissionWriteTool submissionWriteTool);
        public IEnumerable<SubmissionWriteTool> GetById(int id);
    }
}
