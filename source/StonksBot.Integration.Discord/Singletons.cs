using Discord.WebSocket;
using StonksBot.Core;
using StonksBot.Core.Entities;

namespace StonksBot.Integration.Discord;

public static class Singletons
{
    public static Lazy<List<ShareHolder>> ShareholderLazy = new(() => new List<ShareHolder>
        { CreateShareHolder("Tim", 3000), CreateShareHolder("Debra", 5000) });

    public static Lazy<Market> MarketLazy =
        new(() => new Market(BrokerLazy.Value, ShareholderLazy.Value));

    public static Lazy<Broker> BrokerLazy = new(() => CreateBroker());

    private static ShareHolder CreateShareHolder(string name, int capital)
    {
        var shares = new List<Shares>();
        return new ShareHolder(name, new Portfolio(shares), capital);
    }


    private static Broker CreateBroker()
    {
        var marketShares = new List<Shares>();

        //Creation of test companies that have shares you can buy

        var tesla = new Company("Teslor", 20);
        var apple = new Company("Erpple", 18);
        var microsoft = new Company("Macrohard", 14);
        var tradedCompanies = new List<Company> { tesla, apple, microsoft };


        marketShares.Add(new Shares(tesla, 100));
        marketShares.Add(new Shares(apple, 200));
        marketShares.Add(new Shares(microsoft, 70));
        var marketPortFolio = new Portfolio(marketShares);
        return new Broker(marketPortFolio, tradedCompanies);
    }
}