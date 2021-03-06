﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mouha.DemoAspNetCoreGithub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Data
{
    public class GestionLivreContext: IdentityDbContext<ApplicationUser>
    {
        public GestionLivreContext(DbContextOptions<GestionLivreContext> options)
            : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<BookGallery> BookGallery { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}
