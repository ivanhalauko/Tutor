using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class LocationViewModel
    {

        public int Id { get; set; }

        public string NameOfOrganization { get; set; }

        public string Warehouse1 { get; set; }
        public string Warehouse2 { get; set; }
        public string Warehouse3 { get; set; }
    }
}
