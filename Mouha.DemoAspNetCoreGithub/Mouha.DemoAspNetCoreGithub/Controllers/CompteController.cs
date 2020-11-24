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
        public async Task<IActionResult> SignUp(DeconnecterUserModel logingUser)
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

                    return View(logingUser);
                }

                ModelState.Clear();
                return View();
            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(SeConnecterUserModel connecterUserModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _compteRepository.PasswordSignInAsync(connecterUserModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "les informations d'identification invalides");
            }

            return View(connecterUserModel);
        }

        //[Route("signout")]
        //public IActionResult SignOut()
        //{
        //    return View();
        //}

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _compteRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("modifier-motdepasse")]
        public IActionResult ModifierMotdepasse()
        {    
            return View();
        }

        [Route("modifier-motdepasse")]
        [HttpPost]
        public async Task<IActionResult> ModifierMotdepasse(ModifierMotdepasseModel model)
        {
            if (ModelState.IsValid)
            {
                //Ecrire code
                var result = await _compteRepository.ModifierMotdepasseAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.EstReussi = true;
                    ModelState.Clear();
                    return View();
                }

                foreach (var erreur in result.Errors)
                {
                    ModelState.AddModelError("", erreur.Description);
                }
            }

            return View(model);
        }
    }
}
