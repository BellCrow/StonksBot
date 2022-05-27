using Discord;
using Discord.WebSocket;
using StonksBot.Integration.Discord.Interfaces;

namespace StonksBot.Integration.Discord;

public class DiscordConnectionHandler //TODO does this need an interface ? 
{
    private readonly DiscordSocketClient _discordSocketClient;
    private readonly ILogger _logger;

    public DiscordConnectionHandler(DiscordIntegrationConfiguration configuration, ILogger logger)
    {
        _discordSocketClient = new DiscordSocketClient();
        _discordSocketClient.Log += OnDiscordLog;
        _logger = logger;
        try
        {
            _discordSocketClient.LoginAsync(TokenType.Bot, configuration.ApiToken).GetAwaiter().GetResult();
            _discordSocketClient.StartAsync().GetAwaiter().GetResult();

            logger.Info("Bot is connected !");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            throw;
        }

        _discordSocketClient.MessageReceived += OnDiscordSocketMessageReceived;
    }

    public event EventHandler<SocketUserMessage>? MessageReceived;

    private Task OnDiscordLog(LogMessage arg)
    {
        switch (arg.Severity)
        {
            case LogSeverity.Critical:
                _logger.Error(arg.Message);
                break;
            case LogSeverity.Error:
                _logger.Error(arg.Message);
                break;
            case LogSeverity.Warning:
                _logger.Warning(arg.Message);
                break;
            case LogSeverity.Info:
                _logger.Info(arg.Message);
                break;
            case LogSeverity.Verbose:
                _logger.Info(arg.Message);
                break;
            case LogSeverity.Debug:
                _logger.Debug(arg.Message);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return Task.CompletedTask;
    }

    private Task OnDiscordSocketMessageReceived(SocketMessage arg)
    {
        if (arg is SocketUserMessage socketUserMessage)
        {
            MessageReceived?.Invoke(this, socketUserMessage);
        }

        return Task.CompletedTask;
    }
}