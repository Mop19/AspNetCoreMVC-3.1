using Microsoft.AspNetCore.Identity;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class CompteRepository : ICompteRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CompteRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreationUserAsync(LogingUserModel logingUser)
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
    }
}
