namespace StonksBotProject.Communication.Interface
{
    internal interface IEventCommunicator
    {
        #region Public Methods

        void CommunicateEvent(string eventText);

        #endregion Public Methods
    }
}