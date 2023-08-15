using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel.WorldEvents;

internal interface IWorldEvent
{
    void Tick(WorldInterface worldInterface, IEventCommunicator eventCommunicator);
}