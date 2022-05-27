namespace StonksBot.Core.Simulation.Interfaces;

public interface ISimulationTicker
{
    event EventHandler Tick;
}