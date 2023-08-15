using Stonksbot.Communication.Interface;

namespace Stonksbot.Communication.Console;

internal class ConsoleEventCommunicator : IEventCommunicator
{
    public void CommunicateEvent(string eventText)
    {
        System.Console.WriteLine($"Stonks event occured: {eventText}");
    }
}