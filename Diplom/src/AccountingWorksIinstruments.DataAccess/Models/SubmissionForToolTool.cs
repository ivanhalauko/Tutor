using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("SubmissionForToolTool")]
    public class SubmissionForToolTool :IEntity
    {
        public SubmissionForToolTool(int id,int toolId, int submissionId)
        {
            Id = id;
            ToolId = toolId;
            SubmissionId = submissionId;
        }
        public SubmissionForToolTool(int toolId, int submissionId)
        {
            ToolId = toolId;
            SubmissionId = submissionId;
        }

        public SubmissionForToolTool()
        {
        }

        [Key]
        public int Id { get; set; }
        public int ToolId { get; set; }
        public int SubmissionId { get; set; }

    }
}
