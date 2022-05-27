using StonksBot.Core.Entities;

namespace StonksBot.Core.Commands;

public class InstantCommandConsumer : ICommandConsumer
{
    private readonly Market _market;

    public InstantCommandConsumer(Market market)
    {
        _market = market;
    }

    public void ConsumeCommand(Command command)
    {
        _market.ExecuteCommand(command);
    }
}