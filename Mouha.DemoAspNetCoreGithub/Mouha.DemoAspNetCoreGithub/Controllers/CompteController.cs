using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class CompteController : Controller
    {
        private readonly ICompteRepository _compteRepository;

        public CompteController(ICompteRepository compteRepository)
        {
            _compteRepository = compteRepository;
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(LogingUserModel logingUser)
        {
            if (ModelState.IsValid)
            {
                //Ecrire code
                var result = await _compteRepository.CreationUserAsync(logingUser);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View();
                }

                ModelState.Clear();
            }
            return View();
        }
    }
}
