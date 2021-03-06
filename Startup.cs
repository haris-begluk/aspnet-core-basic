﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_basic.Data;
using aspnet_core_basic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace aspnet_core_basic
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
           .AddOpenIdConnect( options => { 
               _configuration.Bind("AzureAd", options);
           })
           .AddCookie(); 


            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            //if we need IRestaurantData in application we will get InMemoryRestaurantData with one instance for hole application 
            services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("OdeToFood")));
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            //if we need IRestaurantData in application we will get InMemoryRestaurantData with one instance for every request in app 
            services.AddSingleton<IGreeter, Greeter>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent()); 

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                // var greeting = "Greeting devs "; 
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        { // "{controller=Home}/{action=Index}/{id?}"
            routeBuilder.MapRoute("Default",
            "{controller=Home}/{action=Index}/{id?}"
            );
        }
    }
}
