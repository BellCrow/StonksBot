// See https://aka.ms/new-console-template for more information


using DryIoc;
using StonksBot.Core.Commands;
using StonksBot.Integration.Discord.Implementations;
using StonksBot.Integration.Discord.Interfaces;

namespace StonksBot.Integration.Discord;

public class MainClass
{
    private static ICommandParser _commandParser;

    private static ICommandConsumer _commandConsumer;


    //tutorial for this code is here https://discordnet.dev/guides/getting_started/first-bot.html
    public static async Task Main(string[] args)
    {
        var container = new Container();
        RegisterTypes(container);

        _commandParser = new CommandParser(Singletons.MarketLazy.Value);

        var tplConsumer = new TplQueueCommandConsumer(Singletons.MarketLazy.Value);
        tplConsumer.StartConsumer();
        _commandConsumer = tplConsumer;

        await Task.Delay(-1);
    }

    public static void RegisterTypes(IRegistrator registrator)
    {
        registrator.Register<ApplicationShutdown>(Reuse.Singleton);
        registrator.Register<ILogger, ConsoleLogger>(Reuse.Singleton);
        registrator.Register<DiscordIntegrationConfiguration>(Reuse.Singleton);
        registrator.Register<DiscordConnectionHandler>(Reuse.Singleton);
        registrator.Register<IMarketHandler, FileMarketHandler>(Reuse.Singleton);
        registrator.Register<DiscordMessageQueue>(Reuse.Singleton,
            Made.Of(() => CreateDiscordMessageQueue(Arg.Of<ApplicationShutdown>(), Arg.Of<ILogger>())));
        
    }

    private static DiscordMessageQueue CreateDiscordMessageQueue(ApplicationShutdown applicationShutdown, ILogger logger)
    {
        var queue = new DiscordMessageQueue(logger);
        queue.StartWorker(applicationShutdown.ApplicationShutdownToken);
        return queue;
    }

    // private static Task MessageReceived(SocketMessage arg)
    // {
    //     var message = arg as SocketUserMessage;
    //     Console.WriteLine($"Bot received message: {message}");
    //     var stonksCommandString = @"stonks";
    //     if (!arg.ToString().StartsWith(stonksCommandString)) return Task.CompletedTask;
    //
    //     var commandString = new string(message.Content.Skip(stonksCommandString.Length).ToArray());
    //     var command = _commandParser.TranslateCommandString(commandString,
    //         new DiscordCommandResultCommunicator(_discordSocketClient, message));
    //     _commandConsumer.ConsumeCommand(command);
    //     return Task.CompletedTask;
    // }
}