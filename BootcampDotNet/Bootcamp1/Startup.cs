using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bootcamp1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            services.AddDbContext<BootcampDotNetDBContext>(
             optionsAction: opt =>
             {
                 opt.UseSqlServer(Configuration.GetConnectionString("BootcampDotNetDB"), config =>
                 {
                 });
                 opt.UseLoggerFactory(LoggerFactory.Create(cfg => cfg.AddConsole()));


             });

            var serviceTypes = Assembly.GetExecutingAssembly().GetTypes()
             .Where(type => type.IsClass)
             .Where(type => type.IsAbstract == false)
             .Where(type => type.FullName.EndsWith("Service")).ToList();
            serviceTypes.ForEach(type =>
            {
                services.AddScoped(type);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=fooddb}/{action=Index}/{id?}");
            });
        }
    }
}
