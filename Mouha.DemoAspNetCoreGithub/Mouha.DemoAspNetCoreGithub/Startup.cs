using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mouha.DemoAspNetCoreGithub.Data;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;

namespace Mouha.DemoAspNetCoreGithub
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Pour MVC
            services.AddControllersWithViews();

            services.AddDbContext<GestionLivreContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<GestionLivreContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false; 
                options.Password.RequireNonAlphanumeric = false; 
                options.Password.RequireUppercase = false;
            });
#if DEBUG
            //Compilation des pages razor lorsque changement
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //Décommenter ce code pour disabler le client side validations.
             //.AddViewOptions(option =>
             //{
             //    option.HtmlHelperOptions.ClientValidationEnabled = false;
             //});
#endif

            services.AddScoped<IBookRepository, BookRepository>();//résoudre erreur par dépendence injection de books
            services.AddScoped<ILanguageRepository, LanguageRepository>();//résoudre erreur par dépendence injection de languages
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddScoped<ICompteRepository, CompteRepository>();

            services.Configure<NouveauLivreAlertConfig>("InternalBook", _configuration.GetSection("CreationNouveauLivre"));
            services.Configure<NouveauLivreAlertConfig>("ThirdPartyBook", _configuration.GetSection("ThirdPartyBook"));
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

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
      
        }
    }
}
