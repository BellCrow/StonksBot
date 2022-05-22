namespace StonksBot.Core;

public class Command
{
    public Command(CommandType commandType, ShareHolder shareHolder, Company company, int amount)
    {
        CommandType = commandType;
        ShareHolder = shareHolder;
        Company = company;
        Amount = amount;
    }

    public CommandType CommandType { get; }
    public ShareHolder ShareHolder { get; }
    public Company Company { get; }
    public int Amount { get; }
}