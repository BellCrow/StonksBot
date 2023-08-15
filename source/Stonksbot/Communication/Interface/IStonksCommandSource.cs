namespace Stonksbot.Communication.Interface
{
    internal interface IStonksCommandSource
    {
        public event EventHandler<IStonksCommand> CommandReceived;

    }
}