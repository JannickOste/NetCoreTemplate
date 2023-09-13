using System.Reflection;

using App.Core.Domain.Database;
using App.Core.Domain.Startup;
using App.Core.Infrastructure.Database;

namespace App.Core.Infrastructure.Startup.Helpers.Generators;

public class LoadDbEntityRepositories : IStartupSetup
{
    public void Load(IServiceCollection services, IEnumerable<Type> assemblyTypes)
    {
        Type interfaceType = typeof(IDatabaseRepository<>);
        Type repositoryType = typeof(DatabaseRepository<>);
        
        foreach (Type entityType in assemblyTypes.Where(t => t.GetCustomAttribute<DbEntityAttribute>() is not null))
        {
            Type repositoryInterface = interfaceType.MakeGenericType(entityType);
            Type repositoryHandler   = repositoryType.MakeGenericType(entityType);

            services.AddScoped(interfaceType, repositoryType);
        }
    }
}