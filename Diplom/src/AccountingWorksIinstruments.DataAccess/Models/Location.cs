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

        public Location(string theNameOfTheOrganization, string warehouse1, string warehouse2, string warehouse3)
        {
            TheNameOfTheOrganization = theNameOfTheOrganization;
            Warehouse1 = warehouse1;
            Warehouse2 = warehouse2;
            Warehouse3 = warehouse3;
        }

        public Location(int id, string theNameOfTheOrganization, 
            string warehouse1, string warehouse2, string warehouse3)
        {
            Id = id;
            TheNameOfTheOrganization = theNameOfTheOrganization;
            Warehouse1 = warehouse1;
            Warehouse2 = warehouse2;
            Warehouse3 = warehouse3;
        }

        [Key]
        public int Id { get; set; }

        public string TheNameOfTheOrganization { get; set; }

        public string Warehouse1 { get; set; }

        public string Warehouse2 { get; set; }

        public string Warehouse3 { get; set; }


    }
}
