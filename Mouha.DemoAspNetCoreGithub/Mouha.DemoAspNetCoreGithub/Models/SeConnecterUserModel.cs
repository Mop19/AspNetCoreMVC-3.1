using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class SeConnecterUserModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Motdepasse { get; set; }
        [Display(Name = "Mémoriser")]
        public bool RemenberMe { get; set; }
    }
}
