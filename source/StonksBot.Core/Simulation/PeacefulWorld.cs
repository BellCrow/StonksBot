using StonksBot.Core.Simulation.Interfaces;

namespace StonksBot.Core.Simulation;

public class PeacefulWorld : IWorld
{
    public IReadOnlyList<StonksEvent> WorldTick()
    {
        var ret = new List<StonksEvent>();
        var marketChanges = new List<IMarketChange>
        {
            new StableMarketChange()
        };
        ret.Add(new StonksEvent("The market is stable...as is tradition", marketChanges));
        return ret;
    }
}