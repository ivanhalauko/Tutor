using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class SubmissionFromWorkersViewModel
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public int ToolId { get; set; }
    }
}
