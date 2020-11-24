using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class ModifierMotdepasseModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Mot de passe courant")]
        public string MotdepasseCourant { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Nouveau mot de passe")]
        public string NouveauMotdepasse { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirmer mot de passe")]
        [Compare("NouveauMotdepasse", ErrorMessage = "Le nouveau mot de passe ne correspond pas au nouveau")]
        public string ConfirmerMotdepasse { get; set; }
    }
}
