namespace StonksBot.Core;

public class Market
{
    public Market(Portfolio marketPortFolio, List<Company> tradedCompanies)
    {
        Portfolio = marketPortFolio;
        TradedCompanies = tradedCompanies;
    }

    public Portfolio Portfolio { get; }
    public List<Company> TradedCompanies { get; }
}