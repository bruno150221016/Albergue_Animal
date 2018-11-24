using System;
using Albergue_Animal.Areas.Identity.Data;
using Albergue_Animal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Albergue_Animal.Areas.Identity.IdentityHostingStartup))]
namespace Albergue_Animal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ApplicationUserContextConnection")));

               // services.AddDefaultIdentity<ApplicationUser>()
                 //   .AddEntityFrameworkStores<ApplicationUserContext>();
            });
        }
    }
}