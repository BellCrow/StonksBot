using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel.WorldEvents;

public class MarketCrash : IWorldEvent
{
    private DateTime _lastEventTick;

    TimeSpan _frequency = TimeSpan.FromSeconds(15);

    public void Tick(BaseData baseData, IEventCommunicator eventCommunicator)
    {
        if(DateTime.Now - _lastEventTick > _frequency)
        {
            eventCommunicator.CommunicateEvent("Market has crashed. People in suits most affected");
            _lastEventTick = DateTime.Now;
        }
    }
}