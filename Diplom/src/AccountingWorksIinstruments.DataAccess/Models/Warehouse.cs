using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("Warehouse")]
    public class Warehouse : IEntity
    {
        public Warehouse(int id, string warehouseNumber)
        {
            Id = id;
            WarehouseNumber = warehouseNumber;
        }

        public Warehouse(string warehouseNumber)
        {
            WarehouseNumber = warehouseNumber;
        }
        [Key]
        public int Id { get; set; }
        public string WarehouseNumber { get; set; }
    }
}
