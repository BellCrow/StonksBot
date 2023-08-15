using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Hosting;

namespace Stonksbot.Communication.Discord;

public class DiscordConnection: IDiscordConnection
{
    private DiscordClient? _connection;

    private DiscordChannel? _communicationChannel;

    public DiscordConnection(IHostApplicationLifetime applicationLifetime)
    {
        applicationLifetime.ApplicationStarted.Register(Connect);
        applicationLifetime.ApplicationStopping.Register(Disconnect);
    }

    public event EventHandler<MessageCreateEventArgs>? MessageReceived;

    private void Connect()
    {
        var pathToTokenFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "discord.token");
        var discordToken = File.ReadLines(pathToTokenFile).First();
        _connection = new DiscordClient(new DiscordConfiguration()
        {
            Token = discordToken,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
        });
        _connection.ConnectAsync().GetAwaiter().GetResult();

        //for now this id is static for the channel on my test server
        const ulong eventCommunicationChannelId = 939828414704132176;
        _communicationChannel = _connection.GetChannelAsync(eventCommunicationChannelId).GetAwaiter().GetResult();

        _connection.MessageCreated += OnMessageReceived;
    }

    private Task OnMessageReceived(DiscordClient sender, MessageCreateEventArgs e)
    {
        return Task.Run(() => MessageReceived?.Invoke(this,e));
    }

    private void Disconnect()
    {
        _connection?.Dispose();
    }

    public void SendMessage(string message)
    {
        _connection?.SendMessageAsync(_communicationChannel,message).GetAwaiter().GetResult();
    }
}