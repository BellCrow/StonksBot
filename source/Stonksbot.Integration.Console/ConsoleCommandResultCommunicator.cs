using StonksBot.Core.Commands;

namespace Stonksbot.Integration.Console;

public class ConsoleCommandResultCommunicator : ICommandResultCommunicator
{
    public void CommunicateCommandResultSuccess()
    {
        System.Console.WriteLine("Successfully executed command");
    }

    public void CommunicateCommandResultFail(string reason)
    {
        System.Console.WriteLine($"Error executing command: {reason}");
    }
}