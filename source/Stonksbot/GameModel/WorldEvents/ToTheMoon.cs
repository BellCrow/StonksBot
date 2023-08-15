using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel.WorldEvents;

public class ToTheMoon : IWorldEvent
{
    TimeSpan _frequency = TimeSpan.FromSeconds(20);

    DateTime _lastEventTick = DateTime.Now;

    public void Tick(BaseData baseData, IEventCommunicator eventCommunicator)
    {
        if(DateTime.Now - _lastEventTick > _frequency)
        {
            eventCommunicator.CommunicateEvent("TO THE MOOOOOOOOOOOON !");
            _lastEventTick = DateTime.Now;
        }
    }
}