using Microsoft.Extensions.DependencyInjection;
using StonksBotProject.Communication.Console;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Console;

public static class ConsoleIntegrationRegistration
{
    public static void Register(IServiceCollection registerInto)
    {
        registerInto.AddSingleton<IStonksCommandSource, ConsoleStonksCommandSource>();
        registerInto.AddSingleton<IEventCommunicator, ConsoleEventCommunicator>();
    }
}