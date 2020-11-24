using Microsoft.AspNetCore.Identity;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Services;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class CompteRepository : ICompteRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;

        public CompteRepository(UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager,
                                IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
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
    }
}
