using System.Reflection;
using App.Core.Domain.Authentication;
using App.Core.Domain.Startup;
using App.Core.Infrastructure.Authorization;
using App.Core.Infrastructure.Database;

namespace NetCore.Infrastructure.Startup;

/**
* @author: Oste Jannick
* @description: The startup configuration where all your dependencies configuration and injection occurs.
* @Date: 2023-09-11
*/
public class Startup
{
    public void ConfigureServices(
        IServiceCollection services
    )
    {
        services.AddDbContext<DatabaseContext>();


        Type startupHelperInterfaceType = typeof(IStartupHelper);
        Type[] assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
        foreach(Type assemblyType in assemblyTypes)
        {
            if(assemblyType.Equals(startupHelperInterfaceType)) continue;
            if(startupHelperInterfaceType.IsAssignableFrom(assemblyType))
            {
                
                IStartupHelper? helper = Activator.CreateInstance(assemblyType) as IStartupHelper;
                if(helper is not null)
                {
                    helper.Load(services, assemblyTypes);
                }
            }
        }

        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IConfiguration configuration
    )
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", configuration["API_NAME"]);
                c.RoutePrefix = String.Empty;
            });
        }

        app.UseIdentityServer();
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
