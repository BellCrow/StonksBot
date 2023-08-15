using Microsoft.Extensions.Hosting;
using Stonksbot.GameModel;

namespace StonksBot;

internal class GameService : BackgroundService
{
    private readonly BaseData _baseData;
    
    private readonly WorldEventScheduler _eventScheduler;

    public GameService(BaseData baseData, WorldEventScheduler eventScheduler)
    {
        _baseData = baseData;
        _eventScheduler = eventScheduler;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }

}