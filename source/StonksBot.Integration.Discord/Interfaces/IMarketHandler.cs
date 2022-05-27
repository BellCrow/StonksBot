using StonksBot.Core.Entities;

namespace StonksBot.Integration.Discord.Interfaces;

public interface IMarketHandler
{
    Market GetMarket();
}