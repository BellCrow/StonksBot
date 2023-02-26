using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using StonksBotProject.CommandCommunication.Interface;

namespace StonksBotProject.CommandCommunication.Discord
{
    internal class DiscordStonksCommand : IStonksCommand
    {
        private readonly MessageCreateEventArgs _messageEventArgs;
        private DiscordClient _connection;
        private DiscordChannel _channel;

        public DiscordStonksCommand(DiscordClient connection, DiscordChannel channel, string commandText)
        {
            _connection = connection;
            _channel = channel;
            CommandText = commandText;
        }

        public string CommandText { get; }

        public void CommunicateResult(string result)
        {            
            _connection.SendMessageAsync(_channel, result);
        }
    }
}
