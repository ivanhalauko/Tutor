using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface ISubmissionForToolsService
    {
        public int Add(SubmissionForTools submissionForTools);
        public IEnumerable<SubmissionForTools> ReadAll();
        public SubmissionForTools Update(SubmissionForTools submissionForTools);
        public IQueryable<SubmissionForTools> DeleteAll(SubmissionForTools submissionForTools);
        public IEnumerable<SubmissionForTools> GetById(int id);
    }
}

