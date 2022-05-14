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
        public Worker(string surname, string name, string secondName, int positionId, int toolId)
        {
            Surname = surname;
            Name = name;
            SecondName = secondName;
            PositionId = positionId;
            ToolId = toolId;
        }

        public Worker(int id, string surname, string name, string secondName, int positionId, int toolId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            SecondName = secondName;
            PositionId = positionId;
            ToolId = toolId;
        }

        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public int PositionId { get; set; }

        public int ToolId { get; set; }
    }
}
