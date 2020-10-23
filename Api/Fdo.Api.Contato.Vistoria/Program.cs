using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Fdo.Api.Contato.Vistoria
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5000", "https://*:5001")
                .UseKestrel()
                .Build();
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
