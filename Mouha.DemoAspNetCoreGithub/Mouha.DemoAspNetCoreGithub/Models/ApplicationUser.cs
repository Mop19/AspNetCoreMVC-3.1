using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime? Datenaissance { get; set; }
    }
}
