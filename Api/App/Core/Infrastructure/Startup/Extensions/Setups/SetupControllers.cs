using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;

namespace App.Core.Infrastructure.Startup.Helpers.Generators;

[StartupSetupOptions(priority: (byte)StartupPriorityLevel.Low)]
public class SetupControllers : IStartupSetup
{
    public void ConfigureService(IServiceCollection services, IEnumerable<Type> assemblyTypes)
    {
        services.AddControllers();
    }
}