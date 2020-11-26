using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
                return RedirectToAction("ConfirmEmail", new { email = logingUser.Email});
            }
            return View(logingUser);
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

                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Vous n'êtes pas autorisé à se connecter");
                }
                else
                {
                    ModelState.AddModelError("", "les informations d'identification invalides");
                }
                
            }

            return View(connecterUserModel);
        }

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

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        {
            EmailConfirmModel model = new EmailConfirmModel
            {
                Email = email
            };

            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _compteRepository.ConfirmEmailAsync(uid, token);
                if (result.Succeeded)
                {
                    model.EmailVerifie = true;
                }
            }

            return View(model);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
        {
            var user = await _compteRepository.GetUserByEmailAsync(model.Email);
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    model.EmailVerifie = true;
                    return View(model);
                }

                await _compteRepository.GenerateEmailConfirmationTokenAsync(user);
                model.EmailEnvoye = true;
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("", "Quelque chose ne marche pas");
            }
            return View();
        }

        [AllowAnonymous, HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                //Code
                var user = await _compteRepository.GetUserByEmailAsync(model.Email);
                if (user != null)
                {
                   await _compteRepository.GenerateForgotPasswordTokenAsync(user);
                }

                ModelState.Clear();
                model.EmailEnvoye = true;
            }
            return View(model);
        }

        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordModel model = new ResetPasswordModel
            {
                Token = token,
                UserId = uid
            };
            return View(model);
        }

        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                //Code
                model.Token = model.Token.Replace(' ', '+');
                var result = await _compteRepository.ResetPasswordAsync(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.EstSucces = true;
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
