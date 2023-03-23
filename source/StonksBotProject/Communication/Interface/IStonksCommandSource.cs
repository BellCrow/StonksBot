namespace StonksBotProject.Communication.Interface
{
    internal interface IStonksCommandSource
    {
        #region Public Events

        public event EventHandler<IStonksCommand> CommandReceived;

        #endregion Public Events
    }
}