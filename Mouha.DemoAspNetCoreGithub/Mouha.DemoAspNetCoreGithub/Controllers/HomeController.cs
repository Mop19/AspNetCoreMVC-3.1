using Microsoft.AspNetCore.Mvc;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Dynamic;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController: Controller
    {
        [ViewData]
        public string proprieteCliente { get; set; }

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }

        //[Route("~/")]
        public ViewResult Index()
        {
            Title = "Accueil";
            proprieteCliente = "propriété Cliente";
            Book = new BookModel() { Id = 1, Title = "Asp.net Core" };
            return View();
        }

        //[Route("about-us/{name:alpha:minlenght(3):regex()}")]
        public ViewResult AboutUs(string name)
        {
            Title = "A propos de nous";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contactez-nous";
            return View();
        }

        [Route("test/a{a}")]
        public string Test(string a)
        {
            return a;
        }

        [Route("test/b{a}")]
        public string Test1(string a)
        {
            return a;
        }

        [Route("test/c{a}")]
        public string Test2(string a)
        {
            return a;
        }
    }
}
