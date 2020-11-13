using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            //ViewBag.Title = "MouhaWeb";

            //dynamic data = new ExpandoObject();
            //data.Id = 1;
            //data.Name = "Mouha";

            //ViewBag.Data = data;

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
