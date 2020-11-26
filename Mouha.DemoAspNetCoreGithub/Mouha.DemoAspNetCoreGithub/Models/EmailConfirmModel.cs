using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class EmailConfirmModel
    {
        public string Email { get; set; }
        public bool EstConforme { get; set; }
        public bool EmailEnvoye { get; set; }
        public bool EmailVerifie { get; set; }
    }
}
