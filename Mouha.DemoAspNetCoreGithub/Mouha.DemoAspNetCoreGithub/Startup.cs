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
            //Décommenter ce code pour disabler le client side validations.
             //.AddViewOptions(option =>
             //{
             //    option.HtmlHelperOptions.ClientValidationEnabled = false;
             //});
#endif

            services.AddScoped<BookRepository, BookRepository>();//résoudre erreur par dépendence injection de books
            services.AddScoped<LanguageRepository, LanguageRepository>();//résoudre erreur par dépendence injection de languages
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

                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "AboutUs",
                pattern: "about-us",
                defaults: new { controller = "Home", action = "AboutUs" });
            });
      
        }
    }
}
