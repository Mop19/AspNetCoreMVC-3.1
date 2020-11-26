using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress, Display(Name = "Enregrement adresse email")]
        public string Email { get; set; }
        public bool EmailEnvoye { get; set; }
    }
}
