using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetCore.Domain.Data;
using NetCore.Domain.Models;
using NetCore.Infrastructure.Data;

namespace NetCore.Infrastructure;

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
        // Lazy repository injection, all entities with RepositoryTarget attribute.
        services.AddDbContext<DatabaseContext>();
        IEnumerable<System.Type> entityTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
            t => t.GetCustomAttribute<RepositoryTargetAttribute>() is not null
        );

        foreach(System.Type entityType in entityTypes)
        {
            Type interfaceType = typeof(IDatabaseRepository<>).MakeGenericType(entityType);
            Type repositoryType = typeof(DatabaseRepository<>).MakeGenericType(entityType);

            services.AddScoped(interfaceType, repositoryType);
        }

        // Controller / Service initialization
        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(
        IApplicationBuilder app, 
        IWebHostEnvironment env,
        IConfiguration configuration
    )
    {
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", configuration["API_NAME"]);
                c.RoutePrefix = String.Empty;
            });
        }

        app.UseRouting();
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
            // endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });
    }
}
