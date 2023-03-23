using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Console
{
    internal class ConsoleStonksCommand : IStonksCommand
    {
        #region Public Constructors

        public ConsoleStonksCommand(string commandText)
        {
            CommandText = commandText;
        }

        #endregion Public Constructors

        #region Public Properties

        public string CommandText { get; }

        #endregion Public Properties

        #region Public Methods

        public void CommunicateResult(string result)
        {
            System.Console.WriteLine(result);
        }

        #endregion Public Methods
    }
}