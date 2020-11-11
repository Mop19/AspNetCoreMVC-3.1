using Microsoft.AspNetCore.Mvc;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
           // return View("~/TempView/MouhaTemp.cshtml");//full path
           // return View("../../TempView/MouhaTemp");//relative path
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
