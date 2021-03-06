﻿using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectWebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public static Parameter parameters;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();
            parameters = new Parameter();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            parameters.ConnectionStringMsSql = Configuration["ConnectionStrings:MsSql"];
            parameters.ConnectionStringMySql = Configuration["ConnectionStrings:MySql"];
            parameters.Path = Configuration["path:location"];
            parameters.FileName = Configuration["file:name"];

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
