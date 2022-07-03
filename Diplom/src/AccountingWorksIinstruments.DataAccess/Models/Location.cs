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

        public Location(string nameOfLocation, int warehouseId)
        {
            NameOfLocation = nameOfLocation;
            WarehouseId = warehouseId;
                    }

        public Location(int id, string nameOfLocation, 
            int warehouseId)
        {
            Id = id;
            NameOfLocation = nameOfLocation;
            WarehouseId = warehouseId;
        }

        [Key]
        public int Id { get; set; }

        public string NameOfLocation { get; set; }

        public int WarehouseId { get; set; }
    }
}
