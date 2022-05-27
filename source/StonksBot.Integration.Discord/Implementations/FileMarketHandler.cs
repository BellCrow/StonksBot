using System.Text.Json;
using StonksBot.Core.Entities;
using StonksBot.Integration.Discord.Interfaces;

namespace StonksBot.Integration.Discord.Implementations;

public class FileMarketHandler : IMarketHandler
{
    private readonly DiscordIntegrationConfiguration _configuration;
    private readonly Lazy<Market> _market;

    public FileMarketHandler(DiscordIntegrationConfiguration configuration)
    {
        _configuration = configuration;
        _market = new Lazy<Market>(CreateMarketFromFile);
    }

    public Market GetMarket()
    {
        return _market.Value;
    }

    private Market CreateMarketFromFile()
    {
        var saveFileString = File.ReadAllText(_configuration.SaveGamePath);
        var market = JsonSerializer.Deserialize<Market>(saveFileString);
        return market;
    }
}