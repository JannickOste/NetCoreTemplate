using System.Reflection;
using App.Core.Domain.Mappers;
using App.Core.Domain.Mappers.Entity;
using App.Core.Domain.Startup;
using App.Core.Infrastructure.Mappers;

namespace App.Core.Infrastructure.Startup.Helpers.Generators;

[StartupHelperOptions]
public class LoadMappers : IStartupHelper
{
    private struct GeneratorType 
    {
        public Type Attribute {get; set;}
        public Type Interface {get; set;}
        public Type Implementation {get; set;}
    }

    private readonly GeneratorType[] generatorTypes = new GeneratorType[]{
            new(){
                Attribute = typeof(SetEntityRemapperAttribute),
                Interface = typeof(IEntityRemapper<,>),
                Implementation = typeof(EntityRemapper<,>)
            }
        };


    public void Load(IServiceCollection services, IEnumerable<Type> assemblyTypes)
    {
        foreach (GeneratorType generatorType in this.generatorTypes)
        {
            if (typeof(ISetEntityRemapperAttribute).IsAssignableFrom(generatorType.Attribute))
            {
                foreach (System.Type assemblyType in assemblyTypes.Where(t => t.GetCustomAttribute(generatorType.Attribute) is not null))
                {
                    Attribute? attribute = assemblyType.GetCustomAttribute(generatorType.Attribute);

                    if (attribute is ISetEntityRemapperAttribute generatorInfo)
                    {
                        Type generatorInterface = generatorType.Interface.MakeGenericType(assemblyType, generatorInfo.MapToType);
                        Type generatorMapper = generatorType.Implementation.MakeGenericType(assemblyType, generatorInfo.MapToType);

                        services.AddSingleton(generatorInterface, generatorMapper);
                    }
                }
            }
        }
    }
}