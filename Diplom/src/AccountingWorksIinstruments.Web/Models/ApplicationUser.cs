using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Surname")]
        [Column(TypeName = "nvchar(256)")]
        public string Surname { get; set; }

        [Display(Name = "PositionId")]
        [Column(TypeName = "int")]
        public int PositionId { get; set; }

    }
}
