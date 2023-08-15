namespace Stonksbot.Communication.Interface;

public interface IStonksCommandSource
{
    public event EventHandler<IStonksCommand> CommandReceived;
}