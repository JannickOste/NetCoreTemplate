using System.Net;


await Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
    config => config
    .UseStartup<App.Core.Infrastructure.Startup.Startup>()
        .UseKestrel(options =>
        {
            options.Listen(IPAddress.Loopback, 80);
        })
).Build().RunAsync();