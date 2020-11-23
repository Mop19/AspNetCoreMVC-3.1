using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mouha.DemoAspNetCoreGithub.Models;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class CompteController : Controller
    {
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public IActionResult SignUp(LogingUserModel logingUser)
        {
            if (ModelState.IsValid)
            {
                //Ecrire code

                ModelState.Clear();
            }
            return View();
        }
    }
}
