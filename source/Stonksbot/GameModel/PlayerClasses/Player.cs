using Stonksbot.GameModel.CompanyClasses;
namespace Stonksbot.GameModel.PlayerClasses;

public class Player
{
    private readonly List<(Company company, int amount)> _stocks = new();

    public Player(string identifier, int initialMoney)
    {
        Identifier = identifier;
        Money = initialMoney;
    }

    public string Identifier { get; }

    public int Money { get; }

    public IReadOnlyList<(Company company, int amount)> Stocks => _stocks;

    public void AddStock(Company company, int amount)
    {
        var alreadyOwnedStockCount = 0;
        if(_stocks.Any(s => s.company == company))
        {
            alreadyOwnedStockCount = Stocks.First(s => s.company == company).amount;
            _stocks.RemoveAll(t => t.company == company);
        }
        _stocks.Add((company, alreadyOwnedStockCount + amount));
    }

    public void SubtractStock(Company company, int amount)
    {
        var alreadyOwnedStockCount = 0;
        if(_stocks.Any(s => s.company == company))
        {
            alreadyOwnedStockCount = Stocks.First(s => s.company == company).amount;
        }
        if(alreadyOwnedStockCount == 0 || alreadyOwnedStockCount - amount < 0)
        {
            throw new ArgumentException();
        }

        _stocks.RemoveAll(t => t.company == company);
        if(alreadyOwnedStockCount - amount == 0)
        {
            return;
        }
        _stocks.Add((company, alreadyOwnedStockCount - amount));
    }
}