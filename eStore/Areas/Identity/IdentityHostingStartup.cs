using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(eStore.Areas.Identity.IdentityHostingStartup))]
namespace eStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<eStoreIdentityDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("eStoreIdentityDbContextConnection")));

            //    services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<eStoreIdentityDbContext>();
            //});
        }
    }
}