namespace StonksBot.Core;

public class ShareHolder
{
    public ShareHolder(string identifier, Portfolio portfolio, int capital)
    {
        Identifier = identifier;
        Portfolio = portfolio;
        Money = capital;
    }

    public string Identifier { get; }
    public Portfolio Portfolio { get; }

    public int Money { get; set; }
}