using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class CompteRepository : ICompteRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public CompteRepository(UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager,
                                IUserService userService,
                                IEmailService emailService,
                                IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
        }
        public async Task<IdentityResult> CreationUserAsync(DeconnecterUserModel logingUser)
        {
            var user = new ApplicationUser()
            {
                Prenom = logingUser.Prenom,
                Nom = logingUser.Nom,
                Email = logingUser.Email,
                UserName = logingUser.Email
            };
            var result = await _userManager.CreateAsync(user, logingUser.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    await EnvoyerEmailConfirmation(user, token);
                }
            }
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SeConnecterUserModel connecterUserModel)
        {
            var result = await _signInManager.PasswordSignInAsync(connecterUserModel.Email, connecterUserModel.Motdepasse, connecterUserModel.RemenberMe, false);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ModifierMotdepasseAsync(ModifierMotdepasseModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.MotdepasseCourant, model.NouveauMotdepasse);
        }

        private async Task EnvoyerEmailConfirmation(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions()
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.Prenom),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.EnvoyerEmailPourConfirmationEmail(options);
        }
    }
}
