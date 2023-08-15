using Microsoft.Extensions.DependencyInjection;
using Stonksbot.Communication.Interface;

namespace Stonksbot.Communication.Discord;

internal static class DiscordIntegrationRegistration
{
    internal static void Register(IServiceCollection registerInto)
    {
        registerInto.AddSingleton<IDiscordConnection, DiscordConnection>();
        registerInto.AddSingleton<IStonksCommandSource, DiscordCommandSource>();
        registerInto.AddSingleton<IEventCommunicator, DiscordEventCommunicator>();
    }

}