using DSharpPlus;
using DSharpPlus.EventArgs;

namespace StonksBotProject.Communication.Discord
{
    internal interface IDiscordConnection
    {
        void SendMessage(string message);

        event EventHandler<MessageCreateEventArgs> MessageReceived;
        
    }
}