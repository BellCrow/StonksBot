// See https://aka.ms/new-console-template for more information

using StonksBot.Core.Commands;

namespace Stonksbot.Integration.Console;

public class MainClass
{
    public static void Main(string[] args)
    {
        var commandParser = CreateCommandParser();
        var commandConsumer = CreateCommandConsumer();
        var commandText = string.Empty;
        var consoleResultCommunicator = new ConsoleCommandResultCommunicator();

        var exitCommand = "exit";
        while (commandText != exitCommand)
        {
            commandText = System.Console.ReadLine();
            if (string.IsNullOrEmpty(commandText) || commandText == exitCommand) continue;

            try
            {
                var command = commandParser.TranslateCommandString(commandText, new ConsoleCommandResultCommunicator());
                commandConsumer.ConsumeCommand(command);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }
    }

    private static CommandParser CreateCommandParser()
    {
        return new CommandParser(Singletons.GameComposerLazy.Value);
    }


    private static ICommandConsumer CreateCommandConsumer()
    {
        var commandConsumer = new InstantCommandConsumer(Singletons.GameComposerLazy.Value);
        return commandConsumer;
    }
}