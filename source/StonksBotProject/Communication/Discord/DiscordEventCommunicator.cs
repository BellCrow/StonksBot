using DSharpPlus.Entities;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Discord
{
    public class DiscordEventCommunicator : IEventCommunicator
    {
        private readonly IDiscordConnection _discordConnection;
        
        DiscordChannel _eventCommunicationChannel;
        
        public DiscordEventCommunicator(IDiscordConnection discordConnection)
        {
            _discordConnection = discordConnection;
            //for now this id is static for the channel on my test server
            ulong eventCommunicationChannelId = 939828414704132176;
            _eventCommunicationChannel = _discordConnection.Connection.GetChannelAsync(eventCommunicationChannelId).GetAwaiter().GetResult();
        }
        public void CommunicateEvent(string eventText)
        {
            _discordConnection.Connection.SendMessageAsync(_eventCommunicationChannel,eventText).GetAwaiter().GetResult();
        }
    }
}