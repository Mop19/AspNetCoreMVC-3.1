using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class LogingUserModel
    {
        [Required(ErrorMessage = "S'il vous plait entrer votre prénom")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "S'il vous plait entrer votre email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "S'il vous plait entrer un mot de passe valide")]
        public string Email { get; set; }
        [Required(ErrorMessage = "S'il vous plait entrer un fort mot de passe")]
        [Compare("ConfirmPassword", ErrorMessage = "Les deux mots de passe sont differents")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "S'il vous plait confirmez votre mot de passe")]
        [Display(Name = "Retapez votre mot de passe")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
