using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("SubmissionForTools")]
    public class SubmissionForTools : IEntity
    {
        public SubmissionForTools(string purpose, DateTime dateOfDelivery)
        {
            Purpose = purpose;
            DateOfDelivery = dateOfDelivery;
        }

        public SubmissionForTools(int id,string purpose,DateTime dateOfDelivery)
        {
            Id = id;
            Purpose = purpose;
            DateOfDelivery = dateOfDelivery;
        }
        [Key]
        public int Id { get; set; }
        public string Purpose { get; set; }
        public DateTime DateOfDelivery { get; set; }
    }
}
