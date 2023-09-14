using App.Core.Domain.Startup;

namespace App.Core.Infrastructure.Startup.Extensions.Configurators;

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