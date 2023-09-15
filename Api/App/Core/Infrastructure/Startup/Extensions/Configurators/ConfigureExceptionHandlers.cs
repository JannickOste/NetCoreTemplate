using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;

namespace App.Core.Infrastructure.Startup.Extensions.Configurators;

[ConfigureSetupOptions(priority: StartupPriorityLevel.TopLevel)]
public class ConfigureExceptionHandlers : IStartupConfigurator
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "");
                c.RoutePrefix = String.Empty;
            });
        }
    }
}