using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Console
{
    internal class ConsoleEventCommunicator : IEventCommunicator
    {
        public void CommunicateEvent(string eventText)
        {
            System.Console.WriteLine($"Stonks event occured: {eventText}");
        }
    }
}