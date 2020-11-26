using Mouha.DemoAspNetCoreGithub.Models;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Services
{
    public interface IEmailService
    {
        Task EnvoyerTestEmail(UserEmailOptions userEmailOptions);
        Task EnvoyerEmailPourConfirmationEmail(UserEmailOptions userEmailOptions);
        Task EnvoyerEmailForgotPassword(UserEmailOptions userEmailOptions);
    }
}