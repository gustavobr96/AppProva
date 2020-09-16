using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppInfra.Interfaces;
using BitzenAppInfra.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProvaAppApplication.Interfaces;
using ProvaAppApplication.Services;
using ProvaAppDomain.Interfaces.Repositories;
using ProvaAppDomain.Interfaces.Services;
using ProvaAppDomain.Services;
using ProvaAppInfra.Repositories;

namespace BitzenApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMvc();
            setContainer(services);


        }

        private void setContainer(IServiceCollection services)
        {

            #region instanciando as DI

            //Applications
            services.AddScoped<IApplicationCliente, ApplicationCliente>();

            //Services
            services.AddScoped<IServiceCliente, ServiceCliente>();


            //Repositorios
            services.AddScoped<IRepositoryCliente, RepositoryCliente>();

            // infra
            services.AddScoped<IDbConnectionString, DbConnectionString>();
            #endregion


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
   
            app.UseMvc();
        }
    }
}
