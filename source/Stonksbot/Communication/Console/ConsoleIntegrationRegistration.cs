using Microsoft.Extensions.DependencyInjection;
using Stonksbot.Communication.Console;
using Stonksbot.Communication.Interface;

namespace Stonksbot.Communication.Console;

public static class ConsoleIntegrationRegistration
{
    public static void Register(IServiceCollection registerInto)
    {
        registerInto.AddSingleton<IStonksCommandSource, ConsoleStonksCommandSource>();
        registerInto.AddSingleton<IEventCommunicator, ConsoleEventCommunicator>();
    }
}