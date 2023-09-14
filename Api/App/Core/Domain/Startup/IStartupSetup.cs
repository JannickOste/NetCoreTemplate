namespace App.Core.Domain.Startup;

/// <summary>
/// Represents an interface for setting up services and configurations during application startup.
/// </summary>
public interface IStartupSetup
{
    /// <summary>
    /// Loads and configures services based on the provided <see cref="IServiceCollection"/> and assembly types.
    /// </summary>
    /// <param name="services">The service collection to configure services.</param>
    /// <param name="assemblyTypes">The types from the assembly to be used for setup.</param>
    void Load(IServiceCollection services, IEnumerable<Type> assemblyTypes);
}