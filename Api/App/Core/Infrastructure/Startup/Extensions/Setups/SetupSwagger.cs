using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;
using Microsoft.OpenApi.Models;

namespace App.Core.Infrastructure.Startup.Helpers.Generators;

[StartupSetupOptions(priority: (byte)StartupPriorityLevel.Low)]
public class SetupSwagger : IStartupSetup
{
    public void ConfigureService(IServiceCollection services, IEnumerable<Type> assemblyTypes)
    {
        services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            config.AddSecurityRequirement(new()
            {
                {
                    new(){
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
    }
}