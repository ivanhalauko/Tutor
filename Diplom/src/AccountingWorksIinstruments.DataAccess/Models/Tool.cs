using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("Tool")]
    public class Tool : IEntity
    {
        public Tool(string name, string description, int locationId)
        {
            Name = name;
            Description = description;
            LocationId = locationId;
        }

        public Tool(int id, string name, string description, int locationId)
        {
            Id = id;
            Name = name;
            Description = description;
            LocationId = locationId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int LocationId { get; set; }
    }
}
