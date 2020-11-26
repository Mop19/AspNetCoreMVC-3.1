using Microsoft.Extensions.Options;
using Mouha.DemoAspNetCoreGithub.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Services
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smptConfig;

        public async Task EnvoyerTestEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolders("Bonjour {{UserName}}, Ceci est un test du sujet d'email de l'application Gestion des livres", userEmailOptions.PlaceHolders);
            
            userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("TestEmail"), userEmailOptions.PlaceHolders);

            await EnvoyerEmail(userEmailOptions);
        }

        public async Task EnvoyerEmailPourConfirmationEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolders("Bonjour {{UserName}}, Confirmez votre id email", userEmailOptions.PlaceHolders);

            userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("EmailConfirm"), userEmailOptions.PlaceHolders);

            await EnvoyerEmail(userEmailOptions);
        }

        public async Task EnvoyerEmailForgotPassword(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolders("Bonjour {{UserName}}, réinitialiser votre mot de passe", userEmailOptions.PlaceHolders);

            userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("ForgotPassword"), userEmailOptions.PlaceHolders);

            await EnvoyerEmail(userEmailOptions);
        }

        public EmailService(IOptions<SMTPConfigModel> smptConfig)
        {
            _smptConfig = smptConfig.Value;
        }
        private async Task EnvoyerEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smptConfig.AdresseExpediteur, _smptConfig.NomExpediteur),
                IsBodyHtml = _smptConfig.IsBodyHTML
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smptConfig.NomUser, _smptConfig.Password);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smptConfig.host,
                Port = _smptConfig.Port,
                EnableSsl = _smptConfig.EnableSSL,
                UseDefaultCredentials = _smptConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }

        private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeholder in keyValuePairs)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key, placeholder.Value);
                    }
                }
            }

            return text;
        }
    }
}
