using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Dynamic;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController: Controller
    {
        private readonly IConfiguration _configuration;

        [ViewData]
        public string proprieteCliente { get; set; }

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
         }

        //[Route("~/")]
        public ViewResult Index()
        {
            //Title = "Accueil";
            proprieteCliente = "propriété Cliente";
            Book = new BookModel() { Id = 1, Title = "Asp.net Core" };

            var nouveauLivre = new NouveauLivreAlertConfig();
            _configuration.Bind("CreationNouveauLivre", nouveauLivre);

            bool estAfficher = nouveauLivre.AfficherAlertCreationLivre;
          
            //var nouveauLivre = _configuration.GetSection("CreationNouveauLivre");
            //var result = nouveauLivre.GetValue<bool>("AfficherAlertCreationLivre");
            //var NomLivre = nouveauLivre.GetValue<string>("NomLivre");

            //var result = _configuration["AppName"];
            //var key1 = _configuration["infoObj:key1"];
            //var key2 = _configuration["infoObj:key2"];
            //var key3 = _configuration["infoObj:key3:key3obj1"];

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
