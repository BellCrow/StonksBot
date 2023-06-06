using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Console
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