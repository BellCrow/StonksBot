using Discord.WebSocket;

namespace StonksBot.Integration.Discord;

public class DiscordMessageFilter
{
    //TODO: maybe make these variables configurable for the user. at least the channel name
    private const string StonksCommand = "stonks";
    private const string StonksBotChannelName = "stonkbot_test_area";
    public bool IsMessageStonksCommand(SocketUserMessage message)
    {
        var messageContent = message.Content;
        if (message.Channel.Name != StonksBotChannelName)
        {
            return false;
        }
        return messageContent.Trim().ToLower().StartsWith(StonksCommand);
    }
}