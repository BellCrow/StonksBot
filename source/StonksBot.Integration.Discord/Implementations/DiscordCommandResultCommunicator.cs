using Discord.Commands;
using Discord.WebSocket;
using StonksBot.Core.Commands;

namespace StonksBot.Integration.Discord.Implementations;

public class DiscordCommandResultCommunicator : ICommandResultCommunicator
{
    private readonly DiscordSocketClient _socketClient;
    private readonly SocketUserMessage _socketUserMessage;

    public DiscordCommandResultCommunicator(DiscordSocketClient socketClient, SocketUserMessage socketUserMessage)
    {
        _socketClient = socketClient;
        _socketUserMessage = socketUserMessage;
    }

    public void CommunicateCommandResultSuccess()
    {
        var socketCommandContext = new SocketCommandContext(_socketClient, _socketUserMessage);
        socketCommandContext.Channel.SendMessageAsync("Success executing command");
    }

    public void CommunicateCommandResultFail(string reason)
    {
        var socketCommandContext = new SocketCommandContext(_socketClient, _socketUserMessage);
        socketCommandContext.Channel.SendMessageAsync($"Error executing command: {reason}");
    }
}