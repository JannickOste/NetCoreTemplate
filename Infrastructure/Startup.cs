using System.Reflection;
using NetCore.Domain.Data;
using NetCore.Domain.Mappers;
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
        foreach (Type entityType in assemblyTypes.Where(t => t.GetCustomAttribute<RepositoryTargetAttribute>() is not null))
        {
            Type interfaceType = typeof(IDatabaseRepository<>).MakeGenericType(entityType);
            Type repositoryType = typeof(DatabaseRepository<>).MakeGenericType(entityType);

            services.AddScoped(interfaceType, repositoryType);
        }

        // Lazy create/Update mapper generator for entities
        Tuple<System.Type, Tuple<Type, Type>>[] mapGenerators = new Tuple<System.Type, Tuple<Type, Type>>[]  {
            new ( typeof(EntityCreateViewMapTargetAttribute), new(typeof(IEntityCreateMapper<,>), typeof(EntityCreateMapper<,>))),
            new ( typeof(EntityUpdateViewMapTargetAttribute), new(typeof(IEntityUpdateMapper<,>), typeof(EntityUpdateMapper<,>))),
        };

        foreach (Tuple<System.Type, Tuple<Type, Type>> generatorTypes in mapGenerators)
        {
            var (attributeType, mapper) = generatorTypes;
            if (typeof(IMapperGenerator).IsAssignableFrom(attributeType))
            {
                var (interfaceType, mapperType) = mapper;
                foreach (System.Type assemblyType in assemblyTypes.Where(t => t.GetCustomAttribute(attributeType) is not null))
                {
                    Attribute? attribute = assemblyType.GetCustomAttribute(attributeType);

                    if (attribute is IMapperGenerator generatorInfo)
                    {
                        Type generatorInterface = interfaceType.MakeGenericType(assemblyType, generatorInfo.MapToType);
                        Type generatorMapper = mapperType.MakeGenericType(assemblyType, generatorInfo.MapToType);

                        services.AddSingleton(generatorInterface, generatorMapper);
                    }
                }
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

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            // endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });
    }
}
