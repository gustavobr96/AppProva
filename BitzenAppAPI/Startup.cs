using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitzenAppApplication.Interfaces;
using BitzenAppApplication.Services;
using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppDomain.Interfaces.Services;
using BitzenAppDomain.Services;
using BitzenAppInfra.Interfaces;
using BitzenAppInfra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BitzenAppAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            setContainer(services);
        }

        private void setContainer(IServiceCollection services)
        {

            #region instanciando as DI

            //Applications
            services.AddScoped<IApplicationUsuario, ApplicationUsuario>();
            services.AddScoped<IApplicationVeiculo, ApplicationVeiculo>();
            services.AddScoped<IApplicationAbastecimento, ApplicationAbastecimento>();
            services.AddScoped<IApplicationRelatorio, ApplicationRelatorio>();
         

            //Services
            services.AddScoped<IServiceUsuario, ServiceUsuario>();
            services.AddScoped<IServiceVeiculo, ServiceVeiculo>();
            services.AddScoped<IServiceAbastecimento, ServiceAbastecimento>();
            services.AddScoped<IServiceRelatorio, ServiceRelatorio>();
           


            //Repositorios
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IRepositoryVeiculo, RepositoryVeiculo>();
            services.AddScoped<IRepositoryAbastecimento, RepositoryAbastecimento>();
            services.AddScoped<IRepositoryRelatorio, RepositoryRelatorio>();
            

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
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
