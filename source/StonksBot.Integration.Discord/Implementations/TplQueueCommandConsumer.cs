using System.Threading.Tasks.Dataflow;
using StonksBot.Core;
using StonksBot.Core.Commands;
using StonksBot.Core.Entities;

namespace StonksBot.Integration.Discord.Implementations;

public class TplQueueCommandConsumer : ICommandConsumer
{
    private readonly BufferBlock<Command> _gameCommandBuffer = new(new DataflowBlockOptions { EnsureOrdered = true });
    private readonly Market _market;

    public TplQueueCommandConsumer(Market market)
    {
        _market = market;
    }

    public void ConsumeCommand(Command command)
    {
        _gameCommandBuffer.Post(command);
    }

    public async Task StartConsumer()
    {
        Console.WriteLine("Started message consumer");
        while (await _gameCommandBuffer.OutputAvailableAsync())
        {
            var command = _gameCommandBuffer.Receive();
            _market.ExecuteCommand(command);
        }
    }
}