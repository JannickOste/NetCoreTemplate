using System.Reflection;
using App.Core.Domain.Startup;

/// <summary>
/// Middleware class responsible for invoking startup configuration methods.
/// </summary>
public class ConfigureServicesMiddleware
{
    /// <summary>
    /// Invokes startup configuration methods for registered startup configurators.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    public static void Invoke(IApplicationBuilder app, IWebHostEnvironment env)
    {
        Type startupConfigurationInterfaceType = typeof(IStartupConfigurator);
        Type[] assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

        foreach (Type assemblyType in assemblyTypes)
        {
            if (assemblyType.Equals(startupConfigurationInterfaceType)) continue;
            if (startupConfigurationInterfaceType.IsAssignableFrom(assemblyType))
            {
                if (Activator.CreateInstance(assemblyType) is IStartupConfigurator configurator)
                {
                    configurator.Configure(app, env);
                }
            }
        }
    }
}
