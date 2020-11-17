using Microsoft.AspNetCore.Http;
using Mouha.DemoAspNetCoreGithub.Data;
using Mouha.DemoAspNetCoreGithub.Enums;
using Mouha.DemoAspNetCoreGithub.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mouha.DemoAspNetCoreGithub.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Le nombre de caractère est entre 5 a 100 ")]
        [Required(ErrorMessage = "S'il vous plait, entrez le titre du livre")]
        public string Title { get; set; }
        [Required(ErrorMessage = "S'il vous plait, entrez l'auteur du livre")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Le nombre de caractère est entre 10 a 500 ")]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="S'il vous choisissez une langue")]
        [Display(Name ="Langue")]
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "S'il vous choisissez les langues")]
        public LanguageEnum LanguageEnum { get; set; }
        [Required(ErrorMessage = "S'il vous plait, entrez le total des pages du livre")]
        [Display(Name ="Nombre total des pages")]
        public int? TotalPages { get; set; }
        public string Language { get; set; }
        [Display(Name ="Choisit la photo de ton livre")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        [Display(Name = "Choisit la galérie de ton livre")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }


        [Display(Name = "Upload votre livre en format pdf")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
    }
}
