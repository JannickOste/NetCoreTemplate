using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;

namespace App.Auth.Infrastructure.Startup.Extensions.Setups;

[StartupSetupOptions(priority: (byte)StartupPriorityLevel.High)]
public class SetupIdentityServer : IStartupSetup
{
    public void ConfigureService(IServiceCollection services, IEnumerable<Type> assemblyTypes)
    {
        services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients);

        services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => {
                    options.Authority = "https://localhost:6001";
                    options.TokenValidationParameters = new() {
                        ValidateAudience = false
                    };
                });
    }
}