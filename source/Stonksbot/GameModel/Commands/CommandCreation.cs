using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel.Commands;

public static class CommandCreation
{
    private const string TokenSeparator = " ";
    private static IEnumerable<string> Tokenize(string command)
    {
        return command.Split(TokenSeparator);
    }

    public static IStonksCommand Create(string commandText, ICommandResultCommunicator commandResultCommunicator)
    {
        if(string.IsNullOrWhiteSpace(commandText))
        {
            throw new ArgumentException("Empty command received");
        }
        var tokens = Tokenize(commandText);
        var command = tokens.First();
        var arguments = tokens.Skip(1).ToList();
        return SwitchCommand(command, arguments, commandResultCommunicator);
    }

    private static IStonksCommand SwitchCommand(string command, List<string> arguments, ICommandResultCommunicator commandResultCommunicator)
    {
        if(Buy.IsToken(command))
        {
            return new Buy(arguments,commandResultCommunicator);
        }
        throw new ArgumentException($"Unrecognized command encountered: {command}");
    }
}