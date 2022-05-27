namespace StonksBot.Core.Commands;

public interface ICommandParser
{
    /// <summary>
    ///     Is used to translate string commands like
    ///     tim buy companyname 20 into an <see cref="Command" /> object.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="gameComposer"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    Command TranslateCommandString(string command,
        ICommandResultCommunicator commandResultCommunicator);
}