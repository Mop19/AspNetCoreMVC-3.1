using Microsoft.EntityFrameworkCore;
using Mouha.DemoAspNetCoreGithub.Data;
using Mouha.DemoAspNetCoreGithub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class LanguageRepository: DbContext
    {
        private readonly GestionLivreContext _context = null;
        public LanguageRepository(GestionLivreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Nom = x.Nom,
                Description = x.Description
            }).ToListAsync();
        }
    }
}
