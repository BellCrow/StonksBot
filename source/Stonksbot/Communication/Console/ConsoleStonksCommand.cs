using Stonksbot.Communication.Interface;

namespace Stonksbot.Communication.Console
{
    internal class ConsoleStonksCommand : IStonksCommand
    {
        public ConsoleStonksCommand(string commandText)
        {
            CommandText = commandText;
        }

        public string CommandText { get; }

        public void CommunicateResult(string result)
        {
            System.Console.WriteLine(result);
        }
    }
}