using System.ComponentModel.DataAnnotations;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Entrez email")]
        [EmailAddress(ErrorMessage ="Ce courriel n'est pas valide")]
        public string MyField { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Le nombre de caractère est entre 5 a 100 ")]
        [Required(ErrorMessage ="S'il vous plait, entrez le titre du livre")]
        public string Title { get; set; }
        [Required(ErrorMessage = "S'il vous plait, entrez l'auteur du livre")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Le nombre de caractère est entre 10 a 500 ")]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "S'il vous plait, entrez le total des pages du livre")]
        [Display(Name ="Nombre total des pages")]
        public int? TotalPages { get; set; }
    }
}
