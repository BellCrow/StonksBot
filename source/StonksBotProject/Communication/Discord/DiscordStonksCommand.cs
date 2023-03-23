using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Discord
{
    internal class DiscordStonksCommand : IStonksCommand
    {
        #region Private Fields

        private readonly MessageCreateEventArgs _messageEventArgs;
        private DiscordChannel _channel;
        private DiscordClient _connection;

        #endregion Private Fields

        #region Public Constructors

        public DiscordStonksCommand(DiscordClient connection, DiscordChannel channel, string commandText)
        {
            _connection = connection;
            _channel = channel;
            CommandText = commandText;
        }

        #endregion Public Constructors

        #region Public Properties

        public string CommandText { get; }

        #endregion Public Properties

        #region Public Methods

        public void CommunicateResult(string result)
        {
            _connection.SendMessageAsync(_channel, result);
        }

        #endregion Public Methods
    }
}