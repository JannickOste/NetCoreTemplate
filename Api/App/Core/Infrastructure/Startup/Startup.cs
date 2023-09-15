namespace App.Core.Infrastructure.Startup;

public class Startup
{
    public void ConfigureServices(
        IServiceCollection services
    ) =>  SetupServicesMiddleware.Invoke(services);

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env
    ) => ConfigureServicesMiddleware.Invoke(app, env);
}
