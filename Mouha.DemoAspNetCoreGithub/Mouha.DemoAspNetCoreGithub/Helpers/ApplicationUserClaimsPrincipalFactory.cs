using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("PrenomUser", user.Prenom ?? ""));
            identity.AddClaim(new Claim("NomUser", user.Nom ?? ""));

            return identity;
        }
    }
}
