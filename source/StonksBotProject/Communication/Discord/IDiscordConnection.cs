using DSharpPlus;

namespace StonksBotProject.Communication.Discord
{
    public interface IDiscordConnection
    {
        public DiscordClient Connection {get;}
        
    }
}