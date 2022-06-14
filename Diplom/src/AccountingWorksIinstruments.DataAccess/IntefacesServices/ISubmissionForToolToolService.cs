using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingWorkInstruments.DataAccess.IntefacesServices
{
    public interface ISubmissionForToolToolService
    {
        public int Add(SubmissionForToolTool submissionForToolTool);
        public IEnumerable<SubmissionForToolTool> ReadAll();
        public SubmissionForToolTool Update(SubmissionForToolTool submissionForToolTool);
        public IQueryable<SubmissionForToolTool> DeleteAll(SubmissionForToolTool submissionForToolTool);
        public IEnumerable<SubmissionForToolTool> GetById(int id);
    }
}
