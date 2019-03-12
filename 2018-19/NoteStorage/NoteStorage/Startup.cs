﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NoteStorage.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace NoteStorage
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
             string connection = Configuration.GetConnectionString("DefaultConnection");
             services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));

             // установка конфигурации подключения
             services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options => //CookieAuthenticationOptions
                 {
                     options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/Index");
                 });


            services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

           /*services.AddDbContext<NoteStorageContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("UserContext")));*/
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Notes}/{action=Index}/{id?}");
            });
        }
    }
}
