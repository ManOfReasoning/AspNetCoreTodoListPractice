using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoListBreeze.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TodoListBreeze.Areas.Identity.IdentityHostingStartup))]
namespace TodoListBreeze.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            string connectionStringName = "TodoListBreezeIdentityDbContextConnection";
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TodoListBreezeIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString(connectionStringName))
                    );

                services.AddDefaultIdentity<UserData>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = false;
                }).AddEntityFrameworkStores<TodoListBreezeIdentityDbContext>();
            });
        }
    }
}