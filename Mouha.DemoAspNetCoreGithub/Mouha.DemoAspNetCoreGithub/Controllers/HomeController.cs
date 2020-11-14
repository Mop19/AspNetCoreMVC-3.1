using Microsoft.AspNetCore.Mvc;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Dynamic;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class HomeController: Controller
    {
        [ViewData]
        public string proprieteCliente { get; set; }

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }

        public ViewResult Index()
        {
            Title = "Accueil";
            proprieteCliente = "propriété Cliente";
            Book = new BookModel() { Id = 1, Title = "Asp.net Core" };
            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "A propos de nous";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contactez-nous";
            return View();
        }
    }
}
