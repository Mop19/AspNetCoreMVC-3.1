using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;
using Mouha.DemoAspNetCoreGithub.Services;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController: Controller
    {
        private readonly NouveauLivreAlertConfig _nouveauLivreAlertConfig;
        private readonly NouveauLivreAlertConfig _thirdPartyBookConfig;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        //private readonly IConfiguration _configuration;

        [ViewData]
        public string proprieteCliente { get; set; }

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }

        public HomeController(IOptionsSnapshot<NouveauLivreAlertConfig> nouveauLivreAlertConfig, 
                              IMessageRepository messageRepository,
                              IUserService userService,
                              IEmailService emailService)
        {
            _nouveauLivreAlertConfig = nouveauLivreAlertConfig.Get("InternalBook");
            _thirdPartyBookConfig = nouveauLivreAlertConfig.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }

        //[Route("~/")]
        public async Task<ViewResult> Index()
        {
            //Title = "Accueil";
            proprieteCliente = "propriété Cliente";
            Book = new BookModel() { Id = 1, Title = "Asp.net Core" };

            UserEmailOptions options = new UserEmailOptions()
            {
                ToEmails = new List<string>() { "test@gmail.com" },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", "Mouha")
                }
            };

            await _emailService.EnvoyerTestEmail(options);

            //var userId = _userService.GetUserId();
            //var estConnecter = _userService.EstAuthentifier();

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
