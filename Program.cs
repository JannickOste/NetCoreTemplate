/**
* @author: Oste Jannick
* @description: The main entry point of the .net core project were all server configuration takes place. 
* @Date: 2023-09-11
*/
await Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
    config => config.UseStartup<NetCore.Infrastructure.Startup>()
).Build().RunAsync();