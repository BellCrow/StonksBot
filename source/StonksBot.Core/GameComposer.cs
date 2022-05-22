namespace StonksBot.Core;

public class GameComposer
{
    public GameComposer(Market market, List<ShareHolder> shareHolder)
    {
        Market = market;
        ShareHolder = shareHolder;
    }

    public Market Market { get; }
    public List<ShareHolder> ShareHolder { get; }

    public void ExecuteCommand(Command command)
    {
        switch (command.CommandType)
        {
            case CommandType.Sell:
                ExecuteSellCommand(command.ShareHolder, command.Company, command.Amount);
                break;
            case CommandType.Buy:
                ExecuteBuyCommand(command.ShareHolder, command.Company, command.Amount);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void ExecuteSellCommand(ShareHolder shareHolder, Company company, int amount)
    {
        var sharesToSellToMarket = shareHolder.Portfolio.DeductShare(company, amount);
        var valueForShareSell = sharesToSellToMarket.Value;
        Market.Portfolio.AddShare(sharesToSellToMarket);
        shareHolder.Money += valueForShareSell;
    }

    private void ExecuteBuyCommand(ShareHolder shareHolder, Company company, int amount)
    {
        var costsForShare = company.Value * amount;
        if (shareHolder.Money < costsForShare)
            throw new ArgumentException(
                "The specified shareholder does not have enough money to buy the specified amount of shares");

        var boughtShare = Market.Portfolio.DeductShare(company, amount);
        shareHolder.Money -= boughtShare.Value;
        shareHolder.Portfolio.AddShare(boughtShare);
    }
}