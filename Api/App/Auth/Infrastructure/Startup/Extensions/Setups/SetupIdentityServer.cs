using App.Core.Domain.Startup;

namespace App.Auth.Infrastructure.Startup.Extensions.Setups;

public class SetupIdentityServer : IStartupSetup
{
    public void Load(IServiceCollection services, IEnumerable<Type> assemblyTypes)
    {
        services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients);
    }
}