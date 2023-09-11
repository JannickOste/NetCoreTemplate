using System.Reflection;
using NetCore.Domain.Data;
using NetCore.Domain.Mappers.ViewModels;
using NetCore.Infrastructure.Data;
using NetCore.Infrastructure.Mappers.ViewModels;

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
        System.Type[] assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

        // Lazy repository inject, all entities with RepositoryTarget attribute.
        services.AddDbContext<DatabaseContext>();
        foreach(Type entityType in assemblyTypes.Where(t => t.GetCustomAttribute<RepositoryTargetAttribute>() is not null))
        {
            Type interfaceType = typeof(IDatabaseRepository<>).MakeGenericType(entityType);
            Type repositoryType = typeof(DatabaseRepository<>).MakeGenericType(entityType);

            services.AddScoped(interfaceType, repositoryType);
        }

        ///!TODO: Look for way to generalize this, possible for loop ?
        // Lazy Create ViewModel mapper generation
        foreach(Type createMapperDestinationType in assemblyTypes.Where(t => t.GetCustomAttribute<EntityCreateViewMapTargetAttribute>() is not null))
        {
            EntityCreateViewMapTargetAttribute? targetAttr = createMapperDestinationType.GetCustomAttribute<EntityCreateViewMapTargetAttribute>();

            if(targetAttr is not null)
            {
                Type interfaceType = typeof(IEntityCreateMapper<,>).MakeGenericType(createMapperDestinationType, targetAttr.MapToType);
                Type createMapperType = typeof(EntityCreateMapper<,>).MakeGenericType(createMapperDestinationType, targetAttr.MapToType);

                services.AddSingleton(interfaceType, createMapperType);
            }
        }

        // Lazy Update ViewModel mapper generation
        foreach(Type updateMapperDestinationType in assemblyTypes.Where(t => t.GetCustomAttribute<EntityUpdateViewMapTargetAttribute>() is not null))
        {
            EntityUpdateViewMapTargetAttribute? targetAttr = updateMapperDestinationType.GetCustomAttribute<EntityUpdateViewMapTargetAttribute>();

            if(targetAttr is not null)
            {
                Type interfaceType = typeof(IEntityUpdateMapper<,>).MakeGenericType(updateMapperDestinationType, targetAttr.MapToType);
                Type updateMapperType = typeof(EntityUpdateMapper<,>).MakeGenericType(updateMapperDestinationType, targetAttr.MapToType);

                services.AddSingleton(interfaceType, updateMapperType);
            }
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
