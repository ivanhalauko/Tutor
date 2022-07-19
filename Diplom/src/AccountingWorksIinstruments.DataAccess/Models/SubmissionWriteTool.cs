using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("SubmissionWriteTool")]
    public class SubmissionWriteTool : IEntity
    {

        public SubmissionWriteTool(int id,int toolId, int submissionWriteID)
        {
            Id = id;
            ToolId = toolId;
            SubmissionWriteID = submissionWriteID;
        }
        public SubmissionWriteTool(int toolId, int submissionWriteID)
        {
            ToolId = toolId;
            SubmissionWriteID = submissionWriteID;
        }

        public SubmissionWriteTool()
        {
        }

        [Key]
        public int Id { get; set; }
        public int ToolId { get; set; }
        public int SubmissionWriteID { get; set; }
    }
}
