﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class ToolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int LocationId { get; set; }

        public string NameOfLocation { get; set; }
    }
}
