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

        public Location(string nameOfTheOrganization, string warehouse)
        {
            NameOfTheOrganization = nameOfTheOrganization;
            Warehouse = warehouse;
                    }

        public Location(int id, string nameOfTheOrganization, 
            string warehouse)
        {
            Id = id;
            NameOfTheOrganization = nameOfTheOrganization;
            Warehouse = warehouse;
        }

        [Key]
        public int Id { get; set; }

        public string NameOfTheOrganization { get; set; }

        public string Warehouse { get; set; }
    }
}
