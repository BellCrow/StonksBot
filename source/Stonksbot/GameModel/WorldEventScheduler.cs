using Microsoft.Extensions.Hosting;
using Stonksbot.Communication.Interface;
using Stonksbot.GameModel.WorldEvents;

namespace Stonksbot.GameModel;

internal class WorldEventScheduler
{
    private readonly BaseData _baseData;

    private readonly IEventCommunicator _eventCommunicator;
    private readonly List<IWorldEvent> _worldEvents;
    private Timer? _eventTimer;

    public WorldEventScheduler(BaseData worldInterface, IEventCommunicator eventCommunicator, IHostApplicationLifetime applicationLifeTime)
    {
        _baseData = worldInterface ?? throw new ArgumentNullException(nameof(worldInterface));
        _eventCommunicator = eventCommunicator ?? throw new ArgumentNullException(nameof(eventCommunicator));

        _worldEvents = new List<IWorldEvent>(){
            new ToTheMoon(),
            new MarketCrash()
        };

        applicationLifeTime.ApplicationStarted.Register(OnApplicationStarted);
        applicationLifeTime.ApplicationStopping.Register(OnApplicationStopping);
    }

    private void OnApplicationStopping()
    {
        _eventTimer?.Dispose();
    }

    private void OnApplicationStarted()
    {
        //events have a chance to be triggered every second
        _eventTimer = new Timer(WorldEventTicker,null,1000,1000);
    }

    private void WorldEventTicker(object? state)
    {
        _worldEvents.ForEach(e => e.Tick(_baseData,_eventCommunicator));
    }
}