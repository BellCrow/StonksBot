using StonksBot.Core.Entities;
using StonksBot.Core.Simulation.Interfaces;

namespace StonksBot.Core.Simulation;

public class StableMarketChange:IMarketChange
{
    public void Apply(Market market)
    {
        //intentionally left blank. is supposed to make no change to the market
    }
}