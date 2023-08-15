using Stonksbot.Communication.Interface;
using Stonksbot.GameModel.CompanyClasses;
using Stonksbot.GameModel.PlayerClasses;

namespace Stonksbot.GameModel;

public class BaseData
{
    private const string BuyCommand = "buy";

    private const string InspectPlayerCommand = "inspectp";

    private const string ListCompaniesCommand = "listc";

    private const string ListPlayersCommand = "listp";

    private const string NextCommand = "next";

    private const string SellCommand = "sell";

    private readonly IStonksCommandSource _commandSource;

    private readonly IEventCommunicator _eventCommunicator;

    public readonly Playerbase _playerbase;

    public readonly Stockmarket _stockmarket;

    private CompanyPriceChanger _companyPriceChanger;

    
    public BaseData(
        IStonksCommandSource commandSource,
        IEventCommunicator eventCommunicator,
        Playerbase playerbase,
        Stockmarket stockmarket)
    {
        //TODO: make this a dependency
        _companyPriceChanger = new CompanyPriceChanger(stockmarket.Companies.ToList());
        _commandSource = commandSource ?? throw new ArgumentNullException(nameof(commandSource));
        _eventCommunicator = eventCommunicator ?? throw new ArgumentNullException(nameof(eventCommunicator));
        _stockmarket = stockmarket ?? throw new ArgumentNullException(nameof(stockmarket));
        _playerbase = playerbase ?? throw new ArgumentNullException(nameof(playerbase));
        _commandSource.CommandReceived += (_, com) => com.Execute(this);
    }
}