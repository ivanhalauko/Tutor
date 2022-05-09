using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("Position")]
   public class Position : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
