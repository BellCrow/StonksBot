// See https://aka.ms/new-console-template for more information

using StonksBot.Core;

namespace Stonksbot.Integration.Console;

public class MainClass
{
    public static void Main(string[] args)
    {
        var shareHolders = new List<ShareHolder> { CreateShareHolder("Tim",3000), CreateShareHolder("Debra", 5000) };

        var gameComposer = new GameComposer(CreateMarket(), shareHolders);
        var command = string.Empty;

        var exitCommand = "exit";
        while (command != exitCommand)
        {
            command = System.Console.ReadLine();
            if (string.IsNullOrEmpty(command) || command == exitCommand)
            {
                continue;
            }

            try
            {
                gameComposer.ExecuteCommand(TranslateCommandString(command,gameComposer));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }
    }

    private static Command TranslateCommandString(string command, GameComposer gameComposer)
    {
        var commandSeparator = " ";
        var commandTokens = command.Split(commandSeparator);
        var userName = commandTokens[0];
        var commandTypeString = commandTokens[1];
        var companyName = commandTokens[2];
        var amountString = commandTokens[3];
        
        if (CommandType.TryParse(commandTypeString, true, out CommandType commandType))
        {
            int amount = int.Parse(amountString);
            ShareHolder shareHolder = gameComposer.ShareHolder.First(shareHolder => String.Equals(shareHolder.Identifier, userName, StringComparison.CurrentCultureIgnoreCase));
            Company company =
                gameComposer.Market.TradedCompanies.First(iterCompany =>
                    String.Equals(iterCompany.Name, companyName, StringComparison.CurrentCultureIgnoreCase));
            var gameCommand = new Command(commandType, shareHolder, company, amount);
            return gameCommand;
        }
        throw new ArgumentException($"Command {commandTypeString} is not recognized as a valid command");
    }

    private static ShareHolder CreateShareHolder(string name, int capital)
    {
        var shares = new List<Share>();
        return new ShareHolder(name, new Portfolio(shares), capital);
    }

    private static Market CreateMarket()
    {
        var marketShares = new List<Share>();

        //Creation of test companies that have shares you can buy
        
        var tesla = new Company("Teslor", 20);
        var apple = new Company("Erpple", 18);
        var microsoft = new Company("Macrohard", 14);
        var tradedCompanies = new List<Company> { tesla,apple,microsoft};
            

        marketShares.Add(new Share(tesla, 100));
        marketShares.Add(new Share(apple, 200));
        marketShares.Add(new Share(microsoft, 70));
        var marketPortFolio = new Portfolio(marketShares);
        return new Market(marketPortFolio, tradedCompanies);
    }
}