using Microsoft.AspNetCore.Identity;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public interface ICompteRepository
    {
        Task<IdentityResult> CreationUserAsync(DeconnecterUserModel logingUser);
        Task<SignInResult> PasswordSignInAsync(SeConnecterUserModel connecterUserModel);
        Task SignOutAsync();
        Task<IdentityResult> ModifierMotdepasseAsync(ModifierMotdepasseModel model);
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
    }
}