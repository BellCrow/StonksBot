using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StonksBotProject.Communication.Discord;
using StonksBotProject.GameModel;

namespace StonksBotProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                DiscordIntegrationRegistration.Register(services);
                
                services.AddSingleton<WorldEventScheduler>();
                services.AddSingleton<WorldInterface>();
                services.AddHostedService<GameService>();

            }).Build().Run();
        }
    }
}