using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Books_Demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            /*app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "My_Images")),
                RequestPath = "/My_Images"
            });*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                
                /*if (env.IsProduction())
                {
                    endpoints.Map("/", async context =>
                    {
                        await context.Response.WriteAsync("Hello From Production\n");
                    });
                }
                else if(env.IsDevelopment())
                {
                    endpoints.Map("/", async context =>
                    {
                        await context.Response.WriteAsync("Hello World!\n");
                    });
                }*/
            });

            /*app.Use(async (context, next) => 
            {
                await context.Response.WriteAsync("Hello 1st middleware\n");
                await next();
                await context.Response.WriteAsync("Hello 1st middleware response\n");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello 2nd middleware\n");
                await next();
                await context.Response.WriteAsync("Hello 2nd middleware response\n");
            });*/
        }
    }
}
