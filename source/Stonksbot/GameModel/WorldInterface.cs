using Stonksbot.Communication.Interface;
using Stonksbot.GameModel.CompanyClasses;
using Stonksbot.GameModel.PlayerClasses;

namespace Stonksbot.GameModel;

internal class WorldInterface
{
    private const string BuyCommand = "buy";

    private const string InspectPlayerCommand = "inspectp";

    private const string ListCompaniesCommand = "listc";

    private const string ListPlayersCommand = "listp";

    private const string NextCommand = "next";

    private const string SellCommand = "sell";

    private readonly IStonksCommandSource _commandSource;

    private readonly IEventCommunicator _eventCommunicator;

    private readonly Playerbase _playerbase;

    private readonly Stockmarket _stockmarket;

    private CompanyPriceChanger _companyPriceChanger;

    
    public WorldInterface(IStonksCommandSource commandSource,IEventCommunicator eventCommunicator,Playerbase playerbase, Stockmarket stockmarket)
    {
        //TODO: make this a dependency
        _companyPriceChanger = new CompanyPriceChanger(stockmarket.Companies.ToList());
        _commandSource = commandSource ?? throw new ArgumentNullException(nameof(commandSource));
        _eventCommunicator = eventCommunicator ?? throw new ArgumentNullException(nameof(eventCommunicator));
        _stockmarket = stockmarket;
        _playerbase = playerbase;
        _commandSource.CommandReceived += (_, com) => HandleCommand(com);
    }

    public void HandleCommand(IStonksCommand command)
    {
        var tokens = command.CommandText.Trim().Split(' ');
        if(!tokens.Any())
        {
            throw new ArgumentException();
        }
        //TODO: replace homebrew command parsing
        var commandToken = tokens.First();
        switch(commandToken)
        {
            case InspectPlayerCommand:
                {
                    //assume second argument is present and a player name
                    var playerName = tokens[1];
                    var player = _playerbase.Player.First(p => p.Identifier == playerName);
                    string playerPortfolio = string.Join(", ", player.Stocks.Select(s => $"{s.amount} x {s.company.Name}"));
                    command.CommunicateResult($"{player.Identifier}, {player.Money} $ -> {playerPortfolio}");
                    break;
                }
            case ListCompaniesCommand:
                {
                    string companyInfos = string.Join("\n", _stockmarket.Companies.Select(c => $"{c.Name} -> {c.Price} $"));
                    command.CommunicateResult(companyInfos);
                    break;
                }
            case BuyCommand:
                {
                    //assume second argument is present and a player name
                    var playerName = tokens[1];
                    //assume third argument is present and a company name
                    var companyName = tokens[2];
                    var stockAmount = int.Parse(tokens[3]);
                    if(stockAmount <= 0)
                    {
                        throw new ArgumentException();
                    }

                    var player = _playerbase.Player.First(p => p.Identifier == playerName);
                    var companyToBuyFrom = _stockmarket.Companies.First(c => c.Name == companyName);
                    companyToBuyFrom.BuyStock(stockAmount);
                    player.AddStock(companyToBuyFrom, stockAmount);
                    break;
                }
            case SellCommand:
                {
                    //assume second argument is present and a player name
                    var playerName = tokens[1];
                    //assume third argument is present and a company name
                    var companyName = tokens[2];
                    var stockAmount = int.Parse(tokens[3]);
                    if(stockAmount <= 0)
                    {
                        throw new ArgumentException();
                    }

                    var player = _playerbase.Player.First(p => p.Identifier == playerName);
                    var companyToSell = _stockmarket.Companies.First(c => c.Name == companyName);
                    companyToSell.SellStock(stockAmount);
                    player.SubtractStock(companyToSell, stockAmount);
                    break;
                }
            case NextCommand:
                {
                    _companyPriceChanger.Step();
                    break;
                }
            case ListPlayersCommand:
                {
                    var playerList = string.Join(", ", _playerbase.Player.Select(p => p.Identifier));
                    command.CommunicateResult(playerList);
                    break;
                }
            default:
                command.CommunicateResult($"Error: The command {commandToken} is not recognized");
                break;
        }
    }
}