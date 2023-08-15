using DSharpPlus;
using DSharpPlus.EventArgs;

namespace Stonksbot.Communication.Discord
{
    internal interface IDiscordConnection
    {
        void SendMessage(string message);

        event EventHandler<MessageCreateEventArgs> MessageReceived;
        
    }
}