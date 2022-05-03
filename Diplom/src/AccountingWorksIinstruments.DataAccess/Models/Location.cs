using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("Location")]
    public class Location : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string TheNameOfTheOrganization { get; set; }

        public string Warehouse1 { get; set; }

        public string Warehouse2 { get; set; }

        public string Warehouse3 { get; set; }
    }
}
