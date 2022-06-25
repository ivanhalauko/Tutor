using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class HistoryOfADelivaryNotesViewModel
    {
        public int NumberOfDeliveryNote { get; set; }

        public int CarsNumber { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
