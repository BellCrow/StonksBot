using StonksBot.Core.Entities;

namespace StonksBot.Core.Commands;

public class Command
{
    public Command(CommandType commandType, ShareHolder shareHolder, Company company, int amount,
        ICommandResultCommunicator commandResultCommunicator)
    {
        CommandType = commandType;
        ShareHolder = shareHolder;
        Company = company;
        Amount = amount;
        CommandResultCommunicator = commandResultCommunicator;
    }

    public CommandType CommandType { get; }
    public ShareHolder ShareHolder { get; }
    public Company Company { get; }
    public int Amount { get; }
    public ICommandResultCommunicator CommandResultCommunicator { get; }
}