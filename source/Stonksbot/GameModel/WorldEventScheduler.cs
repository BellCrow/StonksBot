using Microsoft.Extensions.Hosting;
using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel;

internal class WorldEventScheduler
{
    private readonly WorldInterface _worldInterface;
    private readonly IEventCommunicator _eventCommunicator;

    private Timer? _eventTimer;

    public WorldEventScheduler(WorldInterface worldInterface, IEventCommunicator eventCommunicator, IHostApplicationLifetime applicationLifeTime)
    {
        _worldInterface = worldInterface ?? throw new ArgumentNullException(nameof(worldInterface));
        _eventCommunicator = eventCommunicator ?? throw new ArgumentNullException(nameof(eventCommunicator));
        applicationLifeTime.ApplicationStarted.Register(OnApplicationStarted);
        applicationLifeTime.ApplicationStopping.Register(OnApplicationStopping);
    }

    private void OnApplicationStopping()
    {
        _eventTimer?.Dispose();
    }

    private void OnApplicationStarted()
    {
        _eventTimer = new Timer(OnScheduleEvent,null,10000,10000);
    }

    private void OnScheduleEvent(object? state)
    {
        _eventCommunicator.CommunicateEvent("World event happened. Be scared !");
    }
}