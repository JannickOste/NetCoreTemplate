using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;

namespace App.Core.Infrastructure.Startup.Extensions.Configurators;

[StartupSetupOptions(priority: (byte)StartupPriorityLevel.Minimal)]
public class ConfigureEndpoints : IStartupConfigurator
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}