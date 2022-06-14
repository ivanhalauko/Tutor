using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("SubmissionWriteOff")]
    public class SubmissionWriteOff : IEntity
    {
        public SubmissionWriteOff(int id,DateTime date )
        {
            Id = id;
            Date = date;
        }
        public SubmissionWriteOff(DateTime date)
        {
            Date = date;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
