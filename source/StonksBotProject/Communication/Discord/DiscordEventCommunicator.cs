using DSharpPlus.Entities;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Discord
{
    internal class DiscordEventCommunicator : IEventCommunicator
    {
        private readonly IDiscordConnection _discordConnection;

        public DiscordEventCommunicator(IDiscordConnection discordConnection)
        {
            _discordConnection = discordConnection ?? throw new ArgumentNullException(nameof(discordConnection));
            
        }
        public void CommunicateEvent(string eventText)
        {
            _discordConnection.SendMessage(eventText);
        }
    }
}