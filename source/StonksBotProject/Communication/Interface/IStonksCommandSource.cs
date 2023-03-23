namespace StonksBotProject.Communication.Interface
{
    internal interface IStonksCommandSource
    {
        public event EventHandler<IStonksCommand> CommandReceived;
    }
}

