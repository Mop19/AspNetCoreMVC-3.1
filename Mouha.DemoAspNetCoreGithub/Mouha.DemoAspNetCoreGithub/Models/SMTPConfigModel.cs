using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class SMTPConfigModel
    {
        public string AdresseExpediteur { get; set; }
        public string NomExpediteur { get; set; }
        public string NomUser { get; set; }
        public string Password { get; set; }
        public string host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool IsBodyHTML { get; set; }
    }
}
