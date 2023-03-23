using StonksBotProject.Communication.Interface;

namespace StonksBotProject.GameModel
{
    internal class WorldInterface
    {
        List<Company> _companies = new List<Company>
        {
            new Company("Teslor",100,250),
            new Company("Macrohard",200,50),
        };

        List<Player> _player = new List<Player>
        {
            new Player("tim", 2000),
            new Player("eve", 2500),
            new Player("liz", 1500),
        };

        CompanyPriceChanger _companyPriceChanger;

        public WorldInterface(IStonksCommandSource commandSource, IEventCommunicator eventCommunicator)
        {
            //TODO: make this a dependency
            _companyPriceChanger = new CompanyPriceChanger(_companies);
            _commandSource = commandSource ?? throw new ArgumentNullException(nameof(commandSource));
            _eventCommunicator = eventCommunicator ?? throw new ArgumentNullException(nameof(eventCommunicator));
            _commandSource.CommandReceived += (_, com) => HandleCommand(com);
        }

        const string ListPlayersCommand = "listp";
        const string InspectPlayerCommand = "inspectp";
        const string ListCompaniesCommand = "listc";
        const string BuyCommand = "buy";
        const string SellCommand = "sell";
        const string NextCommand = "next";
        private readonly IStonksCommandSource _commandSource;
        private readonly IEventCommunicator _eventCommunicator;

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
                        var player = _player.First(p => p.Identifier == playerName);
                        string playerPortfolio = string.Join(", ", player.Stocks.Select(s => $"{s.amount} x {s.company.Name}"));
                        command.CommunicateResult($"{player.Identifier}, {player.Money} $ -> {playerPortfolio}");
                        break;
                    }
                case ListCompaniesCommand:
                    {
                        string companyInfos = string.Join("\n", _companies.Select(c => $"{c.Name} -> {c.Price} $"));
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

                        var player = _player.First(p => p.Identifier == playerName);
                        var companyToBuyFrom = _companies.First(c => c.Name == companyName);
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

                        var player = _player.First(p => p.Identifier == playerName);
                        var companyToSell = _companies.First(c => c.Name == companyName);
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
                        var playerList = string.Join(", ", _player.Select(p => p.Identifier));
                        command.CommunicateResult(playerList);
                        break;
                    }
                default:
                    command.CommunicateResult($"Error: The command {commandToken} is not recognized");
                    break;
            }


        }
    }
}
