using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class User : IdentityUser
    {
        public string Surname { get; set; }

        public int LocationId { get; set; }

        public int PositionId { get; set; }
    }
}
