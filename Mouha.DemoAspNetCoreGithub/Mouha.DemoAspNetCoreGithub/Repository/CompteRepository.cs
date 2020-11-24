using Microsoft.AspNetCore.Identity;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class CompteRepository : ICompteRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CompteRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}
