namespace StonksBotProject.Communication.Interface
{
    internal interface IStonksCommand
    {
        #region Public Properties

        public string CommandText { get; }

        #endregion Public Properties

        #region Public Methods

        public void CommunicateResult(string result);

        #endregion Public Methods
    }
}