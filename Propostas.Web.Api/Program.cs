namespace Propostas.Web.Api
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Propostas.WebApi;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
