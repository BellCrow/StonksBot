using Microsoft.Extensions.DependencyInjection;
using StonksBotProject.Communication.Console;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Discord
{
    internal static class DiscordIntegrationRegistration
    {
        #region Internal Methods

        internal static void Register(IServiceCollection registerInto)
        {
            registerInto.AddSingleton<IStonksCommandSource, ConsoleStonksCommandSource>();
            registerInto.AddSingleton<IEventCommunicator, ConsoleEventCommunicator>();
        }

        #endregion Internal Methods
    }
}