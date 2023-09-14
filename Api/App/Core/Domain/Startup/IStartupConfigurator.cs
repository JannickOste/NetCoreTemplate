namespace App.Core.Domain.Startup;

/// <summary>
/// Represents an interface for configuring application startup.
/// </summary>
public interface IStartupConfigurator
{
    /// <summary>
    /// Configures the application during startup.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web host environment.</param>
    void Configure(IApplicationBuilder app, IWebHostEnvironment env);
}