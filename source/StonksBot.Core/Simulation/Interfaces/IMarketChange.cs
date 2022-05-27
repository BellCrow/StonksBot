using StonksBot.Core.Entities;

namespace StonksBot.Core.Simulation.Interfaces;

public interface IMarketChange
{
    void Apply(Market market);
}