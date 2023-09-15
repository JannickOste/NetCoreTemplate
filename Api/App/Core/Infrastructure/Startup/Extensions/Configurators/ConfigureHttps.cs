using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;

namespace App.Core.Infrastructure.Startup.Extensions.Configurators;

[StartupSetupOptions(priority: (byte)StartupPriorityLevel.High)]
public class ConfigureHttps : IStartupConfigurator
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();
    }
}