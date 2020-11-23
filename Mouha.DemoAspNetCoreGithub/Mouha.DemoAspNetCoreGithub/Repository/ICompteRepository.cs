using Microsoft.AspNetCore.Identity;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public interface ICompteRepository
    {
        Task<IdentityResult> CreationUserAsync(LogingUserModel logingUser);
    }
}