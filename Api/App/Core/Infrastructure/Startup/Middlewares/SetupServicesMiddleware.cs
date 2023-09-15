using System.Reflection;
using App.Core.Domain.Startup;
using App.Core.Domain.Startup.Attributes;

/// <summary>
/// Middleware class responsible for invoking setup methods for services during startup.
/// </summary>
public class SetupServicesMiddleware
{
    private struct SetupServiceInformation 
    {
        public Type classType;
        public StartupSetupOptions? startupSetupOptions;
    }

    private static IEnumerable<SetupServiceInformation> SetupServices {
        get => Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => typeof(IStartupSetup).IsAssignableFrom(t) && !t.Equals(typeof(IStartupSetup)))
                    .Select(t => new SetupServiceInformation(){
                        classType = t,
                        startupSetupOptions = t.GetCustomAttribute<StartupSetupOptions>()
                    })
                    .OrderByDescending(info => info.startupSetupOptions?.Priority ?? (byte)StartupPriorityLevel.Low);

    }

    /// <summary>
    /// Invokes setup methods for services registered in the DI container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to configure services.</param>
    public static void Invoke(IServiceCollection services)
    {
        IEnumerable<System.Type> assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

        foreach (SetupServiceInformation info in SetupServices)
        {
            if (!info.startupSetupOptions?.Enabled ?? false) continue;
            
            if (Activator.CreateInstance(info.classType) is IStartupSetup helper)
            {
                helper.ConfigureService(services, assemblyTypes);
            }
        }
    }
}
