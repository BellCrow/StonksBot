using Microsoft.Extensions.DependencyInjection;
using StonksBotProject.Communication.Console;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Discord
{
    internal static class DiscordIntegrationRegistration
    {
        internal static void Register(IServiceCollection registerInto)
        {
            registerInto.AddSingleton<IDiscordConnection, DiscordConnection>();
            registerInto.AddSingleton<IStonksCommandSource, DiscordCommandSource>();
            registerInto.AddSingleton<IEventCommunicator, DiscordEventCommunicator>();
        }

    }
}