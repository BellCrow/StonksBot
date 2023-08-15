using Stonksbot.Communication.Interface;

namespace Stonksbot.Communication.Discord;

internal class DiscordCommandResultCommunicator : ICommandResultCommunicator
{
    private readonly IDiscordConnection _connection;

    public DiscordCommandResultCommunicator(IDiscordConnection connection)
    {
        _connection = connection;
    }

    public void CommunicateResult(string result)
    {
        _connection.SendMessage(result);
    }
}