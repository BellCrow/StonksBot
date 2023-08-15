using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel.WorldEvents;

internal interface IWorldEvent
{
    void Tick(BaseData baseData, IEventCommunicator eventCommunicator);
}