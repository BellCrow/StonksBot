using Stonksbot.Communication.Interface;

namespace Stonksbot.GameModel.Commands
{
    public class Sell:IStonksCommand
    {
        private static readonly string Token = "sell";
        
        private readonly ICommandResultCommunicator _commandResultCommunicator;
        
        private readonly string _seller;
        
        private readonly string _companyToSell;
        
        private readonly int _amount;

        public Sell(List<string> arguments, ICommandResultCommunicator commandResultCommunicator)
        {
            _commandResultCommunicator = commandResultCommunicator;
            _seller = arguments[0];
            _companyToSell = arguments[1];
            _amount = int.Parse(arguments[2]);
        }

        public static bool IsToken(string token)
        {
            return token == Token;
        }

        public void Execute(BaseData baseData)
        {
            var player = baseData._playerbase.Player.First(player => player.Identifier == _seller);
            var companyToSell = baseData._stockmarket.Companies.First(company => company.Name == _companyToSell);
            player.SubtractStock(companyToSell,_amount);
            companyToSell.AddStock(_amount);
            _commandResultCommunicator.CommunicateResult("Sold the stuff");
        }
    }
    
}