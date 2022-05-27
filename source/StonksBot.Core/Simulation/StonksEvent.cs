using StonksBot.Core.Simulation.Interfaces;

namespace StonksBot.Core.Simulation;

public class StonksEvent
{
    public StonksEvent(string announcementMessage, IReadOnlyList<IMarketChange> marketChanges)
    {
        AnnouncementMessage = announcementMessage;
        MarketChanges = marketChanges;
    }

    public string AnnouncementMessage { get; }
    public IReadOnlyList<IMarketChange> MarketChanges { get; }
}