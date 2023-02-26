using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StonksBotProject.CommandCommunication.Console;
using StonksBotProject.CommandCommunication.Discord;
using StonksBotProject.CommandCommunication.Interface;

namespace StonksBotProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<IStonksCommandSource, DiscordCommandSource>();
                services.AddSingleton<Game>();
                services.AddHostedService<GameService>();
            }).Build().Run();
        }
    }
}