using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class StockAccountViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public string NameOfTheOrganization { get; set; }

        public int WorkerId { get; set; }

        public string Purpose { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public int ToolId { get; set; }

        public string StatusDiscription { get; set; }

        public int NumberOfDeliveryNote { get; set; }

        public int CarsNumber { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int NoteDeliveryId { get; set; }
    }
}
