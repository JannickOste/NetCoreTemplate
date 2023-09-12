using App.Core.Domain.Authentication;
using App.Core.Domain.Entities.User;
using App.Core.Infrastructure.Database;
using Duende.IdentityServer.Models;

namespace App.Core.Infrastructure.Authorization;

public class AuthorizationProvider
{
    private DatabaseRepository<UserScope> scopeRepository;

    public AuthorizationProvider(
        DatabaseRepository<UserScope> scopeRepository
    )  {
        this.scopeRepository = scopeRepository;
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new []{new ApiScope("Guest")};
    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>(){
            new(){
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "Guest"}
            }
        };
    }
}