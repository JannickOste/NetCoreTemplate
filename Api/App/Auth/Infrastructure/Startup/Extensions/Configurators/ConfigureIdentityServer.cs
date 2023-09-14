using App.Core.Domain.Startup;

namespace App.Auth.Infrastructure.Startup.Extensions.Configurators;

public class ConfigureIdentityServer : IStartupConfigurator
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseIdentityServer();
    }
}