using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface ISubmissionWriteOffService
    {
        public int Add(SubmissionWriteOff submissionWriteOff);
        public IEnumerable<SubmissionWriteOff> ReadAll();
        public SubmissionWriteOff Update(SubmissionWriteOff submissionWriteOff);
        public IQueryable<SubmissionWriteOff> DeleteAll(SubmissionWriteOff submissionWriteOff);
        public IEnumerable<SubmissionWriteOff> GetById(int id);
    }
}
