using Stonksbot.GameModel;

namespace Stonksbot.Communication.Interface;

public interface IStonksCommand
{
    public void Execute(BaseData worldInterface);
}