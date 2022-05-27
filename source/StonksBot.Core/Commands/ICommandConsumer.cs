namespace StonksBot.Core.Commands;

public interface ICommandConsumer
{
    void ConsumeCommand(Command command);
}