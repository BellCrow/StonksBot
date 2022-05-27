using System.Threading.Tasks.Dataflow;
using Discord.WebSocket;
using StonksBot.Integration.Discord.Interfaces;

namespace StonksBot.Integration.Discord;

public class DiscordMessageQueue
{
    private readonly BufferBlock<SocketMessage> _discordMessages = new();
    private readonly ILogger _logger;
    private readonly DiscordMessageFilter _discordMessageFilter;

    public DiscordMessageQueue(ILogger logger, DiscordMessageFilter discordMessageFilter)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _discordMessageFilter = discordMessageFilter ?? throw new ArgumentNullException(nameof(discordMessageFilter));
    }

    public event EventHandler<SocketMessage> ConsumeDiscordMessage;

    public void Enqueue(SocketMessage message)
    {
        if (message is SocketUserMessage castMessage && _discordMessageFilter.IsMessageStonksCommand(castMessage))
        {
            _discordMessages.Post(castMessage);
        }
    }

    public async Task StartWorker(CancellationToken cancellationToken)
    {
        _logger.Info("Started message consumer");
        while (await _discordMessages.OutputAvailableAsync(cancellationToken) && !cancellationToken.IsCancellationRequested)
        {
            var message = _discordMessages.Receive();
            ConsumeDiscordMessage?.Invoke(this, message);
        }
        _logger.Info("Shutting down message consumer");
    }
}