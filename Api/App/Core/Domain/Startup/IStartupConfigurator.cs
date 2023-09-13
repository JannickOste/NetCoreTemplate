namespace App.Core.Domain.Startup;

public interface IStartupConfigurator 
{
    void Configure(IApplicationBuilder app, IWebHostEnvironment env);
}