using System.Reflection;
using App.Core.Domain.Startup;

/// <summary>
/// Middleware class responsible for invoking startup configuration methods.
/// </summary>
public class ConfigureServicesMiddleware
{
    private struct ConfigureServiceInformation
    {
        public Type classType;
        public StartupSetupOptions? startupSetupOptions;
    }

    private static IEnumerable<ConfigureServiceInformation> ConfigureServices
    {
        get => Assembly.GetExecutingAssembly().GetTypes()
                                              .Where(t => typeof(IStartupConfigurator).IsAssignableFrom(t)
                                                            && !t.Equals(typeof(IStartupConfigurator)))
                                              .Select(t => new ConfigureServiceInformation()
                                              {
                                                  classType = t,
                                                  startupSetupOptions = t.GetCustomAttribute<StartupSetupOptions>()
                                              })
                                              .OrderByDescending(info => info.startupSetupOptions?.Priority ?? 0);
    }

    /// <summary>
    /// Invokes startup configuration methods for registered startup configurators.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    public static void Invoke(IApplicationBuilder app, IWebHostEnvironment env)
    {
        foreach (ConfigureServiceInformation info in ConfigureServices)
        {
            if (!info.startupSetupOptions?.Enabled ?? false) continue;
            
            if (Activator.CreateInstance(info.classType) is IStartupConfigurator configurator)
            {
                configurator.Configure(app, env);
            }
        }
    }
}
