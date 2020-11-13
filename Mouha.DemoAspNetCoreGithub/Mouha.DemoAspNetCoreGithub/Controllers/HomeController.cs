using Microsoft.AspNetCore.Mvc;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Dynamic;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            ViewData["propriete1"] = "Mouha";

            ViewData["book"] = new BookModel() { Id = 1, Author = "Mouhamed" };

            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
