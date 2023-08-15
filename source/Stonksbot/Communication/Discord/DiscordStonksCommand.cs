using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Stonksbot.Communication.Interface;

namespace Stonksbot.Communication.Discord
{
    internal class DiscordStonksCommand : IStonksCommand
    {
        private readonly IDiscordConnection _connection;

        public DiscordStonksCommand(IDiscordConnection connection, string commandText)
        {
            _connection = connection;
            CommandText = commandText;
        }

        public string CommandText { get; }

        public void CommunicateResult(string result)
        {
            _connection.SendMessage(result);
        }

    }
}