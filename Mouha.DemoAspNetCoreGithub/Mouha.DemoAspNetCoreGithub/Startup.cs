using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Mouha.DemoAspNetCoreGithub.Data;
using Mouha.DemoAspNetCoreGithub.Repository;

namespace Mouha.DemoAspNetCoreGithub
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Pour MVC
            services.AddControllersWithViews();

            services.AddDbContext<GestionLivreContext>(
                options => options.UseSqlServer("Server='.\\SQLEXPRESS';Database=BookStore;Integrated Security=True"));

            #if DEBUG
                //Compilation des pages razor lorsque changement
                services.AddRazorPages().AddRazorRuntimeCompilation();
            #endif

            services.AddScoped<BookRepository, BookRepository>();//r�soudre erreur par d�pendence injection de books
            services.AddScoped<LanguageRepository, LanguageRepository>();//r�soudre erreur par d�pendence injection de languages
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
     
            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapDefaultControllerRoute();
            });
      
        }
    }
}
