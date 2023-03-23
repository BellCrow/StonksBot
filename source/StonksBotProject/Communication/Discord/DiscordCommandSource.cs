using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Hosting;
using StonksBotProject.Communication.Interface;
using System.Text.RegularExpressions;

namespace StonksBotProject.Communication.Discord
{
    internal class DiscordCommandSource : IStonksCommandSource
    {
        #region Private Fields

        private readonly IHostApplicationLifetime _applicationLifetime;

        private DiscordClient _connection;

        private string _discordToken;

        #endregion Private Fields

        #region Public Constructors

        public DiscordCommandSource(IHostApplicationLifetime applicationLifetime)
        {
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
            _applicationLifetime.ApplicationStarted.Register(Connect);
            _applicationLifetime.ApplicationStopping.Register(Disconnect);
            //TODO move this to another place
            _discordToken = File.ReadAllText("discordToken.token");
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<IStonksCommand> CommandReceived;

        #endregion Public Events

        #region Private Methods

        private void Connect()
        {
            _connection = new DiscordClient(new DiscordConfiguration()
            {
                Token = _discordToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });
            _connection.ConnectAsync().GetAwaiter().GetResult();
            _connection.MessageCreated += DiscordMessageReceived;
        }

        private void Disconnect()
        {
            _connection.Dispose();
        }

        private Task DiscordMessageReceived(DiscordClient sender, MessageCreateEventArgs e)
        {
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

            if(e.Message.MessageType != MessageType.Default || !regexResult.Success)
            {
                return Task.CompletedTask;
            }

            //remove the discord specific encoding from the message
            string commandText = regexResult.Groups[2].Value;

            //TODO: rework the command creation so the
            //message author is automatically used
            //if the command requires a user
            CommandReceived?.Invoke(this, new DiscordStonksCommand(_connection, e.Channel, commandText));
            return Task.CompletedTask;
        }

        #endregion Private Methods
    }
}