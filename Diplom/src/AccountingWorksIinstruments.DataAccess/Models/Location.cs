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

        public Location(string nameOfTheOrganization, int warehouseId)
        {
            NameOfTheOrganization = nameOfTheOrganization;
            WarehouseId = warehouseId;
                    }

        public Location(int id, string nameOfTheOrganization, 
            int warehouseId)
        {
            Id = id;
            NameOfTheOrganization = nameOfTheOrganization;
            WarehouseId = warehouseId;
        }

        [Key]
        public int Id { get; set; }

        public string NameOfTheOrganization { get; set; }

        public int WarehouseId { get; set; }
    }
}
