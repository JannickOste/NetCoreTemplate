using System.Reflection;
using App.Core.Domain.Startup;

/// <summary>
/// Middleware class responsible for invoking setup methods for services during startup.
/// </summary>
public class SetupServicesMiddleware 
{
    /// <summary>
    /// Invokes setup methods for services registered in the DI container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to configure services.</param>
    public static void Invoke(IServiceCollection services)
    {
        Type startupHelperInterfaceType = typeof(IStartupSetup);
        Type[] assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
        
        foreach(Type assemblyType in assemblyTypes)
        {
            if(assemblyType.Equals(startupHelperInterfaceType)) continue;
            if(startupHelperInterfaceType.IsAssignableFrom(assemblyType))
            {
                
                IStartupSetup? helper = Activator.CreateInstance(assemblyType) as IStartupSetup;
                if(helper is not null)
                {
                    helper.Load(services, assemblyTypes);
                }
            }
        }
    }
}
