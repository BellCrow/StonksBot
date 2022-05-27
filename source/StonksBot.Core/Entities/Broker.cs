namespace StonksBot.Core.Entities;

public class Broker
{
    public Broker(Portfolio portfolio, List<Company> tradedCompanies)
    {
        Portfolio = portfolio;
        TradedCompanies = tradedCompanies;
    }

    public Portfolio Portfolio { get; }
    public List<Company> TradedCompanies { get; }
}