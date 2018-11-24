﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Albergue_Animal.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Albergue_Animal.Models;
using Albergue_Animal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Albergue_Animal
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;


            })

                .AddDefaultTokenProviders()
           //services.AddDefaultIdentity<IdentityUser>()
           .AddEntityFrameworkStores<ApplicationUserContext>();
            
               


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IEmailSender, Albergue_Animal.Areas.Identity.Services.EmailSenders>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateRoles(serviceProvider).Wait();
        }









        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles   
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "User", "HR" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1  
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            ApplicationUser user = await UserManager.FindByEmailAsync("the.kratos000@gmail.com");

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "the.kratos000@gmail.com",
                    Email = "the.kratos000@gmail.com",
                };
                await UserManager.CreateAsync(user, "the.kratos000");
            }
            await UserManager.AddToRoleAsync(user, "Admin");


            ApplicationUser user1 = await UserManager.FindByEmailAsync("joaosilgo96@gmail.com");

            if (user1 == null)
            {
                user1 = new ApplicationUser()
                {
                    UserName = "joaosilgo96@gmail.com",
                    Email = "joaosilgo96@gmail.com",
                };
                await UserManager.CreateAsync(user1, "Jo@og0mes");
            }
            await UserManager.AddToRoleAsync(user1, "User");

            ApplicationUser user2 = await UserManager.FindByEmailAsync("the.kratos000@gmail.com");

            if (user2 == null)
            {
                user2 = new ApplicationUser()
                {
                    UserName = "150221016@estudantes.ips.pt",
                    Email = "150221016@estudantes.ips.pt",
                };
               await UserManager.CreateAsync(user2, "150221016@Estudantes");
            }
            await UserManager.AddToRoleAsync(user2, "HR");
//
        }


    }
}
