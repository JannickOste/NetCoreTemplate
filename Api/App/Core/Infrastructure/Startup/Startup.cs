using App.Core.Infrastructure.Database;

namespace App.Core.Infrastructure.Startup;

public class Startup
{
    public void ConfigureServices(
        IServiceCollection services
    ) =>  SetupServicesMiddleware.Invoke(services);

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IConfiguration configuration
    )
    {
        ConfigureServicesMiddleware.Invoke(app, env);
        app.UseHttpsRedirection();

        // app.UseIdentityServer();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            // endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });
    }
}
