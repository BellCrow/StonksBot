namespace StonksBotProject.CommandCommunication.Interface
{
    internal interface IStonksCommandSource
    {
        public event EventHandler<IStonksCommand> CommandReceived;
    }
}

