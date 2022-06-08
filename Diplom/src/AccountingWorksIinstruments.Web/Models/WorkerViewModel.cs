using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class WorkerViewModel
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public int PositionId { get; set; }

        public int ToolId { get; set; }
    }
}
