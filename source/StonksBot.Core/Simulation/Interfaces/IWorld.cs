namespace StonksBot.Core.Simulation.Interfaces;

public interface IWorld
{
    IReadOnlyList<StonksEvent> WorldTick();
}