using Microsoft.Extensions.Hosting;
using Stonksbot.GameModel;

namespace StonksBot;

internal class GameService : BackgroundService
{
    private readonly WorldInterface _game;
    
    private readonly WorldEventScheduler _eventScheduler;

    public GameService(WorldInterface game, WorldEventScheduler eventScheduler)
    {
        _game = game;
        _eventScheduler = eventScheduler;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }

}