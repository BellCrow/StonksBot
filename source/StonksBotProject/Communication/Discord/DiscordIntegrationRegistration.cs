using Microsoft.Extensions.DependencyInjection;
using StonksBotProject.Communication.Console;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Discord
{
    static internal class DiscordIntegrationRegistration
    {
        internal static void Register(IServiceCollection registerInto)
        {
            registerInto.AddSingleton<IStonksCommandSource, ConsoleStonksCommandSource>();
            registerInto.AddSingleton<IEventCommunicator, ConsoleEventCommunicator>();
        }
    }
}
