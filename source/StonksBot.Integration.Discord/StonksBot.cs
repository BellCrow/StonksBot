using StonksBot.Integration.Discord.Interfaces;

namespace StonksBot.Integration.Discord;

public class StonksBot
{
    private readonly DiscordConnectionHandler _connectionHandler;
    private readonly ILogger _logger;

    public StonksBot(ILogger logger, DiscordConnectionHandler connectionHandler)
    {
        _logger = logger;
        _connectionHandler = connectionHandler;
    }

    public async Task Run()
    {
        await Task.Delay(-1);
    }
}