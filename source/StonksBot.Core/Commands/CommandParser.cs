using StonksBot.Core.Entities;

namespace StonksBot.Core.Commands;

public class CommandParser : ICommandParser
{
    private readonly Market _market;

    public CommandParser(Market market)
    {
        _market = market;
    }

    /// <summary>
    ///     Is used to translate string commands like
    ///     tim buy companyname 20 into an <see cref="Command" /> object.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="gameComposer"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public Command TranslateCommandString(string command,
        ICommandResultCommunicator commandResultCommunicator)
    {
        var commandSeparator = " ";
        var commandTokens = command.Trim().Split(commandSeparator);
        var userName = commandTokens[0];
        var commandTypeString = commandTokens[1];
        var companyName = commandTokens[2];
        var amountString = commandTokens[3];

        if (Enum.TryParse(commandTypeString, true, out CommandType commandType))
        {
            var amount = int.Parse(amountString);

            var shareHolder = _market.ShareHolder.First(shareHolder =>
                string.Equals(shareHolder.Identifier, userName, StringComparison.CurrentCultureIgnoreCase));

            var company =
                _market.Broker.TradedCompanies.First(iterCompany =>
                    string.Equals(iterCompany.Name, companyName, StringComparison.CurrentCultureIgnoreCase));
            var gameCommand = new Command(commandType, shareHolder, company, amount, commandResultCommunicator);
            return gameCommand;
        }

        throw new ArgumentException($"Command {commandTypeString} is not recognized as a valid command");
    }
}