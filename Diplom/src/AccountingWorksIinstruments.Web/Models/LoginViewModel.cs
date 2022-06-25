using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email/user name required")]
        [Display(Name = "Username/Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

