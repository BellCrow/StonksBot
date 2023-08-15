using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stonksbot.Communication.Discord;
using Stonksbot.GameModel;
using Stonksbot.GameModel.PlayerClasses;
using Stonksbot.GameModel.CompanyClasses;
using StonksBot;

namespace Stonksbot;

internal class Program
{
    private static void Main(string[] args)
    {
        Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            DiscordIntegrationRegistration.Register(services);
            services.AddSingleton<Playerbase>();
            services.AddSingleton<Stockmarket>();
            services.AddSingleton<WorldEventScheduler>();
            services.AddSingleton<BaseData>();
            services.AddHostedService<GameService>();
        }).Build().Run();
    }
}