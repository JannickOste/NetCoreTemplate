using System.Reflection;
using App.Core.Domain.Startup;
using App.Core.Domain.Database;
using App.Core.Infrastructure.Database;

namespace App.Core.Infrastructure.Startup.Helpers.Generators
{
    /// <summary>
    /// Utility class for dynamically loading and registering database entity repositories during startup.
    /// </summary>
    public class SetupDatabaseEntities : IStartupSetup
    {
        /// <summary>
        /// Load and register database entity repositories in the DI container.
        /// </summary>
        /// <param name="services">The IServiceCollection to register services with.</param>
        /// <param name="assemblyTypes">The types to scan for entities with the [DbEntity] attribute.</param>
        public void ConfigureService(IServiceCollection services, IEnumerable<Type> assemblyTypes)
        {
            services.AddDbContext<DatabaseContext>();

            Type interfaceType = typeof(IDatabaseRepository<>);
            Type repositoryType = typeof(DatabaseRepository<>);

            foreach (Type entityType in assemblyTypes.Where(t => t.GetCustomAttribute<DbEntityAttribute>() is not null))
            {
                Type repositoryInterface = interfaceType.MakeGenericType(entityType);
                Type repositoryHandler = repositoryType.MakeGenericType(entityType);

                services.AddScoped(interfaceType, repositoryType);
            }
        }
    }
}
