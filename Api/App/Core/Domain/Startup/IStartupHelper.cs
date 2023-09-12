namespace App.Core.Domain.Startup; 

public interface IStartupHelper 
{
    void Load(IServiceCollection services, IEnumerable<Type> assemblyTypes);
}