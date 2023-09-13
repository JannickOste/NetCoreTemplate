using System.Net;


/**
* @author: Oste Jannick
* @description: The main entry point of the .net core project were all server configuration takes place. 
* @Date: 2023-09-11
*/
await Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
    config => config
    .UseStartup<App.Core.Infrastructure.Startup.Startup>()
        .UseUrls("https://localhost:6001") // Change the port if needed
        .UseKestrel(options =>
        {
            options.Listen(IPAddress.Loopback, 6001, listenOptions =>
            {
                listenOptions.UseHttps(); // HTTPS
            });
        })
).Build().RunAsync();