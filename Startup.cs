using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Repository;
using Web.Repository.Base;

namespace Clinica_Viva_Bem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Metodo para configurar serviços
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(o => o.UseMySql(
               Configuration.GetConnectionString("Default"),
               new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddScoped<IPatientService, PatientRepository>();
            services.AddScoped<IDoctorService, DoctorRepository>();
            services.AddScoped<IConsultaService, ConsultaRepository>();
            services.AddControllersWithViews();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
