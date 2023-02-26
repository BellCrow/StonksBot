using StonksBotProject.CommandCommunication.Interface;

namespace StonksBotProject.CommandCommunication.Console
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
