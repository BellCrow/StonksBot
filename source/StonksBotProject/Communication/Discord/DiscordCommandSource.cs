using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Hosting;
using StonksBotProject.Communication.Interface;
using System.Text.RegularExpressions;

namespace StonksBotProject.Communication.Discord
{
    internal class DiscordCommandSource : IStonksCommandSource
    {
        #region Public Constructors
        private readonly IDiscordConnection _discordConnection;

        public DiscordCommandSource(IHostApplicationLifetime applicationLifetime, IDiscordConnection discordConnection)
        {
            _discordConnection = discordConnection ?? throw new ArgumentNullException(nameof(discordConnection));
            applicationLifetime.ApplicationStopping.Register(OnApplicationShuttingDown);
            discordConnection.MessageReceived += DiscordMessageReceived;
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<IStonksCommand>? CommandReceived;

        #endregion Public Events

        #region Private Methods

        private void OnApplicationShuttingDown()
        {
            _discordConnection.MessageReceived -= DiscordMessageReceived;
        }

        private void DiscordMessageReceived(object? sender, MessageCreateEventArgs e)
        {
            if(sender is not IDiscordConnection senderConnection)
            {
                throw new ArgumentException("Send object to discrod message received handler, that is not a discord connection");
            }
            /*
             * A message for the stonks bot from discord has to
             * start with "stonks " (note the extra space at the end).
             * This limitation is set, so that the bot does not try to
             * parse every message as a command and people can still
             * talk in the channel.
             */
            var discordCommandRegex = @"^(stonks )(.+)";
            var regex = new Regex(discordCommandRegex);
            var regexResult = regex.Match(e.Message.Content);

            if (e.Message.MessageType != MessageType.Default || !regexResult.Success)
            {
                return;
            }

            //remove the discord specific encoding from the message
            string commandText = regexResult.Groups[2].Value;

            //TODO: rework the command creation so the
            //message author is automatically used
            //if the command requires a user
            CommandReceived?.Invoke(this, new DiscordStonksCommand(_discordConnection, commandText));
        }

        #endregion Private Methods
    }
}