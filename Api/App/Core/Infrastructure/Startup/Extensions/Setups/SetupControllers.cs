using App.Core.Domain.Startup;

namespace App.Core.Infrastructure.Startup.Helpers.Generators;
public class SetupControllers : IStartupSetup
{
    public void ConfigureService(IServiceCollection services, IEnumerable<Type> assemblyTypes)
    {
        services.AddControllers();
    }
}