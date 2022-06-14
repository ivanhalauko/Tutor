using AccountingWorkInstruments.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Models
{
    [Table("NoteDelivery")]
    public class NoteDelivery : IEntity
    {
        public NoteDelivery(int numberOfDeliveryNote, int carsNumber, DateTime deliveryDate)
        {
            NumberOfDeliveryNote = numberOfDeliveryNote;
            CarsNumber = carsNumber;
            DeliveryDate = deliveryDate;
        }

        public NoteDelivery(int id, int numberOfDeliveryNote,int carsNumber,DateTime deliveryDate)
        {
            Id = id;
            NumberOfDeliveryNote = numberOfDeliveryNote;
            CarsNumber = carsNumber;
            DeliveryDate = deliveryDate;
        }
        [Key]
        public int Id { get; set; }
        public int NumberOfDeliveryNote { get; set; }
        public int CarsNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
