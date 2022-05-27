namespace StonksBot.Core.Commands;

public interface ICommandResultCommunicator
{
    void CommunicateCommandResultSuccess();

    void CommunicateCommandResultFail(string reason);
}