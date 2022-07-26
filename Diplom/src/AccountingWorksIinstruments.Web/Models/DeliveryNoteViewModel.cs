using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class DeliveryNoteViewModel
    {
        public int Id { get; set; }
        public int NumberOfDeliveryNote { get; set; }
        public int CarsNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Destination { get; set; }
        public IEnumerable<ApplicationUser> Worker { get; set; }
        public IEnumerable<ToolViewModel> AvailableTools { get; set; }
        public IEnumerable<ToolViewModel> ToolForShipment { get; set; }
        public string WorkerId { get; set; }
    }
}
