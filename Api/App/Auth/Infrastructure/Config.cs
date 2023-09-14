using Duende.IdentityServer.Models;

namespace App.Auth.Infrastructure;


public static class Config
{
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> {
            new ApiScope("Guest", "None logged-in user scope")
        };
    
    public static IEnumerable<Client> Clients => new List<Client> {
            new Client {
                ClientId = "client_id",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "Guest"
                    }
            }
        };
}
