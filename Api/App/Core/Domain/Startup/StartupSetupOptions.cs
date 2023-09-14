namespace App.Core.Domain.Startup; 

/// <summary>
/// Attribute class for specifying startup setup options.
/// </summary>
public class StartupSetupOptions : Attribute  
{
    /// <summary>
    /// Gets a value indicating whether the startup setup is enabled.
    /// </summary>
    public bool Enabled { get; }

    /// <summary>
    /// Gets the priority of the startup setup. Lower values indicate higher priority.
    /// </summary>
    public int Priority { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StartupSetupOptions"/> class.
    /// </summary>
    /// <param name="enabled">Whether the startup setup is enabled. (Default is true)</param>
    /// <param name="priority">The priority of the startup setup. Lower values indicate higher priority. (Default is 100)</param>
    public StartupSetupOptions(bool enabled = true, int priority = 100)
    {
        Enabled = enabled;
        Priority = priority;
    }
}