using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CoreDapperApi.Repositories;
using CoreDapperApi.Data;
using AutoMapper;
using CoreDapperApi.Models;

namespace CoreDapperApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://coredapperclient.azurewebsites.net","http://localhost:10505").AllowAnyHeader()
                                                                                                                    .AllowAnyMethod());
            });

            services.AddTransient<IcustomersRepository>(_ => new customersRepository(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            Mapper.Initialize(config =>
            {
                config.CreateMap<customersModel, CustomersViewModel>().ReverseMap();
            });

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
         
      
        }
    }
}
