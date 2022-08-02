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
        //public Tool(string name, string description,
        //    int locationId,string nameOfLocation)
        //{
        //    Name = name;
        //    Description = description;
        //    LocationId = locationId;
        //    NameOfLocation = nameOfLocation;
        //}

        public Tool(int id, string name, string description,
            int locationId, int statusId)
        {
            Id = id;
            Name = name;
            Description = description;
            LocationId = locationId;
            StatusId = statusId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int StatusId { get; set; }
        public string PosterImageUrl { get; set; }
        public string AspNetUsersId { get; set; }
        public bool MarkWriteOffTools { get; set; }
        public bool MarkForShipment { get; set; }
        public bool MarkFromWorker { get; set; }
        public string MarkDestinationUser { get; set; }
    }
}
