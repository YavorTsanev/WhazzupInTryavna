using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhazzupInTryavna.Data;
using WhazzupInTryavna.Data.Models;

[assembly: HostingStartup(typeof(WhazzupInTryavna.Web.Areas.Identity.IdentityHostingStartup))]
namespace WhazzupInTryavna.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}