using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mouha.DemoAspNetCoreGithub
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region "Cours sur les Middlewares"

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Bonjour, voici mon premier middleware");

            //    await next();

            //    await context.Response.WriteAsync("Bonjour, voici mon premier middleware");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Bonjour, voici mon deuxieme middleware");

            //    await next();

            //    await context.Response.WriteAsync("Bonjour, voici mon deuxieme middleware");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Bonjour, voici mon troisieme middleware");

            //    await next();
            //});

            //Il faudra ajouter UseRouting()

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.Map("/Mouha", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Mouha!");
            //    });
            //});

            #endregion

            app.UseRouting();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    #region "Cours sur les variables environnement"
                    //if (env.IsDevelopment())
                    //{
                    //    await context.Response.WriteAsync("Bonjour environnement dev!");
                    //}
                    //else if (env.IsProduction())
                    //{
                    //    await context.Response.WriteAsync("Bonjour environnement prod!");
                    //}
                    //else if (env.IsStaging())
                    //{
                    //    await context.Response.WriteAsync("Bonjour environnement stag!");
                    //}
                    //else
                    //{
                    //    await context.Response.WriteAsync(env.EnvironmentName);
                    //}

                    //if (env.IsEnvironment("Develop"))
                    //{
                    //    await context.Response.WriteAsync("Bonjour au particulier nom!");
                    //}
                    //else
                    //{
                    //    await context.Response.WriteAsync(env.EnvironmentName);
                    //}

                    #endregion

                    await context.Response.WriteAsync("Hello World!");

                });
            });

            
        }
    }
}
