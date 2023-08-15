using Stonksbot.Communication.Interface;

namespace Stonksbot.Communication.Console;

public class ConsoleCommandResultCommunicator : ICommandResultCommunicator
{
    public void CommunicateResult(string result)
    {
        System.Console.WriteLine(result);
    }
}