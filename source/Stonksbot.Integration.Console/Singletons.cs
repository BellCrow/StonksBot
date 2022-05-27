using StonksBot.Core;
using StonksBot.Core.Entities;

namespace Stonksbot.Integration.Console;

public static class Singletons
{
    public static Lazy<List<ShareHolder>> ShareholderLazy = new(() => new List<ShareHolder>
        { CreateShareHolder("Tim", 3000), CreateShareHolder("Debra", 5000) });

    public static Lazy<Market> GameComposerLazy =
        new(() => new Market(MarketLazy.Value, ShareholderLazy.Value));

    public static Lazy<Broker> MarketLazy = new(() => CreateMarket());

    private static ShareHolder CreateShareHolder(string name, int capital)
    {
        var shares = new List<Shares>();
        return new ShareHolder(name, new Portfolio(shares), capital);
    }


    private static Broker CreateMarket()
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