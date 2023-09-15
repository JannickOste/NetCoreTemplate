using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;

namespace App.Core.Infrastructure.Startup.Extensions.Configurators;

[StartupSetupOptions(priority: (byte)StartupPriorityLevel.Medium)]
public class ConfigureRouting : IStartupConfigurator
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}