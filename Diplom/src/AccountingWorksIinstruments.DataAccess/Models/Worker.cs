using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("Worker")]
    public class Worker : IEntity
    {
        public Worker(string surname, string name, string secondName, int positionId, int locationId)
        {
            Surname = surname;
            Name = name;
            SecondName = secondName;
            PositionId = positionId;
            LocationId = locationId;
        }

        public Worker(int id, string surname, string name, string secondName, int positionId, int locationId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            SecondName = secondName;
            PositionId = positionId;
            LocationId = locationId;
        }

        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public int PositionId { get; set; }

        public int LocationId { get; set; }
    }
}
