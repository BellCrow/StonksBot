namespace StonksBotProject.CommandCommunication.Interface
{
    internal interface IStonksCommand
    {
        public string CommandText { get; }

        public void CommunicateResult(string result);
    }
}
