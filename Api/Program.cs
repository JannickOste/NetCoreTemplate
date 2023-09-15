using System.Net;


await Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
    config => config
    .UseStartup<App.Core.Infrastructure.Startup.Startup>()
).Build().RunAsync();