using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("NotesDeliveryTool")]
    public class NotesDeliveryTool : IEntity
    {
        public NotesDeliveryTool(int id,int toolId,int noteDeliveryId)
        {
            Id = id;
            ToolId = toolId;
            NoteDeliveryId = noteDeliveryId;
        }
        public NotesDeliveryTool(int toolId, int noteDeliveryId)
        {
            ToolId = toolId;
            NoteDeliveryId = noteDeliveryId;
        }

        public NotesDeliveryTool()
        {
        }

        [Key]
        public int Id { get; set; }
        public int ToolId { get; set; }
        public int NoteDeliveryId { get; set; }
    }
}
