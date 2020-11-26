using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required, DataType(DataType.Password)]
        public string NouveauMotdepasse { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare("NouveauMotdepasse")]
        public string ConfirmNouveauMotdepasse { get; set; }
        public bool EstSucces { get; set; }
    }
}
