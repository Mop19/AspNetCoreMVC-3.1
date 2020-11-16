using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Langue français")]
        Francais = 10,
        [Display(Name = "Langue Anglais")]
        Anglais = 11,
        [Display(Name = "Langue Espagnole")]
        Espagnole = 12,
        [Display(Name = "Langue Allemand")]
        Allemand = 13,
        [Display(Name = "Langue Zaponnais")]
        Zaponnais = 14
    }
}
