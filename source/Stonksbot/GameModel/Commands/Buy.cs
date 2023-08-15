using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel.Commands;

internal class Buy : IStonksCommand
{
    private readonly ICommandResultCommunicator _commandResultCommunicator;

    public const string Token = "buy";
    
    public readonly string Buyer;

    public readonly string CompanyToBuy;

    public readonly int Amount;
    public Buy(List<string> arguments, ICommandResultCommunicator commandResultCommunicator)
    {
        Buyer = arguments[0];
        CompanyToBuy = arguments[1];
        Amount = int.Parse(arguments[2]);
        _commandResultCommunicator = commandResultCommunicator;
    }

    public void Execute(BaseData baseData)
    {
        var player = baseData._playerbase.Player.First(player => player.Identifier == Buyer);
        var companyToBuy = baseData._stockmarket.Companies.First(company => company.Name == CompanyToBuy);
        player.AddStock(companyToBuy,Amount);
        companyToBuy.SubtractStock(Amount);
        _commandResultCommunicator.CommunicateResult("Bought the stuff");
    }

    public static bool IsToken(string token)
    {
        return token == Token;
    }
}