using Microsoft.AspNetCore.Mvc;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class HomeController: Controller
    {
        public string Index()
        {
            return "Bonjour Mouha!";
        }
    }
}
