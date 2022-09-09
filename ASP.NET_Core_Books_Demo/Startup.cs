using ASPNET_Core_Books_Demo.Data;
using ASPNET_Core_Books_Demo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace ASPNET_Core_Books_Demo
{
    public class Startup
    {
        private readonly IConfiguration _Config;
        public Startup(IConfiguration config)
        {
            _Config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(_Config.GetConnectionString("DefaultConnStr")));
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddScoped<IBookRepository, BookRepo>();
            services.AddScoped<ILanguageRepository, LanguageRepo>();
            services.AddSingleton<IMessageRepository, MessageRepo>();

            services.Configure<NewBookAlertConfig>("InternalBook", _Config.GetSection("NewBookAlert"));
            services.Configure<NewBookAlertConfig>("ThirdPartyBook", _Config.GetSection("ThirdPartyBook"));
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
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
                //endpoints.MapDefaultControllerRoute();
                /* endpoints.MapControllerRoute(
                     name: "Default",
                     pattern: "{controller}/{action}/{id?}",
                     defaults: new { Controller = "Home", Action = "Index" });
                */
                endpoints.MapControllers();

            });
        }
    }
}
