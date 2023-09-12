using App.Core.Domain.Entities.User;
using App.Core.Domain.Startup;
using App.Core.Infrastructure.Authorization;
using App.Core.Infrastructure.Database;
using App.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace App.Core.Infrastructure.Startup.Helpers.Setups;

[StartupHelperOptions]
public class SetupIdentityServer : IStartupHelper
{
    public void Load(
        IServiceCollection services, 
        IEnumerable<Type> assemblyTypes
    ) {        
        ServiceProvider provider = services.BuildServiceProvider();
        services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiScopes(AuthorizationProvider.GetApiScopes())
                .AddInMemoryClients(AuthorizationProvider.GetClients());
        
        services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => {
                    options.Authority = "https://localhost:7105";
                    options.TokenValidationParameters = new TokenValidationParameters(){
                        ValidateAudience = false
                    };
                });
    }
}