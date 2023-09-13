
using System.Reflection;
using App.Core.Domain.Startup;

public class ConfigureServicesMiddleware
{
    public static void Invoke(IApplicationBuilder app, IWebHostEnvironment env)
    {
        Type startupConfigurationInterfaceType = typeof(IStartupConfigurator);
        Type[] assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
        foreach(Type assemblyType in assemblyTypes)
        {
            if(assemblyType.Equals(startupConfigurationInterfaceType)) continue;
            if(startupConfigurationInterfaceType.IsAssignableFrom(assemblyType))
            {
                if(Activator.CreateInstance(assemblyType) is IStartupConfigurator configurator)
                {
                    configurator.Configure(app, env);
                }
            }
        }
    }
}