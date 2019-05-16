using ContosoPets.Ui.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ContosoPets.Ui.Areas.Identity.IdentityHostingStartup))]
namespace ContosoPets.Ui.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ContosoPetsContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("ContosoPetsContextConnection")));

                services.AddDefaultIdentity<ContosoPetsUser>()
                    .AddEntityFrameworkStores<ContosoPetsContext>();
            });
        }
    }
}