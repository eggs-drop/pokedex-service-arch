using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EggsDrop.Pokedex.Web
{
    /// <summary>
    /// Application start up class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create the host builder from defaults using <see cref="Startup"/>.
        /// See more information about the <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.1">.NET Generic Host</a>.
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
