
using System.Reflection;
using App.Core.Domain.Startup;

public class SetupServicesMiddleware 
{
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