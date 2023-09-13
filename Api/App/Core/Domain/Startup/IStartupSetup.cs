namespace App.Core.Domain.Startup; 

public interface IStartupSetup 
{
    void Load(IServiceCollection services, IEnumerable<Type> assemblyTypes);
}