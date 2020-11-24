using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;
using Mouha.DemoAspNetCoreGithub.Services;
using System.Dynamic;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController: Controller
    {
        private readonly NouveauLivreAlertConfig _nouveauLivreAlertConfig;
        private readonly NouveauLivreAlertConfig _thirdPartyBookConfig;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;

        //private readonly IConfiguration _configuration;

        [ViewData]
        public string proprieteCliente { get; set; }

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }

        public HomeController(IOptionsSnapshot<NouveauLivreAlertConfig> nouveauLivreAlertConfig, 
                              IMessageRepository messageRepository,
                              IUserService userService)
        {
            _nouveauLivreAlertConfig = nouveauLivreAlertConfig.Get("InternalBook");
            _thirdPartyBookConfig = nouveauLivreAlertConfig.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
        }

        //[Route("~/")]
        public ViewResult Index()
        {
            //Title = "Accueil";
            proprieteCliente = "propriété Cliente";
            Book = new BookModel() { Id = 1, Title = "Asp.net Core" };

            var userId = _userService.GetUserId();
            var estConnecter = _userService.EstAuthentifier();

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
