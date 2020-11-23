using Microsoft.Extensions.Options;
using Mouha.DemoAspNetCoreGithub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NouveauLivreAlertConfig> _nouveauLivreAlertConfig;

        public MessageRepository(IOptionsMonitor<NouveauLivreAlertConfig> nouveauLivreAlertConfig)
        {
            _nouveauLivreAlertConfig = nouveauLivreAlertConfig;
        }

        public string GetName()
        {
            return _nouveauLivreAlertConfig.CurrentValue.NomLivre;
        }
    }
}
