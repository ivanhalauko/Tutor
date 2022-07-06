using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingWorksIinstruments.Web.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Surname")]
        [Column(TypeName = "nvarchar(256)")]
        public string Surname { get; set; }

        [Display(Name = "PositionId")]
        [Column(TypeName = "int")]
        public int PositionId { get; set; }
    }
}
