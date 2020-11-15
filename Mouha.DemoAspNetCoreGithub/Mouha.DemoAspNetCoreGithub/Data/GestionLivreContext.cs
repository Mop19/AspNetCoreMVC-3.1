using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Data
{
    public class GestionLivreContext: DbContext
    {
        public GestionLivreContext(DbContextOptions<GestionLivreContext> options)
            : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
