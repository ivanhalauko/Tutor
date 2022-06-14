using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("Status")]
   public class Status : IEntity
   {
        public Status(string statusDiscription)
        {
            StatusDiscription = statusDiscription;
        }

        public Status (int id,string statusDiscription)
        {
            Id = id;
            StatusDiscription = statusDiscription;
        }
        [Key]
        public int Id { get; set; }
        public string StatusDiscription { get; set; }
    }
}
