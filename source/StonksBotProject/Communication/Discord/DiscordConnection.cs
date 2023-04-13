using DSharpPlus;
using Microsoft.Extensions.Hosting;

namespace StonksBotProject.Communication.Discord
{
    public class DiscordConnection: IDiscordConnection
    {
        public DiscordClient Connection {get;private set;}

        public DiscordConnection(IHostApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStarted.Register(Connect);
            applicationLifetime.ApplicationStopping.Register(Disconnect);
        }

        private void Connect()
        {
            var pathToTokenFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"discordToken.token");
            var discordToken = File.ReadAllText(pathToTokenFile);
            Connection = new DiscordClient(new DiscordConfiguration()
            {
                Token = discordToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });
            Connection.ConnectAsync().GetAwaiter().GetResult();
        }

        private void Disconnect()
        {
            Connection.Dispose();
        }
    }
}