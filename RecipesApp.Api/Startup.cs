﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipes.DataAccess;
using Recipes.DataAccess.Common;
using Recipes.Models.Configuration;

namespace RecipesApp.Api
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
            services.AddMvc();

			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
			services.AddOptions();

			services.AddScoped<IRecipesRepository, RecipesRepository>();
			SessionFactory.Init(Configuration["AppSettings:Database:ConnectionString"]);
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
