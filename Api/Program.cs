using MinimalApi;

var builder = WebApplication.CreateBuilder(args);

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
       webBuilder.UseStartUp<Startup>(); 
    });
}

CreateHostBuilder(args).Build().Run();